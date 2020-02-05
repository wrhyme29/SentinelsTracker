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
	public class CheckLastDamageUponCreation
	{
		[TestMethod]
		public void CheckLastDamage()
		{
			Setup.SetupTestInfrastructure();
			try
			{
				Assert.IsTrue(DamageType.Radiant == GameContainer.ActiveGame.AllTargets[27].DefaultDamageType, $"Damage does not match. Expected {DamageType.Radiant}, Actual {GameContainer.ActiveGame.AllTargets[27].LastDamageType}");

			}
			catch (Exception e)
			{
				Assert.Fail("Test failed: " + e);
			}
		}
	}
}
