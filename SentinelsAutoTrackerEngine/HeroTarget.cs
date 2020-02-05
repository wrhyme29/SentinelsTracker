//----------------------------------------------------
// Copyright 2019 Epic Systems Corporation
//----------------------------------------------------

using System.Collections.Generic;
using static SentinelsAutoTrackerEngine.AmountModifier;
using static SentinelsAutoTrackerEngine.CustomDataTypes;

namespace SentinelsAutoTrackerEngine
{
	public class HeroTarget : CharacterAccount
	{
		public List<CharacterAccount> HeroTargetList { get; private set; }

		public HeroTarget(string name, int health, DamageType damageType) : base(name, health, damageType)
		{
			GameContainer.ActiveGame.AssignGlobalModifiers(this, GameContainer.ActiveGame.GlobalHeroModifers);
		}

		

		public void AddSelfToParentList(Dictionary<int, CharacterAccount> allTargets, List<CharacterAccount> heroTargetsList)
		{
			base.AddSelfToParentList(allTargets);
			HeroTargetList = heroTargetsList;
			HeroTargetList.Add(this);
		}

		public override void Destroyed()
		{
			base.Destroyed();
			HeroTargetList.Remove(this);
		}
	}
}
