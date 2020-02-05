//----------------------------------------------------
// Copyright 2019 Epic Systems Corporation
//----------------------------------------------------

using System.Collections.Generic;
using static SentinelsAutoTrackerEngine.CustomDataTypes;

namespace SentinelsAutoTrackerEngine
{
	public class HeroPlayer : HeroTarget
	{
		public List<CharacterAccount> HeroPlayerList { get; private set; }

		public HeroPlayer (string name, int health, DamageType damageType) : base(name, health, damageType)
		{
			
		}

		public void AddSelfToParentList(Dictionary<int, CharacterAccount> allTargets, List<CharacterAccount> heroTargetsList, List<CharacterAccount> heroPlayerList)
		{
			base.AddSelfToParentList(allTargets, heroTargetsList);
			HeroPlayerList = heroPlayerList;
			HeroPlayerList.Add(this);
		}

		public override void Destroyed()
		{
			base.Destroyed();
			Incapped = true;
		}
	}
}
