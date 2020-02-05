//----------------------------------------------------
// Copyright 2019 Epic Systems Corporation
//----------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static SentinelsAutoTrackerEngine.CustomDataTypes;

namespace SentinelsAutoTrackerEngine
{
	public class ImmunityModifier : Modifier
	{
		public DamageType DamageTypeImmunity { get; private set; }

		public ImmunityModifier(string name, string description, ModifierTargets target, DamageType damageType) : base(name, description, target)
		{
			DamageTypeImmunity = damageType;
		}
	}
}
