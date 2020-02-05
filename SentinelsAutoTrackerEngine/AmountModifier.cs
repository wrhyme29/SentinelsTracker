//----------------------------------------------------
// Copyright 2019 Epic Systems Corporation
//----------------------------------------------------


namespace SentinelsAutoTrackerEngine
{
	public class AmountModifier : Modifier
	{
		public int Amount { get; private set; }
		public bool OneTime { get; private set; }
		public AmountModifierType ModifierType { get; private set; }

		public AmountModifier(string name, string description, ModifierTargets target, AmountModifierType modifierType, int amount, bool oneTime) : base(name, description, target)
		{
			Amount = amount;
			OneTime = oneTime;
			ModifierType = modifierType;
		}

		public enum AmountModifierType
		{
			DamageGiven,
			DamageTaken,
			Health
		}
	}
}
