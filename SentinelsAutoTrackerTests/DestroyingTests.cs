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
	public class DestroyingTests
	{
		[TestMethod]
		public void VillainTargetGetsDestroyed()
		{
			Setup.SetupTestInfrastructure();
			ActiveGame activeGame = GameContainer.ActiveGame;
			try
			{
				CharacterAccount villainTarget = activeGame.AllTargets[86];
				GameContainer.DealDamage(activeGame.AllTargets[55], villainTarget, 52, DamageType.Fire);
				Assert.IsTrue(!activeGame.VillainTargets.Contains(villainTarget), "Baron Blade is incorrectly still a member of the VillainTargetList");
				Assert.IsTrue(!activeGame.NonHeroTargets.Contains(villainTarget), "Baron Blade is incorrectly still a member of the NonHeroTargetsList");
				Assert.IsTrue(!activeGame.AllTargets.ContainsKey(villainTarget.UniqueId), "Baron Blade is incorrectly still a member of the dictionary AllTargets");

			}
			catch (Exception e)
			{
				Assert.Fail("Test failed: " + e);
			}
		}

		[TestMethod]
		public void EnvironmentTargetGetsDestroyed()
		{
			Setup.SetupTestInfrastructure();
			ActiveGame activeGame = GameContainer.ActiveGame;
			try
			{
				CharacterAccount environmentTarget = activeGame.AllTargets[87];
				GameContainer.DealDamage(activeGame.AllTargets[55], environmentTarget, 17, DamageType.Fire);
				Assert.IsTrue(!activeGame.EnvCharacters.Contains(environmentTarget), "Enraged T-Rex is incorrectly still a member of the EnvironmentTargetList");
				Assert.IsTrue(!activeGame.NonHeroTargets.Contains(environmentTarget), "Enraged T-Rex is incorrectly still a member of the NonHeroTargetsList");
				Assert.IsTrue(!activeGame.AllTargets.ContainsKey(environmentTarget.UniqueId), "Enraged T-Rex is incorrectly still a member of the dictionary AllTargets");

			}
			catch (Exception e)
			{
				Assert.Fail("Test failed: " + e);
			}
		}

		[TestMethod]
		public void HeroPlayerGetsDestroyed()
		{
			Setup.SetupTestInfrastructure();
			ActiveGame activeGame = GameContainer.ActiveGame;
			try
			{
				CharacterAccount heroTarget = activeGame.AllTargets[43];
				GameContainer.DealDamage(activeGame.AllTargets[55], heroTarget, 33, DamageType.Fire);
				Assert.IsTrue(!activeGame.HeroTargets.Contains(heroTarget), "Legacy is incorrectly still a member of the HeroTargetsList");
				Assert.IsTrue(activeGame.HeroPlayers.Contains(heroTarget), "Legacy is incorrectly not a member of the HeroPlayersList");
				Assert.IsTrue(!activeGame.AllTargets.ContainsKey(heroTarget.UniqueId), "Legacy is incorrectly still a member of the dictionary AllTargets");
				Assert.IsTrue(((HeroPlayer)heroTarget).Incapped, "Legacy was not marked as incapped");
			}
			catch (Exception e)
			{
				Assert.Fail("Test failed: " + e);
			}
		}

		[TestMethod]
		public void HeroTargetGetsDestroyed()
		{
			Setup.SetupTestInfrastructure();
			ActiveGame activeGame = GameContainer.ActiveGame;
			try
			{
				CharacterAccount heroTarget = activeGame.AllTargets[88];
				GameContainer.DealDamage(activeGame.AllTargets[55], heroTarget, 4, DamageType.Fire);
				Assert.IsTrue(!activeGame.HeroTargets.Contains(heroTarget), "Raptor Bot is incorrectly still a member of the HeroTargetsList");
				Assert.IsTrue(!activeGame.AllTargets.ContainsKey(heroTarget.UniqueId), "Raptor Bot is incorrectly still a member of the dictionary AllTargets");

			}
			catch (Exception e)
			{
				Assert.Fail("Test failed: " + e);
			}
		}
	}
}
