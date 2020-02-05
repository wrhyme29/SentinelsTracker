//----------------------------------------------------
// Copyright 2019 Epic Systems Corporation
//----------------------------------------------------

using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SentinelsAutoTrackerEngine;
using static SentinelsAutoTrackerEngine.AmountModifier;
using static SentinelsAutoTrackerEngine.CustomDataTypes;
using static SentinelsAutoTrackerEngine.Modifier;

namespace SentinelsAutoTrackerTests
{
	[TestClass]
	public class ModifiersTests
	{
		[TestMethod]
		public void DamageGivenModTest()
		{
			Setup.SetupTestInfrastructure();
			ActiveGame activeGame = GameContainer.ActiveGame;
			try
			{
				AmountModifier damageGivenMod = new AmountModifier("Galvanize", "Increase all damage by 1", ModifierTargets.Local, AmountModifierType.DamageGiven,1, false);
				CharacterAccount fromAccount = activeGame.AllTargets[43];
				CharacterAccount toAccount = activeGame.AllTargets[87];
				GameContainer.AddDamageGivenModifier(damageGivenMod, fromAccount);

				GameContainer.DealDamage(fromAccount, toAccount, 4, DamageType.Melee);

				int expectedHealth = 10;
				int actualhealth = toAccount.CurrentHealth;
				Assert.IsTrue(expectedHealth == actualhealth, $"{toAccount.Name} health doesn't match expected health. Expected {expectedHealth}, actually {actualhealth}");

				int expectedMod = 1;
				int actualMod = fromAccount.DamageGivenMod;
				Assert.IsTrue(expectedMod == actualMod, $"{fromAccount.Name} damage given mod doesn't match expected mod. Expected {expectedMod}, actually {actualMod}");

			}
			catch (Exception e)
			{
				Assert.Fail("Test failed: " + e);
			}
		}

		[TestMethod]
		public void DamageGivenOneTimeModTest()
		{
			Setup.SetupTestInfrastructure();
			ActiveGame activeGame = GameContainer.ActiveGame;
			try
			{

				AmountModifier damageGivenMod = new AmountModifier("Critical Multiplier", "Increase next damage by 1", ModifierTargets.Local, AmountModifierType.DamageGiven, 1, true);
				CharacterAccount fromAccount = activeGame.AllTargets[43];
				CharacterAccount toAccount = activeGame.AllTargets[87];
				GameContainer.AddDamageGivenModifier(damageGivenMod, fromAccount);

				GameContainer.DealDamage(fromAccount, toAccount, 4, DamageType.Melee);

				int expectedHealth = 10;
				int actualhealth = toAccount.CurrentHealth;
				Assert.IsTrue(expectedHealth == actualhealth, $"{toAccount.Name} health doesn't match expected health. Expected {expectedHealth}, actually {actualhealth}");

				int expectedMod = 0;
				int actualMod = fromAccount.DamageGivenMod;
				Assert.IsTrue(expectedMod == actualMod, $"{fromAccount.Name} damage given mod doesn't match expected mod. Expected {expectedMod}, actually {actualMod}");

			}
			catch (Exception e)
			{
				Assert.Fail("Test failed: " + e);
			}
		}

		[TestMethod]
		public void DamageTakenModTest()
		{
			Setup.SetupTestInfrastructure();
			ActiveGame activeGame = GameContainer.ActiveGame;
			try
			{

				AmountModifier damageTakenMod = new AmountModifier("HeavyPlating", "Decrease damage taken by 1", ModifierTargets.Local, AmountModifierType.DamageTaken, - 1, false);
				CharacterAccount fromAccount = activeGame.AllTargets[43];
				CharacterAccount toAccount = activeGame.AllTargets[87];
				GameContainer.AddDamageTakenModifier(damageTakenMod, toAccount);

				GameContainer.DealDamage(fromAccount, toAccount, 4, DamageType.Melee);

				int expectedHealth = 12;
				int actualhealth = toAccount.CurrentHealth;
				Assert.IsTrue(expectedHealth == actualhealth, $"{toAccount.Name} health doesn't match expected health. Expected {expectedHealth}, actually {actualhealth}");

				int expectedMod = -1;
				int actualMod = toAccount.DamageTakenMod;
				Assert.IsTrue(expectedMod == actualMod, $"{toAccount.Name} damage taken mod doesn't match expected mod. Expected {expectedMod}, actually {actualMod}");

			}
			catch (Exception e)
			{
				Assert.Fail("Test failed: " + e);
			}
		}

		[TestMethod]
		public void DamageTakenOneTimeModTest()
		{
			Setup.SetupTestInfrastructure();
			ActiveGame activeGame = GameContainer.ActiveGame;
			try
			{

				AmountModifier damageTakenMod = new AmountModifier("Breakable Plating", "Decrease next damage taken by 1", ModifierTargets.Local, AmountModifierType.DamageTaken, - 1, true);
				CharacterAccount fromAccount = activeGame.AllTargets[43];
				CharacterAccount toAccount = activeGame.AllTargets[87];
				GameContainer.AddDamageTakenModifier(damageTakenMod, toAccount);

				GameContainer.DealDamage(fromAccount, toAccount, 4, DamageType.Melee);

				int expectedHealth = 12;
				int actualhealth = toAccount.CurrentHealth;
				Assert.IsTrue(expectedHealth == actualhealth, $"{toAccount.Name} health doesn't match expected health. Expected {expectedHealth}, actually {actualhealth}");

				int expectedMod = 0;
				int actualMod = toAccount.DamageTakenMod;
				Assert.IsTrue(expectedMod == actualMod, $"{toAccount.Name} damage taken mod doesn't match expected mod. Expected {expectedMod}, actually {actualMod}");

			}
			catch (Exception e)
			{
				Assert.Fail("Test failed: " + e);
			}
		}

		[TestMethod]
		public void HealModTest()
		{
			Setup.SetupTestInfrastructure();
			ActiveGame activeGame = GameContainer.ActiveGame;
			try
			{

				AmountModifier healthMod = new AmountModifier("Healing Field", "Increase healing by 1", ModifierTargets.Local, AmountModifierType.Health, 1, false);
				CharacterAccount fromAccount = activeGame.AllTargets[43];
				CharacterAccount toAccount = activeGame.AllTargets[87];
				GameContainer.AddHealthModifier(healthMod, toAccount);

				GameContainer.DealDamage(fromAccount, toAccount, 4, DamageType.Melee);

				GameContainer.HealCharacter(toAccount, toAccount, 1);

				int expectedHealth = 13;
				int actualhealth = toAccount.CurrentHealth;
				Assert.IsTrue(expectedHealth == actualhealth, $"{toAccount.Name} health doesn't match expected health. Expected {expectedHealth}, actually {actualhealth}");

				int expectedMod = 1;
				int actualMod = toAccount.HealthMod;
				Assert.IsTrue(expectedMod == actualMod, $"{toAccount.Name} health mod doesn't match expected mod. Expected {expectedMod}, actually {actualMod}");

			}
			catch (Exception e)
			{
				Assert.Fail("Test failed: " + e);
			}
		}

		[TestMethod]
		public void HealOneTimeModTest()
		{
			Setup.SetupTestInfrastructure();
			ActiveGame activeGame = GameContainer.ActiveGame;
			try
			{

				AmountModifier healthMod = new AmountModifier("Healing Field", "Increase next healing by 1", ModifierTargets.Local, AmountModifierType.Health, 1, true);
				CharacterAccount fromAccount = activeGame.AllTargets[43];
				CharacterAccount toAccount = activeGame.AllTargets[87];
				GameContainer.AddHealthModifier(healthMod, toAccount);

				GameContainer.DealDamage(fromAccount, toAccount, 4, DamageType.Melee);

				GameContainer.HealCharacter(toAccount, toAccount, 1);

				int expectedHealth = 13;
				int actualhealth = toAccount.CurrentHealth;
				Assert.IsTrue(expectedHealth == actualhealth, $"{toAccount.Name} health doesn't match expected health. Expected {expectedHealth}, actually {actualhealth}");

				int expectedMod = 0;
				int actualMod = toAccount.HealthMod;
				Assert.IsTrue(expectedMod == actualMod, $"{toAccount.Name} health mod doesn't match expected mod. Expected {expectedMod}, actually {actualMod}");

			}
			catch (Exception e)
			{
				Assert.Fail("Test failed: " + e);
			}
		}

		[TestMethod]
		public void ImmunityAllModTest()
		{
			Setup.SetupTestInfrastructure();
			ActiveGame activeGame = GameContainer.ActiveGame;
			try
			{

				ImmunityModifier immunityMod = new ImmunityModifier("Mobile Defense Platform", "Baron Blade is Immune to Damage", ModifierTargets.Local, DamageType.All);
				CharacterAccount fromAccount = activeGame.AllTargets[43];
				CharacterAccount toAccount = activeGame.AllTargets[87];
				GameContainer.AddDamageImmunityModifier(immunityMod, toAccount);

				GameContainer.DealDamage(fromAccount, toAccount, 4, DamageType.Melee);

				int expectedHealth = 15;
				int actualhealth = toAccount.CurrentHealth;
				Assert.IsTrue(expectedHealth == actualhealth, $"{toAccount.Name} health doesn't match expected health for Melee test. Expected {expectedHealth}, actually {actualhealth}");

				GameContainer.DealDamage(fromAccount, toAccount, 4, DamageType.Fire);

				expectedHealth = 15;
				actualhealth = toAccount.CurrentHealth;
				Assert.IsTrue(expectedHealth == actualhealth, $"{toAccount.Name} health doesn't match expected health for Fire test. Expected {expectedHealth}, actually {actualhealth}");


			}
			catch (Exception e)
			{
				Assert.Fail("Test failed: " + e);
			}
		}

		[TestMethod]
		public void ImmunityTypeSpecificModTest()
		{
			Setup.SetupTestInfrastructure();
			ActiveGame activeGame = GameContainer.ActiveGame;
			try
			{

				ImmunityModifier immunityMod = new ImmunityModifier("Flesh of the Sun God", "Ra is Immune to Fire Damage", ModifierTargets.Local, DamageType.Fire);
				CharacterAccount fromAccount = activeGame.AllTargets[43];
				CharacterAccount toAccount = activeGame.AllTargets[87];
				GameContainer.AddDamageImmunityModifier(immunityMod, toAccount);

				GameContainer.DealDamage(fromAccount, toAccount, 4, DamageType.Melee);

				int expectedHealth = 11;
				int actualhealth = toAccount.CurrentHealth;
				Assert.IsTrue(expectedHealth == actualhealth, $"{toAccount.Name} health doesn't match expected health for Melee test. Expected {expectedHealth}, actually {actualhealth}");

				GameContainer.DealDamage(fromAccount, toAccount, 4, DamageType.Fire);

				expectedHealth = 11;
				actualhealth = toAccount.CurrentHealth;
				Assert.IsTrue(expectedHealth == actualhealth, $"{toAccount.Name} health doesn't match expected health for Fire test. Expected {expectedHealth}, actually {actualhealth}");


			}
			catch (Exception e)
			{
				Assert.Fail("Test failed: " + e);
			}
		}

		[TestMethod]
		public void DamageGivenGlobalAllTargetsModTest()
		{
			Setup.SetupTestInfrastructure();
			ActiveGame activeGame = GameContainer.ActiveGame;
			try
			{
				AmountModifier damageGivenMod = new AmountModifier("Obsidion Field", "Increase all damage by 1", ModifierTargets.AllTargets, AmountModifierType.DamageGiven, 1, false);
				CharacterAccount fromAccount = activeGame.AllTargets[43];
				CharacterAccount toAccount = activeGame.AllTargets[87];
				GameContainer.AddDamageGivenModifier(damageGivenMod, fromAccount);

				GameContainer.DealDamage(fromAccount, toAccount, 4, DamageType.Melee);

				int expectedHealth = 10;
				int actualhealth = toAccount.CurrentHealth;
				Assert.IsTrue(expectedHealth == actualhealth, $"{toAccount.Name} health doesn't match expected health. Expected {expectedHealth}, actually {actualhealth}");

				int expectedMod = 1;
				int actualMod = fromAccount.DamageGivenMod;
				Assert.IsTrue(expectedMod == actualMod, $"{fromAccount.Name} damage given mod doesn't match expected mod. Expected {expectedMod}, actually {actualMod}");
				Assert.IsTrue(activeGame.GlobalEnvironmentModifiers.ContainsValue(damageGivenMod), "Global Environment Mods List does not contain expected modifier");
				Assert.IsTrue(activeGame.GlobalHeroModifers.ContainsValue(damageGivenMod), "Global Environment Mods List does not contain expected modifier");
				Assert.IsTrue(activeGame.GlobalVillainModifiers.ContainsValue(damageGivenMod), "Global Environment Mods List does not contain expected modifier");

				foreach(CharacterAccount characterAccount in activeGame.AllTargets.Values)
				{
					Assert.IsTrue(characterAccount.DamageGivenModList.ContainsValue(damageGivenMod), $"{characterAccount} does not contain the expected modifier");
				}
			}
			catch (Exception e)
			{
					Assert.Fail("Test failed: " + e);
			}
		}

		[TestMethod]
		public void DamageGivenGlobalHeroTargetsModTest()
		{
			Setup.SetupTestInfrastructure();
			ActiveGame activeGame = GameContainer.ActiveGame;
			try
			{
				AmountModifier damageGivenMod = new AmountModifier("Obsidion Field", "Increase all damage by 1", ModifierTargets.HeroTargets, AmountModifierType.DamageGiven, 1, false);
				CharacterAccount fromAccount = activeGame.AllTargets[43];
				CharacterAccount toAccount = activeGame.AllTargets[87];
				GameContainer.AddDamageGivenModifier(damageGivenMod, fromAccount);

				
				Assert.IsTrue(!activeGame.GlobalEnvironmentModifiers.ContainsValue(damageGivenMod), "Global Environment Mods List incorrectly contains expected modifier");
				Assert.IsTrue(activeGame.GlobalHeroModifers.ContainsValue(damageGivenMod), "Global Environment Mods List does not contain expected modifier");
				Assert.IsTrue(!activeGame.GlobalVillainModifiers.ContainsValue(damageGivenMod), "Global Environment Mods List incorrectly contains expected modifier");

				foreach (CharacterAccount characterAccount in activeGame.HeroTargets)
				{
					Assert.IsTrue(characterAccount.DamageGivenModList.ContainsValue(damageGivenMod), $"{characterAccount} does not contain the expected modifier");
				}
			}
			catch (Exception e)
			{
				Assert.Fail("Test failed: " + e);
			}
		}

		[TestMethod]
		public void DamageGivenGlobalEnvironmentTargetsModTest()
		{
			Setup.SetupTestInfrastructure();
			ActiveGame activeGame = GameContainer.ActiveGame;
			try
			{
				AmountModifier damageGivenMod = new AmountModifier("Obsidion Field", "Increase all damage by 1", ModifierTargets.EnvironmentTargets, AmountModifierType.DamageGiven, 1, false);
				CharacterAccount fromAccount = activeGame.AllTargets[43];
				CharacterAccount toAccount = activeGame.AllTargets[87];
				GameContainer.AddDamageGivenModifier(damageGivenMod, fromAccount);


				Assert.IsTrue(activeGame.GlobalEnvironmentModifiers.ContainsValue(damageGivenMod), "Global Environment Mods List does not contain expected modifier");
				Assert.IsTrue(!activeGame.GlobalHeroModifers.ContainsValue(damageGivenMod), "Global Environment Mods List incorrectly contains expected modifier");
				Assert.IsTrue(!activeGame.GlobalVillainModifiers.ContainsValue(damageGivenMod), "Global Environment Mods List incorrectly contains expected modifier");

				foreach (CharacterAccount characterAccount in activeGame.EnvCharacters)
				{
					Assert.IsTrue(characterAccount.DamageGivenModList.ContainsValue(damageGivenMod), $"{characterAccount} does not contain the expected modifier");
				}
			}
			catch (Exception e)
			{
				Assert.Fail("Test failed: " + e);
			}
		}

		[TestMethod]
		public void DamageGivenGlobalVillainTargetsModTest()
		{
			Setup.SetupTestInfrastructure();
			ActiveGame activeGame = GameContainer.ActiveGame;
			try
			{
				AmountModifier damageGivenMod = new AmountModifier("Obsidion Field", "Increase all damage by 1", ModifierTargets.VillainTargets, AmountModifierType.DamageGiven, 1, false);
				CharacterAccount fromAccount = activeGame.AllTargets[43];
				CharacterAccount toAccount = activeGame.AllTargets[87];
				GameContainer.AddDamageGivenModifier(damageGivenMod, fromAccount);


				Assert.IsTrue(!activeGame.GlobalEnvironmentModifiers.ContainsValue(damageGivenMod), "Global Environment Mods List incorrectly contains expected modifier");
				Assert.IsTrue(!activeGame.GlobalHeroModifers.ContainsValue(damageGivenMod), "Global Environment Mods List incorrectly contains expected modifier");
				Assert.IsTrue(activeGame.GlobalVillainModifiers.ContainsValue(damageGivenMod), "Global Environment Mods List does not contain expected modifier");

				foreach (CharacterAccount characterAccount in activeGame.VillainTargets)
				{
					Assert.IsTrue(characterAccount.DamageGivenModList.ContainsValue(damageGivenMod), $"{characterAccount} does not contain the expected modifier");
				}
			}
			catch (Exception e)
			{
				Assert.Fail("Test failed: " + e);
			}
		}

		[TestMethod]
		public void DamageTakenGlobalAllTargetsModTest()
		{
			Setup.SetupTestInfrastructure();
			ActiveGame activeGame = GameContainer.ActiveGame;
			try
			{
				AmountModifier DamageTakenMod = new AmountModifier("Obsidion Field", "Increase all damage by 1", ModifierTargets.AllTargets, AmountModifierType.DamageTaken, 1, false);
				CharacterAccount fromAccount = activeGame.AllTargets[43];
				CharacterAccount toAccount = activeGame.AllTargets[87];
				GameContainer.AddDamageTakenModifier(DamageTakenMod, fromAccount);


				Assert.IsTrue(activeGame.GlobalEnvironmentModifiers.ContainsValue(DamageTakenMod), "Global Environment Mods List does not contain expected modifier");
				Assert.IsTrue(activeGame.GlobalHeroModifers.ContainsValue(DamageTakenMod), "Global Environment Mods List does not contain expected modifier");
				Assert.IsTrue(activeGame.GlobalVillainModifiers.ContainsValue(DamageTakenMod), "Global Environment Mods List does not contain expected modifier");

				foreach (CharacterAccount characterAccount in activeGame.AllTargets.Values)
				{
					Assert.IsTrue(characterAccount.DamageTakenModList.ContainsValue(DamageTakenMod), $"{characterAccount} does not contain the expected modifier");
				}
			}
			catch (Exception e)
			{
				Assert.Fail("Test failed: " + e);
			}
		}

		[TestMethod]
		public void DamageTakenGlobalHeroTargetsModTest()
		{
			Setup.SetupTestInfrastructure();
			ActiveGame activeGame = GameContainer.ActiveGame;
			try
			{
				AmountModifier DamageTakenMod = new AmountModifier("Obsidion Field", "Increase all damage by 1", ModifierTargets.HeroTargets, AmountModifierType.DamageTaken, 1, false);
				CharacterAccount fromAccount = activeGame.AllTargets[43];
				CharacterAccount toAccount = activeGame.AllTargets[87];
				GameContainer.AddDamageTakenModifier(DamageTakenMod, fromAccount);


				Assert.IsTrue(!activeGame.GlobalEnvironmentModifiers.ContainsValue(DamageTakenMod), "Global Environment Mods List incorrectly contains expected modifier");
				Assert.IsTrue(activeGame.GlobalHeroModifers.ContainsValue(DamageTakenMod), "Global Environment Mods List does not contain expected modifier");
				Assert.IsTrue(!activeGame.GlobalVillainModifiers.ContainsValue(DamageTakenMod), "Global Environment Mods List incorrectly contains expected modifier");

				foreach (CharacterAccount characterAccount in activeGame.HeroTargets)
				{
					Assert.IsTrue(characterAccount.DamageTakenModList.ContainsValue(DamageTakenMod), $"{characterAccount} does not contain the expected modifier");
				}
			}
			catch (Exception e)
			{
				Assert.Fail("Test failed: " + e);
			}
		}

		[TestMethod]
		public void DamageTakenGlobalEnvironmentTargetsModTest()
		{
			Setup.SetupTestInfrastructure();
			ActiveGame activeGame = GameContainer.ActiveGame;
			try
			{
				AmountModifier DamageTakenMod = new AmountModifier("Obsidion Field", "Increase all damage by 1", ModifierTargets.EnvironmentTargets, AmountModifierType.DamageTaken, 1, false);
				CharacterAccount fromAccount = activeGame.AllTargets[43];
				CharacterAccount toAccount = activeGame.AllTargets[87];
				GameContainer.AddDamageTakenModifier(DamageTakenMod, fromAccount);


				Assert.IsTrue(activeGame.GlobalEnvironmentModifiers.ContainsValue(DamageTakenMod), "Global Environment Mods List does not contain expected modifier");
				Assert.IsTrue(!activeGame.GlobalHeroModifers.ContainsValue(DamageTakenMod), "Global Environment Mods List incorrectly contains expected modifier");
				Assert.IsTrue(!activeGame.GlobalVillainModifiers.ContainsValue(DamageTakenMod), "Global Environment Mods List incorrectly contains expected modifier");

				foreach (CharacterAccount characterAccount in activeGame.EnvCharacters)
				{
					Assert.IsTrue(characterAccount.DamageTakenModList.ContainsValue(DamageTakenMod), $"{characterAccount} does not contain the expected modifier");
				}
			}
			catch (Exception e)
			{
				Assert.Fail("Test failed: " + e);
			}
		}

		[TestMethod]
		public void DamageTakenGlobalVillainTargetsModTest()
		{
			Setup.SetupTestInfrastructure();
			ActiveGame activeGame = GameContainer.ActiveGame;
			try
			{
				AmountModifier DamageTakenMod = new AmountModifier("Obsidion Field", "Increase all damage by 1", ModifierTargets.VillainTargets, AmountModifierType.DamageTaken, 1, false);
				CharacterAccount fromAccount = activeGame.AllTargets[43];
				CharacterAccount toAccount = activeGame.AllTargets[87];
				GameContainer.AddDamageTakenModifier(DamageTakenMod, fromAccount);


				Assert.IsTrue(!activeGame.GlobalEnvironmentModifiers.ContainsValue(DamageTakenMod), "Global Environment Mods List incorrectly contains expected modifier");
				Assert.IsTrue(!activeGame.GlobalHeroModifers.ContainsValue(DamageTakenMod), "Global Environment Mods List incorrectly contains expected modifier");
				Assert.IsTrue(activeGame.GlobalVillainModifiers.ContainsValue(DamageTakenMod), "Global Environment Mods List does not contain expected modifier");

				foreach (CharacterAccount characterAccount in activeGame.VillainTargets)
				{
					Assert.IsTrue(characterAccount.DamageTakenModList.ContainsValue(DamageTakenMod), $"{characterAccount} does not contain the expected modifier");
				}
			}
			catch (Exception e)
			{
				Assert.Fail("Test failed: " + e);
			}
		}

		[TestMethod]
		public void DamageImmunityGlobalAllTargetsModTest()
		{
			Setup.SetupTestInfrastructure();
			ActiveGame activeGame = GameContainer.ActiveGame;
			try
			{
				ImmunityModifier DamageImmunityMod = new ImmunityModifier("Obsidion Field", "Increase all damage by 1", ModifierTargets.AllTargets, DamageType.All);
				CharacterAccount fromAccount = activeGame.AllTargets[43];
				CharacterAccount toAccount = activeGame.AllTargets[87];
				GameContainer.AddDamageImmunityModifier(DamageImmunityMod, fromAccount);


				Assert.IsTrue(activeGame.GlobalEnvironmentModifiers.ContainsValue(DamageImmunityMod), "Global Environment Mods List does not contain expected modifier");
				Assert.IsTrue(activeGame.GlobalHeroModifers.ContainsValue(DamageImmunityMod), "Global Environment Mods List does not contain expected modifier");
				Assert.IsTrue(activeGame.GlobalVillainModifiers.ContainsValue(DamageImmunityMod), "Global Environment Mods List does not contain expected modifier");

				foreach (CharacterAccount characterAccount in activeGame.AllTargets.Values)
				{
					Assert.IsTrue(characterAccount.ImmunityModList.ContainsValue(DamageImmunityMod), $"{characterAccount} does not contain the expected modifier");
				}
			}
			catch (Exception e)
			{
				Assert.Fail("Test failed: " + e);
			}
		}

		[TestMethod]
		public void DamageImmunityGlobalHeroTargetsModTest()
		{
			Setup.SetupTestInfrastructure();
			ActiveGame activeGame = GameContainer.ActiveGame;
			try
			{
				ImmunityModifier DamageImmunityMod = new ImmunityModifier("Obsidion Field", "Increase all damage by 1", ModifierTargets.HeroTargets, DamageType.All);
				CharacterAccount fromAccount = activeGame.AllTargets[43];
				CharacterAccount toAccount = activeGame.AllTargets[87];
				GameContainer.AddDamageImmunityModifier(DamageImmunityMod, fromAccount);


				Assert.IsTrue(!activeGame.GlobalEnvironmentModifiers.ContainsValue(DamageImmunityMod), "Global Environment Mods List incorrectly contains expected modifier");
				Assert.IsTrue(activeGame.GlobalHeroModifers.ContainsValue(DamageImmunityMod), "Global Environment Mods List does not contain expected modifier");
				Assert.IsTrue(!activeGame.GlobalVillainModifiers.ContainsValue(DamageImmunityMod), "Global Environment Mods List incorrectly contains expected modifier");

				foreach (CharacterAccount characterAccount in activeGame.HeroTargets)
				{
					Assert.IsTrue(characterAccount.ImmunityModList.ContainsValue(DamageImmunityMod), $"{characterAccount} does not contain the expected modifier");
				}
			}
			catch (Exception e)
			{
				Assert.Fail("Test failed: " + e);
			}
		}

		[TestMethod]
		public void DamageImmunityGlobalEnvironmentTargetsModTest()
		{
			Setup.SetupTestInfrastructure();
			ActiveGame activeGame = GameContainer.ActiveGame;
			try
			{
				ImmunityModifier DamageImmunityMod = new ImmunityModifier("Obsidion Field", "Increase all damage by 1", ModifierTargets.EnvironmentTargets, DamageType.All);
				CharacterAccount fromAccount = activeGame.AllTargets[43];
				CharacterAccount toAccount = activeGame.AllTargets[87];
				GameContainer.AddDamageImmunityModifier(DamageImmunityMod, fromAccount);


				Assert.IsTrue(activeGame.GlobalEnvironmentModifiers.ContainsValue(DamageImmunityMod), "Global Environment Mods List does not contain expected modifier");
				Assert.IsTrue(!activeGame.GlobalHeroModifers.ContainsValue(DamageImmunityMod), "Global Environment Mods List incorrectly contains expected modifier");
				Assert.IsTrue(!activeGame.GlobalVillainModifiers.ContainsValue(DamageImmunityMod), "Global Environment Mods List incorrectly contains expected modifier");

				foreach (CharacterAccount characterAccount in activeGame.EnvCharacters)
				{
					Assert.IsTrue(characterAccount.ImmunityModList.ContainsValue(DamageImmunityMod), $"{characterAccount} does not contain the expected modifier");
				}
			}
			catch (Exception e)
			{
				Assert.Fail("Test failed: " + e);
			}
		}

		[TestMethod]
		public void DamageImmunityGlobalVillainTargetsModTest()
		{
			Setup.SetupTestInfrastructure();
			ActiveGame activeGame = GameContainer.ActiveGame;
			try
			{
				ImmunityModifier DamageImmunityMod = new ImmunityModifier("Obsidion Field", "Increase all damage by 1", ModifierTargets.VillainTargets, DamageType.All);
				CharacterAccount fromAccount = activeGame.AllTargets[43];
				CharacterAccount toAccount = activeGame.AllTargets[87];
				GameContainer.AddDamageImmunityModifier(DamageImmunityMod, fromAccount);


				Assert.IsTrue(!activeGame.GlobalEnvironmentModifiers.ContainsValue(DamageImmunityMod), "Global Environment Mods List incorrectly contains expected modifier");
				Assert.IsTrue(!activeGame.GlobalHeroModifers.ContainsValue(DamageImmunityMod), "Global Environment Mods List incorrectly contains expected modifier");
				Assert.IsTrue(activeGame.GlobalVillainModifiers.ContainsValue(DamageImmunityMod), "Global Environment Mods List does not contain expected modifier");

				foreach (CharacterAccount characterAccount in activeGame.VillainTargets)
				{
					Assert.IsTrue(characterAccount.ImmunityModList.ContainsValue(DamageImmunityMod), $"{characterAccount} does not contain the expected modifier");
				}
			}
			catch (Exception e)
			{
				Assert.Fail("Test failed: " + e);
			}
		}

		[TestMethod]
		public void HealGlobalAllTargetsModTest()
		{
			Setup.SetupTestInfrastructure();
			ActiveGame activeGame = GameContainer.ActiveGame;
			try
			{
				AmountModifier healModifier = new AmountModifier("Obsidion Field", "Increase all damage by 1", ModifierTargets.AllTargets, AmountModifierType.Health, 1, false);
				CharacterAccount fromAccount = activeGame.AllTargets[43];
				CharacterAccount toAccount = activeGame.AllTargets[87];
				GameContainer.AddHealthModifier(healModifier, fromAccount);

				GameContainer.DealDamage(fromAccount, toAccount, 4, DamageType.Melee);

				Assert.IsTrue(activeGame.GlobalEnvironmentModifiers.ContainsValue(healModifier), "Global Environment Mods List does not contain expected modifier");
				Assert.IsTrue(activeGame.GlobalHeroModifers.ContainsValue(healModifier), "Global Environment Mods List does not contain expected modifier");
				Assert.IsTrue(activeGame.GlobalVillainModifiers.ContainsValue(healModifier), "Global Environment Mods List does not contain expected modifier");

				foreach (CharacterAccount characterAccount in activeGame.AllTargets.Values)
				{
					Assert.IsTrue(characterAccount.HealingModList.ContainsValue(healModifier), $"{characterAccount} does not contain the expected modifier");
				}
			}
			catch (Exception e)
			{
				Assert.Fail("Test failed: " + e);
			}
		}

		[TestMethod]
		public void HealGlobalHeroTargetsModTest()
		{
			Setup.SetupTestInfrastructure();
			ActiveGame activeGame = GameContainer.ActiveGame;
			try
			{
				AmountModifier healModifier = new AmountModifier("Obsidion Field", "Increase all damage by 1", ModifierTargets.HeroTargets, AmountModifierType.Health, 1, false);
				CharacterAccount fromAccount = activeGame.AllTargets[43];
				CharacterAccount toAccount = activeGame.AllTargets[87];
				GameContainer.AddHealthModifier(healModifier, fromAccount);


				Assert.IsTrue(!activeGame.GlobalEnvironmentModifiers.ContainsValue(healModifier), "Global Environment Mods List incorrectly contains expected modifier");
				Assert.IsTrue(activeGame.GlobalHeroModifers.ContainsValue(healModifier), "Global Environment Mods List does not contain expected modifier");
				Assert.IsTrue(!activeGame.GlobalVillainModifiers.ContainsValue(healModifier), "Global Environment Mods List incorrectly contains expected modifier");

				foreach (CharacterAccount characterAccount in activeGame.HeroTargets)
				{
					Assert.IsTrue(characterAccount.HealingModList.ContainsValue(healModifier), $"{characterAccount} does not contain the expected modifier");
				}
			}
			catch (Exception e)
			{
				Assert.Fail("Test failed: " + e);
			}
		}

		[TestMethod]
		public void HealGlobalEnvironmentTargetsModTest()
		{
			Setup.SetupTestInfrastructure();
			ActiveGame activeGame = GameContainer.ActiveGame;
			try
			{
				AmountModifier healthModifier = new AmountModifier("Obsidion Field", "Increase all damage by 1", ModifierTargets.EnvironmentTargets, AmountModifierType.Health, 1, false);
				CharacterAccount fromAccount = activeGame.AllTargets[43];
				CharacterAccount toAccount = activeGame.AllTargets[87];
				GameContainer.AddHealthModifier(healthModifier, fromAccount);


				Assert.IsTrue(activeGame.GlobalEnvironmentModifiers.ContainsValue(healthModifier), "Global Environment Mods List does not contain expected modifier");
				Assert.IsTrue(!activeGame.GlobalHeroModifers.ContainsValue(healthModifier), "Global Environment Mods List incorrectly contains expected modifier");
				Assert.IsTrue(!activeGame.GlobalVillainModifiers.ContainsValue(healthModifier), "Global Environment Mods List incorrectly contains expected modifier");

				foreach (CharacterAccount characterAccount in activeGame.EnvCharacters)
				{
					Assert.IsTrue(characterAccount.HealingModList.ContainsValue(healthModifier), $"{characterAccount} does not contain the expected modifier");
				}
			}
			catch (Exception e)
			{
				Assert.Fail("Test failed: " + e);
			}
		}

		[TestMethod]
		public void HealGlobalVillainTargetsModTest()
		{
			Setup.SetupTestInfrastructure();
			ActiveGame activeGame = GameContainer.ActiveGame;
			try
			{
				AmountModifier healthModifier = new AmountModifier("Obsidion Field", "Increase all damage by 1", ModifierTargets.VillainTargets, AmountModifierType.DamageGiven, 1, false);
				CharacterAccount fromAccount = activeGame.AllTargets[43];
				CharacterAccount toAccount = activeGame.AllTargets[87];
				GameContainer.AddHealthModifier(healthModifier, fromAccount);


				Assert.IsTrue(!activeGame.GlobalEnvironmentModifiers.ContainsValue(healthModifier), "Global Environment Mods List incorrectly contains expected modifier");
				Assert.IsTrue(!activeGame.GlobalHeroModifers.ContainsValue(healthModifier), "Global Environment Mods List incorrectly contains expected modifier");
				Assert.IsTrue(activeGame.GlobalVillainModifiers.ContainsValue(healthModifier), "Global Environment Mods List does not contain expected modifier");

				foreach (CharacterAccount characterAccount in activeGame.VillainTargets)
				{
					Assert.IsTrue(characterAccount.HealingModList.ContainsValue(healthModifier), $"{characterAccount} does not contain the expected modifier");
				}
			}
			catch (Exception e)
			{
				Assert.Fail("Test failed: " + e);
			}
		}

		[TestMethod]
		public void HealGlobalAddNewVillainModTest()
		{
			Setup.SetupTestInfrastructure();
			ActiveGame activeGame = GameContainer.ActiveGame;
			try
			{
				AmountModifier healthModifier = new AmountModifier("Obsidion Field", "Increase all damage by 1", ModifierTargets.VillainTargets, AmountModifierType.Health, 1, false);
				CharacterAccount fromAccount = activeGame.AllTargets[43];
				GameContainer.AddHealthModifier(healthModifier, fromAccount);

				VillainTarget villain = new VillainTarget("Generic Villain", 10, DamageType.Energy);

				Assert.IsTrue(villain.HealingModList.ContainsValue(healthModifier), "New villain character does not contain the expected modifier");
				
			}
			catch (Exception e)
			{
				Assert.Fail("Test failed: " + e);
			}
		}

		[TestMethod]
		public void HealGlobalAddNewHeroModTest()
		{
			Setup.SetupTestInfrastructure();
			ActiveGame activeGame = GameContainer.ActiveGame;
			try
			{
				AmountModifier healthModifier = new AmountModifier("Obsidion Field", "Increase all damage by 1", ModifierTargets.HeroTargets, AmountModifierType.Health, 1, false);
				CharacterAccount fromAccount = activeGame.AllTargets[43];
				GameContainer.AddHealthModifier(healthModifier, fromAccount);

				HeroTarget hero = new HeroTarget("Generic Hero", 10, DamageType.Energy);

				Assert.IsTrue(hero.HealingModList.ContainsValue(healthModifier), "New hero character does not contain the expected modifier");

			}
			catch (Exception e)
			{
				Assert.Fail("Test failed: " + e);
			}
		}

		[TestMethod]
		public void HealGlobalAddNewEnvironmentModTest()
		{
			Setup.SetupTestInfrastructure();
			ActiveGame activeGame = GameContainer.ActiveGame;
			try
			{
				AmountModifier healthModifier = new AmountModifier("Obsidion Field", "Increase all damage by 1", ModifierTargets.EnvironmentTargets, AmountModifierType.Health, 1, false);
				CharacterAccount fromAccount = activeGame.AllTargets[43];
				GameContainer.AddHealthModifier(healthModifier, fromAccount);

				EnvironmentTarget environmentTarget = new EnvironmentTarget("Generic Environment", 10, DamageType.Energy);

				Assert.IsTrue(environmentTarget.HealingModList.ContainsValue(healthModifier), "New environment character does not contain the expected modifier");

			}
			catch (Exception e)
			{
				Assert.Fail("Test failed: " + e);
			}
		}
	}
}
