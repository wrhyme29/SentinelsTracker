//----------------------------------------------------
// Copyright 2019 Epic Systems Corporation
//----------------------------------------------------

using System.Collections.Generic;
using static SentinelsAutoTrackerEngine.CustomDataTypes;

namespace SentinelsAutoTrackerEngine
{
	public class NonHeroTarget : CharacterAccount
	{
		public List<CharacterAccount> NonHeroTargetList { get; private set; }

		public NonHeroTarget(string name, int health, DamageType damageType) : base(name, health, damageType)
		{}

		public void AddSelfToParentList(Dictionary<int, CharacterAccount> allTargets, List<CharacterAccount> nonHeroTargetsList)
		{
			base.AddSelfToParentList(allTargets);
			NonHeroTargetList = nonHeroTargetsList;
			NonHeroTargetList.Add(this);
		}

		public override void Destroyed()
		{
			base.Destroyed();
			NonHeroTargetList.Remove(this);
		}
	}
}
