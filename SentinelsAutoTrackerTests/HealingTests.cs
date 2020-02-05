//----------------------------------------------------
// Copyright 2019 Epic Systems Corporation
//----------------------------------------------------

using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SentinelsAutoTrackerEngine;
using static SentinelsAutoTrackerEngine.CustomDataTypes;

namespace SentinelsAutoTrackerTests
{
	[TestClass]
	public class HealingTests
	{
		[TestMethod]
		public void HealHero()
		{
			Setup.SetupTestInfrastructure();
			ActiveGame activeGame = GameContainer.ActiveGame;
			GameContainer.DealDamage(activeGame.AllTargets[43], activeGame.AllTargets[43], 5, DamageType.Melee);
			try
			{
				GameContainer.HealCharacter(activeGame.AllTargets[43], activeGame.AllTargets[43], 3);
				int expectedHealth = 30;
				int actualHealth = activeGame.AllTargets[43].CurrentHealth;
				Assert.IsTrue(expectedHealth == actualHealth, $"Legacy is not at the expected health. Expected {expectedHealth}, Actual {actualHealth}");

			}
			catch (Exception e)
			{
				Assert.Fail("Test failed: " + e);
			}
		}

		[TestMethod]
		public void HealHeroTarget()
		{
			Setup.SetupTestInfrastructure();
			ActiveGame activeGame = GameContainer.ActiveGame;
			GameContainer.DealDamage(activeGame.AllTargets[88], activeGame.AllTargets[88], 1, DamageType.Melee);
			try
			{
				GameContainer.HealCharacter(activeGame.AllTargets[43], activeGame.AllTargets[88], 1);
				int expectedHealth = 2;
				int actualHealth = activeGame.AllTargets[88].CurrentHealth;
				Assert.IsTrue(expectedHealth == actualHealth, $"Raptor Bot is not at the expected health. Expected {expectedHealth}, Actual {actualHealth}");

			}
			catch (Exception e)
			{
				Assert.Fail("Test failed: " + e);
			}
		}

		[TestMethod]
		public void HealVillain()
		{
			Setup.SetupTestInfrastructure();
			ActiveGame activeGame = GameContainer.ActiveGame;
			GameContainer.DealDamage(activeGame.AllTargets[43], activeGame.AllTargets[86], 5, DamageType.Melee);
			try
			{
				GameContainer.HealCharacter(activeGame.AllTargets[43], activeGame.AllTargets[86], 3);
				int expectedHealth = 48;
				int actualHealth = activeGame.AllTargets[86].CurrentHealth;
				Assert.IsTrue(expectedHealth == actualHealth, $"Baron Blade is not at the expected health. Expected {expectedHealth}, Actual {actualHealth}");

			}
			catch (Exception e)
			{
				Assert.Fail("Test failed: " + e);
			}
		}

		[TestMethod]
		public void HealEnvironmentTarget()
		{
			Setup.SetupTestInfrastructure();
			ActiveGame activeGame = GameContainer.ActiveGame;
			GameContainer.DealDamage(activeGame.AllTargets[43], activeGame.AllTargets[87], 5, DamageType.Melee);
			try
			{
				GameContainer.HealCharacter(activeGame.AllTargets[43], activeGame.AllTargets[87], 3);
				int expectedHealth = 13;
				int actualHealth = activeGame.AllTargets[87].CurrentHealth;
				Assert.IsTrue(expectedHealth == actualHealth, $"Enraged T-Rex is not at the expected health. Expected {expectedHealth}, Actual {actualHealth}");

			}
			catch (Exception e)
			{
				Assert.Fail("Test failed: " + e);
			}
		}
	}
}
