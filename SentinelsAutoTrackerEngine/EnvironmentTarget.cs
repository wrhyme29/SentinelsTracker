//----------------------------------------------------
// Copyright 2019 Epic Systems Corporation
//----------------------------------------------------

using System.Collections.Generic;
using static SentinelsAutoTrackerEngine.CustomDataTypes;

namespace SentinelsAutoTrackerEngine
{
	public class EnvironmentTarget : NonHeroTarget
	{
		public List<CharacterAccount> EnvironmentTargetList { get; private set; }

		public EnvironmentTarget(string name, int health, DamageType damageType) : base(name, health, damageType)
		{
			GameContainer.ActiveGame.AssignGlobalModifiers(this, GameContainer.ActiveGame.GlobalEnvironmentModifiers);
		}

		public void AddSelfToParentList(Dictionary<int, CharacterAccount> allTargets, List<CharacterAccount> nonHeroTargetList, List<CharacterAccount> environmentTargetList)
		{
			base.AddSelfToParentList(allTargets, nonHeroTargetList);
			EnvironmentTargetList = environmentTargetList;
			EnvironmentTargetList.Add(this);
		}

		public override void Destroyed()
		{
			base.Destroyed();
			EnvironmentTargetList.Remove(this);
		}
	}
}
