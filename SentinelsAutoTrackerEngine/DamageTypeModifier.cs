//----------------------------------------------------
// Copyright 2019 Epic Systems Corporation
//----------------------------------------------------

using static SentinelsAutoTrackerEngine.CustomDataTypes;

namespace SentinelsAutoTrackerEngine
{
	public class DamageTypeModifier : Modifier
	{
		public DamageType DamageType { get; private set; }

		public DamageTypeModifier(string name, string description, ModifierTargets target, DamageType damageType) : base(name, description, target)
		{
			this.DamageType = damageType;
		}
	}
}
