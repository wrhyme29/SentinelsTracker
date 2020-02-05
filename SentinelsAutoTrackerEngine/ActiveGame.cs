//----------------------------------------------------
// Copyright 2019 Epic Systems Corporation
//----------------------------------------------------

using System.Collections.Generic;
using System.Collections.ObjectModel;
using static SentinelsAutoTrackerEngine.AmountModifier;

namespace SentinelsAutoTrackerEngine
{
	public class ActiveGame
	{
		public List<CharacterAccount> HeroPlayers { get; set; }
		public List<CharacterAccount> HeroTargets { get; set; }
		public List<CharacterAccount> NonHeroTargets { get; set; }
		public List<CharacterAccount> VillainTargets { get; set; }
		public List<CharacterAccount> EnvCharacters { get; set; }
		public Dictionary<int, CharacterAccount> AllTargets { get; set; }

		public Dictionary<int, Modifier> GlobalHeroModifers { get; private set; }
		public Dictionary<int, Modifier> GlobalEnvironmentModifiers { get; private set; }
		public Dictionary<int, Modifier> GlobalVillainModifiers { get; private set; }
		public ObservableCollection<Modifier> GlobalAllModifiers { get; private set; }


		public ActiveGame()
		{
			HeroPlayers = new List<CharacterAccount>();
			HeroTargets = new List<CharacterAccount>();
			NonHeroTargets = new List<CharacterAccount>();
			VillainTargets = new List<CharacterAccount>();
			EnvCharacters = new List<CharacterAccount>();
			AllTargets = new Dictionary<int, CharacterAccount>();

			GlobalEnvironmentModifiers = new Dictionary<int, Modifier>();
			GlobalHeroModifers = new Dictionary<int, Modifier>();
			GlobalVillainModifiers = new Dictionary<int, Modifier>();
			GlobalAllModifiers = new ObservableCollection<Modifier>();
		}

		public void AssignGlobalModifiers(CharacterAccount characterAccount, Dictionary<int, Modifier> modifiers)
		{
			foreach (Modifier modifier in modifiers.Values)
			{
				if (modifier.GetType() == typeof(AmountModifier))
				{
					AmountModifier amountModifier = (AmountModifier)modifier;
					switch (amountModifier.ModifierType)
					{
						case AmountModifierType.DamageGiven:
							characterAccount.AddDamageGivenMod(amountModifier);
							break;
						case AmountModifierType.DamageTaken:
							characterAccount.AddDamageTakenMod(amountModifier);
							break;
						case AmountModifierType.Health:
							characterAccount.AddHealthMod(amountModifier);
							break;
						default:
							break;
					}
				}
				else if (modifier.GetType() == typeof(ImmunityModifier))
				{
					characterAccount.AddDamageImmunityMod((ImmunityModifier)modifier);
				}
				else if (modifier.GetType() == typeof(DamageTypeModifier))
				{
					characterAccount.AddDamageTypeMod((DamageTypeModifier)modifier);
				}
			}
		}

	}
}
