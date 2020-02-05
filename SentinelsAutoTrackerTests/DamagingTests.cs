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
	public class DamagingTests
	{
		[TestMethod]
		public void PlayerDamagesVillain()
		{
			Setup.SetupTestInfrastructure();
			ActiveGame activeGame = GameContainer.ActiveGame;
			try
			{
				GameContainer.DealDamage(activeGame.AllTargets[55], activeGame.AllTargets[86], 5, DamageType.Fire);
				int expectedHealth = 45;
				int actualHealth = activeGame.AllTargets[86].CurrentHealth;
				Assert.IsTrue(expectedHealth == actualHealth, $"Baron Blade is not at the expected health. Expected {expectedHealth}, Actual {actualHealth}");

			}
			catch (Exception e)
			{
				Assert.Fail("Test failed: " + e);
			}

		}

		[TestMethod]
		public void PlayerDamagesHeroTarget()
		{
			Setup.SetupTestInfrastructure();
			ActiveGame activeGame = GameContainer.ActiveGame;
			try
			{
				GameContainer.DealDamage(activeGame.AllTargets[55], activeGame.AllTargets[88], 1, DamageType.Fire);
				int expectedHealth = 1;
				int actualHealth = activeGame.AllTargets[88].CurrentHealth;
				Assert.IsTrue(expectedHealth == actualHealth, $"Raptor Bot is not at the expected health. Expected {expectedHealth}, Actual {actualHealth}");

			}
			catch (Exception e)
			{
				Assert.Fail("Test failed: " + e);
			}

		}

		[TestMethod]
		public void VillainDamagesHeroTarget()
		{
			Setup.SetupTestInfrastructure();
			ActiveGame activeGame = GameContainer.ActiveGame;
			try
			{
				GameContainer.DealDamage(activeGame.AllTargets[86], activeGame.AllTargets[88], 1, DamageType.Melee);
				int expectedHealth = 1;
				int actualHealth = activeGame.AllTargets[88].CurrentHealth;
				Assert.IsTrue(expectedHealth == actualHealth, $"Raptor Bot is not at the expected health. Expected {expectedHealth}, Actual {actualHealth}");

			}
			catch (Exception e)
			{
				Assert.Fail("Test failed: " + e);
			}

		}

		[TestMethod]
		public void EnvironmentDamagesHeroTarget()
		{
			Setup.SetupTestInfrastructure();
			ActiveGame activeGame = GameContainer.ActiveGame;
			try
			{
				GameContainer.DealDamage(activeGame.AllTargets[87], activeGame.AllTargets[88], 1, DamageType.Melee);
				int expectedHealth = 1;
				int actualHealth = activeGame.AllTargets[88].CurrentHealth;
				Assert.IsTrue(expectedHealth == actualHealth, $"Raptor Bot is not at the expected health. Expected {expectedHealth}, Actual {actualHealth}");

			}
			catch (Exception e)
			{
				Assert.Fail("Test failed: " + e);
			}

		}

		[TestMethod]
		public void HeroTargetDamagesHeroTarget()
		{
			Setup.SetupTestInfrastructure();
			ActiveGame activeGame = GameContainer.ActiveGame;
			try
			{
				GameContainer.DealDamage(activeGame.AllTargets[88], activeGame.AllTargets[88], 1, DamageType.Melee);
				int expectedHealth = 1;
				int actualHealth = activeGame.AllTargets[88].CurrentHealth;
				Assert.IsTrue(expectedHealth == actualHealth, $"Raptor Bot is not at the expected health. Expected {expectedHealth}, Actual {actualHealth}");

			}
			catch (Exception e)
			{
				Assert.Fail("Test failed: " + e);
			}

		}



		[TestMethod]
		public void VillainDamagesVillain()
		{
			Setup.SetupTestInfrastructure();
			ActiveGame activeGame = GameContainer.ActiveGame;
			try
			{
				GameContainer.DealDamage(activeGame.AllTargets[86], activeGame.AllTargets[86], 5, DamageType.Melee);
				int expectedHealth = 45;
				int actualHealth = activeGame.AllTargets[86].CurrentHealth;
				Assert.IsTrue(expectedHealth == actualHealth, $"Baron Blade is not at the expected health. Expected {expectedHealth}, Actual {actualHealth}");

			}
			catch (Exception e)
			{
				Assert.Fail("Test failed: " + e);
			}

		}

		[TestMethod]
		public void VillainDamagesPlayer()
		{
			Setup.SetupTestInfrastructure();
			ActiveGame activeGame = GameContainer.ActiveGame;
			try
			{
				GameContainer.DealDamage(activeGame.AllTargets[86], activeGame.AllTargets[55], 5, DamageType.Melee);
				int expectedHealth = 25;
				int actualHealth = activeGame.AllTargets[55].CurrentHealth;
				Assert.IsTrue(expectedHealth == actualHealth, $"Ra is not at the expected health. Expected {expectedHealth}, Actual {actualHealth}");

			}
			catch (Exception e)
			{
				Assert.Fail("Test failed: " + e);
			}

		}

		[TestMethod]
		public void HeroTargetDamagesPlayer()
		{
			Setup.SetupTestInfrastructure();
			ActiveGame activeGame = GameContainer.ActiveGame;
			try
			{
				GameContainer.DealDamage(activeGame.AllTargets[88], activeGame.AllTargets[55], 5, DamageType.Melee);
				int expectedHealth = 25;
				int actualHealth = activeGame.AllTargets[55].CurrentHealth;
				Assert.IsTrue(expectedHealth == actualHealth, $"Ra is not at the expected health. Expected {expectedHealth}, Actual {actualHealth}");

			}
			catch (Exception e)
			{
				Assert.Fail("Test failed: " + e);
			}

		}

		[TestMethod]
		public void PlayerDamagesEnvironment()
		{
			Setup.SetupTestInfrastructure();
			ActiveGame activeGame = GameContainer.ActiveGame;
			try
			{
				GameContainer.DealDamage(activeGame.AllTargets[27], activeGame.AllTargets[87], 5, DamageType.Radiant);
				int expectedHealth = 10;
				int actualHealth = activeGame.AllTargets[87].CurrentHealth;
				Assert.IsTrue(expectedHealth == actualHealth, $"Enraged T-Rex is not at the expected health. Expected {expectedHealth}, Actual {actualHealth}");

			}
			catch (Exception e)
			{
				Assert.Fail("Test failed: " + e);
			}

		}

		[TestMethod]
		public void HeroTargetDamagesEnvironment()
		{
			Setup.SetupTestInfrastructure();
			ActiveGame activeGame = GameContainer.ActiveGame;
			try
			{
				GameContainer.DealDamage(activeGame.AllTargets[88], activeGame.AllTargets[87], 5, DamageType.Melee);
				int expectedHealth = 10;
				int actualHealth = activeGame.AllTargets[87].CurrentHealth;
				Assert.IsTrue(expectedHealth == actualHealth, $"Enraged T-Rex is not at the expected health. Expected {expectedHealth}, Actual {actualHealth}");

			}
			catch (Exception e)
			{
				Assert.Fail("Test failed: " + e);
			}

		}

		[TestMethod]
		public void PlayerDamagesPlayer()
		{
			Setup.SetupTestInfrastructure();
			ActiveGame activeGame = GameContainer.ActiveGame;
			try
			{
				GameContainer.DealDamage(activeGame.AllTargets[43], activeGame.AllTargets[43], 5, DamageType.Melee);
				int expectedHealth = 27;
				int actualHealth = activeGame.AllTargets[43].CurrentHealth;
				Assert.IsTrue(expectedHealth == actualHealth, $"Legacy is not at the expected health. Expected {expectedHealth}, Actual {actualHealth}");

			}
			catch (Exception e)
			{
				Assert.Fail("Test failed: " + e);
			}

		}

		[TestMethod]
		public void EnvironmentDamagesEnvironment()
		{
			Setup.SetupTestInfrastructure();
			ActiveGame activeGame = GameContainer.ActiveGame;
			try
			{
				GameContainer.DealDamage(activeGame.AllTargets[87], activeGame.AllTargets[87], 5, DamageType.Melee);
				int expectedHealth = 10;
				int actualHealth = activeGame.AllTargets[87].CurrentHealth;
				Assert.IsTrue(expectedHealth == actualHealth, $"Enraged T-Rex is not at the expected health. Expected {expectedHealth}, Actual {actualHealth}");

			}
			catch (Exception e)
			{
				Assert.Fail("Test failed: " + e);
			}

		}

		[TestMethod]
		public void EnvironmentDamagesPlayer()
		{
			Setup.SetupTestInfrastructure();
			ActiveGame activeGame = GameContainer.ActiveGame;
			try
			{
				GameContainer.DealDamage(activeGame.AllTargets[87], activeGame.AllTargets[43], 5, DamageType.Melee);
				int expectedHealth = 27;
				int actualHealth = activeGame.AllTargets[43].CurrentHealth;
				Assert.IsTrue(expectedHealth == actualHealth, $"Legacy is not at the expected health. Expected {expectedHealth}, Actual {actualHealth}");

			}
			catch (Exception e)
			{
				Assert.Fail("Test failed: " + e);
			}

		}

		[TestMethod]
		public void EnvironmentDamagesVillain()
		{
			Setup.SetupTestInfrastructure();
			ActiveGame activeGame = GameContainer.ActiveGame;
			try
			{
				GameContainer.DealDamage(activeGame.AllTargets[87], activeGame.AllTargets[86], 5, DamageType.Melee);
				int expectedHealth = 45;
				int actualHealth = activeGame.AllTargets[86].CurrentHealth;
				Assert.IsTrue(expectedHealth == actualHealth, $"Baron Blade is not at the expected health. Expected {expectedHealth}, Actual {actualHealth}");

			}
			catch (Exception e)
			{
				Assert.Fail("Test failed: " + e);
			}

		}

		[TestMethod]
		public void HeroTargetDamagesVillain()
		{
			Setup.SetupTestInfrastructure();
			ActiveGame activeGame = GameContainer.ActiveGame;
			try
			{
				GameContainer.DealDamage(activeGame.AllTargets[88], activeGame.AllTargets[86], 5, DamageType.Melee);
				int expectedHealth = 45;
				int actualHealth = activeGame.AllTargets[86].CurrentHealth;
				Assert.IsTrue(expectedHealth == actualHealth, $"Baron Blade is not at the expected health. Expected {expectedHealth}, Actual {actualHealth}");

			}
			catch (Exception e)
			{
				Assert.Fail("Test failed: " + e);
			}

		}

		[TestMethod]
		public void VillainDamagesEnvironment()
		{
			Setup.SetupTestInfrastructure();
			ActiveGame activeGame = GameContainer.ActiveGame;
			try
			{
				GameContainer.DealDamage(activeGame.AllTargets[87], activeGame.AllTargets[87], 5, DamageType.Melee);
				int expectedHealth = 10;
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
