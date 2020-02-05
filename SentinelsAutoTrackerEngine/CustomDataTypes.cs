//----------------------------------------------------
// Copyright 2019 Epic Systems Corporation
//----------------------------------------------------


using System;
using System.Collections.Generic;

namespace SentinelsAutoTrackerEngine
{
    public class CustomDataTypes
    {

        public enum DamageType
        {
            Fire,
            Melee,
            Radiant,
            Toxic,
            Projectile,
            Infernal,
            Cold,
            Psychic,
            Sonic,
            Lightning,
            Energy,
            None,
			All
        }

        public static DamageType ConvertStringToDamageType(string name)
        {
            switch(name)
            {
                case "fire":
                    return DamageType.Fire;
                case "melee":
                    return DamageType.Melee;
                case "radiant":
                    return DamageType.Radiant;
                case "toxic":
                    return DamageType.Toxic;
                case "projectile":
                    return DamageType.Projectile;
                case "infernal":
                    return DamageType.Infernal;
                case "cold":
                    return DamageType.Cold;
                case "psychic":
                    return DamageType.Psychic;
                case "sonic":
                    return DamageType.Sonic;
                case "lightning":
                    return DamageType.Lightning;
                case "energy":
                    return DamageType.Energy;
                default:
                    return DamageType.None;
            }
        }

        public class Damage
        {
            public int Amount { get; set; }
            public DamageType Type { get; set; }

            public Damage(int amount, DamageType type)
            {
                Amount = amount;
                Type = type;
            }
        }

    }
}
