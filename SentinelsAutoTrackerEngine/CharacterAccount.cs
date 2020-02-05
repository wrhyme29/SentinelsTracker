//----------------------------------------------------
// Copyright 2019 Epic Systems Corporation
//----------------------------------------------------


using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using static SentinelsAutoTrackerEngine.CustomDataTypes;

namespace SentinelsAutoTrackerEngine
{
	public class CharacterAccount : INotifyPropertyChanged
    {
		public string Name { get; private set; }
		public  Dictionary<int, CharacterAccount> AllTargetsParentList { get; private set; }

		private int _currentHealth;
		public int CurrentHealth
		{
			get
			{
				return _currentHealth;
			}

			set
			{
				_currentHealth = value;
				OnPropertyChanged("CurrentHealth");
			}
		}

		public int MaxHealth { get; private set; }

		public DamageType DefaultDamageType { get; private set; }
		public DamageType LastDamageType { get; private set; }

		public ObservableCollection<Modifier> AllModifiers { get; private set; } = new ObservableCollection<Modifier>();
		public int HealthMod { get; private set; }
		public int DamageGivenMod { get; private set; }
		public int DamageTakenMod { get; private set; }

		private Dictionary<int, AmountModifier> _damageGivenModList = new Dictionary<int, AmountModifier>();
		private Dictionary<int, AmountModifier> _damageTakenModList = new Dictionary<int, AmountModifier>();
		private Dictionary<int, AmountModifier> _healingModList = new Dictionary<int, AmountModifier>();
		private Dictionary<int, ImmunityModifier> _immunityModList = new Dictionary<int, ImmunityModifier>();
		private DictionaryStack<int, DamageTypeModifier> _damageTypeModList = new DictionaryStack<int,DamageTypeModifier>();

		private static int s_idCounter = 0;
		private static Queue<int> s_orphanedIds = new Queue<int>();
		public int UniqueId { get; private set; }

		private bool _incapped;
		public bool Incapped
		{
			get
			{
				return _incapped;
			}

			protected set
			{
				_incapped = value;
				OnPropertyChanged("Incapped");
			}
		}

		public Dictionary<int, AmountModifier> DamageGivenModList { get => _damageGivenModList; set => _damageGivenModList = value; }
		public Dictionary<int, AmountModifier> DamageTakenModList { get => _damageTakenModList; set => _damageTakenModList = value; }
		public Dictionary<int, AmountModifier> HealingModList { get => _healingModList; set => _healingModList = value; }
		public Dictionary<int, ImmunityModifier> ImmunityModList { get => _immunityModList; set => _immunityModList = value; }
		public DictionaryStack<int, DamageTypeModifier> DamageTypeModList { get => _damageTypeModList; set => _damageTypeModList = value; }

		public CharacterAccount(string name, int health, DamageType damageType)
		{
			Name = name;
			MaxHealth = health;
			CurrentHealth = health;
			DefaultDamageType = damageType;
			LastDamageType = damageType;
			HealthMod = 0;
			DamageGivenMod = 0;
			DamageTakenMod = 0;
			Incapped = false;

			AssignId();


			

		}

		private void AssignId()
		{
			if (s_orphanedIds.Count == 0)
			{
				UniqueId = s_idCounter;
				s_idCounter++;
			}
			else
			{
				UniqueId = s_orphanedIds.Dequeue();
			}
		}

		public Damage DealDamage(int damage, DamageType type)
		{
			int damageAmount = damage + DamageGivenMod;

			RemoveAllOneTimeDamageGivenMods();

			if (DamageTypeModList.Count() != 0)
			{
				type = DamageTypeModList.Peek().DamageType;
			}

			Damage damageDealt = new Damage(damageAmount, type);
			
			LastDamageType = type;
			return damageDealt;
		}

		public void Heal(int amount)
		{
			amount += HealthMod;

			RemoveAllOneTimeHealthMods();
			if(CurrentHealth <= 0)
			{
				CurrentHealth = 0;
			}
			else
			{
				CurrentHealth += amount;
				if (CurrentHealth > MaxHealth)
				{
					CurrentHealth = MaxHealth;
				}
			}
			
		}

		public void TakeDamage(Damage damage)
		{
			if(!CheckForImmnunity(damage))
			{
				int damageAmount = damage.Amount + DamageTakenMod;

				RemoveAllOneTimeDamageTakenMods();

				CurrentHealth -= damageAmount;
			}
			
		}

		private bool CheckForImmnunity(Damage damage)
		{
			foreach(ImmunityModifier modifier in ImmunityModList.Values)
			{
				if(modifier.DamageTypeImmunity == DamageType.All || modifier.DamageTypeImmunity == damage.Type)
				{
					return true;
				}
			}

			return false;
		}

		public void AddDamageImmunityMod(ImmunityModifier modifier)
		{
			ImmunityModList.Add(modifier.UniqueId, modifier);
			AllModifiers.Add(modifier);
		}

		public void AddDamageGivenMod(AmountModifier modifier)
		{
			DamageGivenModList.Add(modifier.UniqueId, modifier);
			DamageGivenMod += modifier.Amount;
			AllModifiers.Add(modifier);
		}

		public void AddDamageTakenMod(AmountModifier modifier)
		{
			DamageTakenModList.Add(modifier.UniqueId, modifier);
			DamageTakenMod += modifier.Amount;
			AllModifiers.Add(modifier);
		}

		public void AddHealthMod(AmountModifier modifier)
		{
			HealingModList.Add(modifier.UniqueId, modifier);
			HealthMod += modifier.Amount;
			AllModifiers.Add(modifier);

		}

		public void AddDamageTypeMod(DamageTypeModifier modifier)
		{
			DamageTypeModList.Push(modifier.UniqueId, modifier);
			AllModifiers.Add(modifier);

		}

		public void RemoveImmunityMod(ImmunityModifier modifier)
		{
			ImmunityModList.Remove(modifier.UniqueId);
			AllModifiers.Remove(modifier);
		}

		public void RemoveDamageGivenMod(AmountModifier modifier)
		{
			DamageGivenModList.Remove(modifier.UniqueId);
			DamageGivenMod -= modifier.Amount;
			AllModifiers.Remove(modifier);
		}

		public void RemoveDamageTakenMod(AmountModifier modifier)
		{
			DamageTakenModList.Remove(modifier.UniqueId);
			DamageTakenMod -= modifier.Amount;
			AllModifiers.Remove(modifier);
		}

		public void RemoveHealthMod(AmountModifier modifier)
		{
			HealingModList.Remove(modifier.UniqueId);
			HealthMod -= modifier.Amount;
			AllModifiers.Remove(modifier);
		}

		public void RemoveDamageTypeMod(DamageTypeModifier modifier)
		{
			DamageTypeModList.Remove(modifier.UniqueId);
			AllModifiers.Remove(modifier);
		}

		public void RemoveAllOneTimeDamageGivenMods()
		{
			List<int> keysToRemove = new List<int>();
			foreach (AmountModifier modifier in DamageGivenModList.Values)
			{
				if(modifier.OneTime)
				{
					keysToRemove.Add(modifier.UniqueId);
				}
			}

			foreach(int id in keysToRemove)
			{
				RemoveDamageGivenMod(DamageGivenModList[id]);
			}
		}

		public void RemoveAllOneTimeDamageTakenMods()
		{
			List<int> keysToRemove = new List<int>();
			foreach (AmountModifier modifier in DamageTakenModList.Values)
			{
				if (modifier.OneTime)
				{
					keysToRemove.Add(modifier.UniqueId);
				}
			}

			foreach (int id in keysToRemove)
			{
				RemoveDamageTakenMod(DamageTakenModList[id]);
			}
		}

		public void RemoveAllOneTimeHealthMods()
		{
			List<int> keysToRemove = new List<int>();
			foreach (AmountModifier modifier in HealingModList.Values)
			{
				if (modifier.OneTime)
				{
					keysToRemove.Add(modifier.UniqueId);
				}
			}

			foreach (int id in keysToRemove)
			{
				RemoveHealthMod(HealingModList[id]);
			}
		}

		public void RemoveAmountModifier(AmountModifier modifier)
		{
			int uniqueId = modifier.UniqueId;
			bool found = false;

			foreach(int modifierId in DamageGivenModList.Keys)
			{
				if(modifierId == uniqueId)
				{
					RemoveDamageGivenMod(modifier);
						found = true;
					break;
				}
			}

			if(!found)
			{
				foreach (int modifierId in DamageTakenModList.Keys)
				{
					if (modifierId == uniqueId)
					{
						RemoveDamageTakenMod(modifier);
						found = true;
						break;
					}
				}
			}
			
			if(!found)
			{
				foreach (int modifierId in HealingModList.Keys)
				{
					if (modifierId == uniqueId)
					{
						RemoveHealthMod(modifier);
						found = true;
						break;
					}
				}
			}
			
		}

		public override string ToString()
		{
			return $"{Name}, HP: {MaxHealth}, Default Damage: {DefaultDamageType}";
		}

		public event PropertyChangedEventHandler PropertyChanged;

		protected void OnPropertyChanged(string info)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(info));
		}

		public virtual void AddSelfToParentList(Dictionary<int, CharacterAccount> allTargets)
		{
			AllTargetsParentList = allTargets;
			if(AllTargetsParentList.ContainsKey(this.UniqueId))
			{
				AssignId();
			}
			AllTargetsParentList.Add(this.UniqueId, this);
		}

		public virtual void Destroyed()
		{
			AllTargetsParentList.Remove(this.UniqueId);
		}

		public static void ClearIdCounter()
		{
			s_idCounter = 0;
			s_orphanedIds.Clear();
		}
	}
}
