//----------------------------------------------------
// Copyright 2019 Epic Systems Corporation
//----------------------------------------------------

using System.Collections.Generic;
using static SentinelsAutoTrackerEngine.CustomDataTypes;
using static SentinelsAutoTrackerEngine.Modifier;
using static SentinelsAutoTrackerEngine.Utilities;

namespace SentinelsAutoTrackerEngine
{
	public class GameContainer
	{
		public static Dictionary<int, HeroPlayer> AllPossibleHeroesList { get; private set; }
		public static ActiveGame ActiveGame { get; set; }
		public static void SetupGame()
		{
			AllPossibleHeroesList = new Dictionary<int, HeroPlayer>();
			ActiveGame = new ActiveGame();
			CharacterAccount.ClearIdCounter();
			Modifier.ClearIdCounter();
			foreach (HeroPlayer hero in ReadHeroCSVResource(Properties.Resources.HeroData))
			{
				AllPossibleHeroesList.Add(hero.UniqueId, hero);
			}
		}

		public static void AddHeroPlayer(int heroId)
		{
			
			AllPossibleHeroesList[heroId].AddSelfToParentList(ActiveGame.AllTargets, ActiveGame.HeroTargets, ActiveGame.HeroPlayers);

		}

		public static int AddHeroTarget(string name, int health, DamageType damageType)
		{
			HeroTarget heroTarget = new HeroTarget(name, health, damageType);
			heroTarget.AddSelfToParentList(ActiveGame.AllTargets, ActiveGame.HeroTargets);

			return heroTarget.UniqueId;
		}

		public static int AddVillainTarget(string name, int health, DamageType damageType)
		{
			VillainTarget villainTarget = new VillainTarget(name, health, damageType);
			villainTarget.AddSelfToParentList(ActiveGame.AllTargets, ActiveGame.NonHeroTargets, ActiveGame.VillainTargets);

			return villainTarget.UniqueId;
		}

		public static int AddEnvironmentTarget(string name, int health, DamageType damageType)
		{
			EnvironmentTarget environmentTarget = new EnvironmentTarget(name, health, damageType);
			environmentTarget.AddSelfToParentList(ActiveGame.AllTargets, ActiveGame.NonHeroTargets, ActiveGame.EnvCharacters);

			return environmentTarget.UniqueId;
		}

		public static void DealDamage(CharacterAccount from, CharacterAccount to, int amount, DamageType damageType)
		{
			Damage dmg = from.DealDamage(amount, damageType);
			to.TakeDamage(dmg);

			if(to.CurrentHealth <= 0)
			{
				to.Destroyed();
			}
		}

		public static void HealCharacter(CharacterAccount from, CharacterAccount to, int amount)
		{
			to.Heal(amount);
		}

		public static void AddDamageGivenModifier(AmountModifier modifier, CharacterAccount characterAccount)
		{
			switch(modifier.Target)
			{
				case ModifierTargets.Local:
					characterAccount.AddDamageGivenMod(modifier);
					break;
				case ModifierTargets.AllTargets:
					ActiveGame.GlobalEnvironmentModifiers.Add(modifier.UniqueId, modifier);
					ActiveGame.GlobalHeroModifers.Add(modifier.UniqueId, modifier);
					ActiveGame.GlobalVillainModifiers.Add(modifier.UniqueId, modifier);
					ActiveGame.GlobalAllModifiers.Add(modifier);

					foreach (CharacterAccount character in ActiveGame.AllTargets.Values)
					{
						character.AddDamageGivenMod(modifier);
					}
					break;
				case ModifierTargets.EnvironmentTargets:
					ActiveGame.GlobalEnvironmentModifiers.Add(modifier.UniqueId, modifier);
					ActiveGame.GlobalAllModifiers.Add(modifier);

					foreach (CharacterAccount character in ActiveGame.EnvCharacters)
					{
						character.AddDamageGivenMod(modifier);
					}
					break;
				case ModifierTargets.HeroTargets:
					ActiveGame.GlobalHeroModifers.Add(modifier.UniqueId, modifier);
					ActiveGame.GlobalAllModifiers.Add(modifier);

					foreach (CharacterAccount character in ActiveGame.HeroTargets)
					{
						character.AddDamageGivenMod(modifier);
					}
					break;
				case ModifierTargets.VillainTargets:
					ActiveGame.GlobalVillainModifiers.Add(modifier.UniqueId, modifier);
					ActiveGame.GlobalAllModifiers.Add(modifier);

					foreach (CharacterAccount character in ActiveGame.VillainTargets)
					{
						character.AddDamageGivenMod(modifier);
					}
					break;
				default:
					break;
			}
		}

		public static void AddDamageTakenModifier(AmountModifier modifier, CharacterAccount characterAccount)
		{
			switch (modifier.Target)
			{
				case ModifierTargets.Local:
					characterAccount.AddDamageTakenMod(modifier);
					break;
				case ModifierTargets.AllTargets:
					ActiveGame.GlobalEnvironmentModifiers.Add(modifier.UniqueId, modifier);
					ActiveGame.GlobalHeroModifers.Add(modifier.UniqueId, modifier);
					ActiveGame.GlobalVillainModifiers.Add(modifier.UniqueId, modifier);
					ActiveGame.GlobalAllModifiers.Add(modifier);

					foreach (CharacterAccount character in ActiveGame.AllTargets.Values)
					{
						character.AddDamageTakenMod(modifier);
					}
					break;
				case ModifierTargets.EnvironmentTargets:
					ActiveGame.GlobalEnvironmentModifiers.Add(modifier.UniqueId, modifier);
					ActiveGame.GlobalAllModifiers.Add(modifier);

					foreach (CharacterAccount character in ActiveGame.EnvCharacters)
					{
						character.AddDamageTakenMod(modifier);
					}
					break;
				case ModifierTargets.HeroTargets:
					ActiveGame.GlobalHeroModifers.Add(modifier.UniqueId, modifier);
					ActiveGame.GlobalAllModifiers.Add(modifier);

					foreach (CharacterAccount character in ActiveGame.HeroTargets)
					{
						character.AddDamageTakenMod(modifier);
					}
					break;
				case ModifierTargets.VillainTargets:
					ActiveGame.GlobalVillainModifiers.Add(modifier.UniqueId, modifier);
					ActiveGame.GlobalAllModifiers.Add(modifier);

					foreach (CharacterAccount character in ActiveGame.VillainTargets)
					{
						character.AddDamageTakenMod(modifier);
					}
					break;
				default:
					break;
			}
		}

		public static void AddDamageImmunityModifier(ImmunityModifier modifier, CharacterAccount characterAccount)
		{
			switch (modifier.Target)
			{
				case ModifierTargets.Local:
					characterAccount.AddDamageImmunityMod(modifier);
					break;
				case ModifierTargets.AllTargets:
					ActiveGame.GlobalEnvironmentModifiers.Add(modifier.UniqueId, modifier);
					ActiveGame.GlobalHeroModifers.Add(modifier.UniqueId, modifier);
					ActiveGame.GlobalVillainModifiers.Add(modifier.UniqueId, modifier);
					ActiveGame.GlobalAllModifiers.Add(modifier);

					foreach (CharacterAccount character in ActiveGame.AllTargets.Values)
					{
						character.AddDamageImmunityMod(modifier);
					}
					break;
				case ModifierTargets.EnvironmentTargets:
					ActiveGame.GlobalEnvironmentModifiers.Add(modifier.UniqueId, modifier);
					ActiveGame.GlobalAllModifiers.Add(modifier);

					foreach (CharacterAccount character in ActiveGame.EnvCharacters)
					{
						character.AddDamageImmunityMod(modifier);
					}
					break;
				case ModifierTargets.HeroTargets:
					ActiveGame.GlobalHeroModifers.Add(modifier.UniqueId, modifier);
					ActiveGame.GlobalAllModifiers.Add(modifier);

					foreach (CharacterAccount character in ActiveGame.HeroTargets)
					{
						character.AddDamageImmunityMod(modifier);
					}
					break;
				case ModifierTargets.VillainTargets:
					ActiveGame.GlobalVillainModifiers.Add(modifier.UniqueId, modifier);
					ActiveGame.GlobalAllModifiers.Add(modifier);

					foreach (CharacterAccount character in ActiveGame.VillainTargets)
					{
						character.AddDamageImmunityMod(modifier);
					}
					break;
				default:
					break;
			}
		}

		public static void AddHealthModifier(AmountModifier modifier, CharacterAccount characterAccount)
		{
			switch (modifier.Target)
			{
				case ModifierTargets.Local:
					characterAccount.AddHealthMod(modifier);
					break;
				case ModifierTargets.AllTargets:
					ActiveGame.GlobalEnvironmentModifiers.Add(modifier.UniqueId, modifier);
					ActiveGame.GlobalHeroModifers.Add(modifier.UniqueId, modifier);
					ActiveGame.GlobalVillainModifiers.Add(modifier.UniqueId, modifier);
					ActiveGame.GlobalAllModifiers.Add(modifier);

					foreach (CharacterAccount character in ActiveGame.AllTargets.Values)
					{
						character.AddHealthMod(modifier);
					}
					break;
				case ModifierTargets.EnvironmentTargets:
					ActiveGame.GlobalEnvironmentModifiers.Add(modifier.UniqueId, modifier);
					ActiveGame.GlobalAllModifiers.Add(modifier);

					foreach (CharacterAccount character in ActiveGame.EnvCharacters)
					{
						character.AddHealthMod(modifier);
					}
					break;
				case ModifierTargets.HeroTargets:
					ActiveGame.GlobalHeroModifers.Add(modifier.UniqueId, modifier);
					ActiveGame.GlobalAllModifiers.Add(modifier);

					foreach (CharacterAccount character in ActiveGame.HeroTargets)
					{
						character.AddHealthMod(modifier);
					}
					break;
				case ModifierTargets.VillainTargets:
					ActiveGame.GlobalVillainModifiers.Add(modifier.UniqueId, modifier);
					ActiveGame.GlobalAllModifiers.Add(modifier);

					foreach (CharacterAccount character in ActiveGame.VillainTargets)
					{
						character.AddHealthMod(modifier);
					}
					break;
				default:
					break;
			}
		}

		public static void AddDamageTypeModifier(DamageTypeModifier modifier, CharacterAccount characterAccount)
		{
			switch (modifier.Target)
			{
				case ModifierTargets.Local:
					characterAccount.AddDamageTypeMod(modifier);
					break;
				case ModifierTargets.AllTargets:
					ActiveGame.GlobalEnvironmentModifiers.Add(modifier.UniqueId, modifier);
					ActiveGame.GlobalHeroModifers.Add(modifier.UniqueId, modifier);
					ActiveGame.GlobalVillainModifiers.Add(modifier.UniqueId, modifier);
					ActiveGame.GlobalAllModifiers.Add(modifier);

					foreach (CharacterAccount character in ActiveGame.AllTargets.Values)
					{
						character.AddDamageTypeMod(modifier);
					}
					break;
				case ModifierTargets.EnvironmentTargets:
					ActiveGame.GlobalEnvironmentModifiers.Add(modifier.UniqueId, modifier);
					ActiveGame.GlobalAllModifiers.Add(modifier);

					foreach (CharacterAccount character in ActiveGame.EnvCharacters)
					{
						character.AddDamageTypeMod(modifier);
					}
					break;
				case ModifierTargets.HeroTargets:
					ActiveGame.GlobalHeroModifers.Add(modifier.UniqueId, modifier);
					ActiveGame.GlobalAllModifiers.Add(modifier);

					foreach (CharacterAccount character in ActiveGame.HeroTargets)
					{
						character.AddDamageTypeMod(modifier);
					}
					break;
				case ModifierTargets.VillainTargets:
					ActiveGame.GlobalVillainModifiers.Add(modifier.UniqueId, modifier);
					ActiveGame.GlobalAllModifiers.Add(modifier);

					foreach (CharacterAccount character in ActiveGame.VillainTargets)
					{
						character.AddDamageTypeMod(modifier);
					}
					break;
				default:
					break;
			}
		}

		public static void RemoveGlobalModifier(Modifier modifier)
		{
			ActiveGame.GlobalAllModifiers.Remove(modifier);
			RemoveModifierFromAllCharacters(modifier);

			foreach (int uniqueId in ActiveGame.GlobalEnvironmentModifiers.Keys)
			{
				if(uniqueId == modifier.UniqueId)
				{
					ActiveGame.GlobalEnvironmentModifiers.Remove(uniqueId);
					break;
				}
			}

			foreach (int uniqueId in ActiveGame.GlobalHeroModifers.Keys)
			{
				if (uniqueId == modifier.UniqueId)
				{
					ActiveGame.GlobalHeroModifers.Remove(uniqueId);
					break;
				}
			}

			foreach (int uniqueId in ActiveGame.GlobalVillainModifiers.Keys)
			{
				if (uniqueId == modifier.UniqueId)
				{
					ActiveGame.GlobalVillainModifiers.Remove(uniqueId);
					break;
				}
			}
		}

		private static void RemoveModifierFromAllCharacters(Modifier modifier)
		{
			foreach(CharacterAccount characterAccount in ActiveGame.AllTargets.Values)
			{
				if(characterAccount.AllModifiers.Contains(modifier))
				{
					characterAccount.AllModifiers.Remove(modifier);

					if (modifier.GetType() == typeof(AmountModifier))
					{
						characterAccount.RemoveAmountModifier((AmountModifier)modifier);
					}
					else if (modifier.GetType() == typeof(DamageTypeModifier))
					{
						characterAccount.RemoveDamageTypeMod((DamageTypeModifier)modifier);
					}
					else if (modifier.GetType() == typeof(ImmunityModifier))
					{
						characterAccount.RemoveImmunityMod((ImmunityModifier)modifier);
					}
				}
			}
		}
	}

}
