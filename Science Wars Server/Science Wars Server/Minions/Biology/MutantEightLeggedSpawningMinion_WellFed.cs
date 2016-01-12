using System;
using System.Collections.Generic;
using Science_Wars_Server.Effects.MinionEffects;
using Science_Wars_Server.GameUtilities;

namespace Science_Wars_Server.Minions.Biology
{
    public class MutantEightLeggedSpawningMinion_WellFed : MutantEightLeggedSpawningMinion
    {
        public MutantEightLeggedSpawningMinion_WellFed(Game game, Player ownerPlayer)
            : base(game, ownerPlayer)
        {
            stats.setBaseResistances(new List<DamageResistance>() { new DamageResistance(DamageType.FIRE, .9f), new DamageResistance(DamageType.PHYSICAL, .9f), new DamageResistance(DamageType.POISON, .9f) });
            stats.baseMovementSpeed = 1.1f;
        }
    }
}
