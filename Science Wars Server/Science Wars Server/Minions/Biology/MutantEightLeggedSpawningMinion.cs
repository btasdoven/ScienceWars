using System;
using System.Collections.Generic;
using Science_Wars_Server.Effects.MinionEffects;
using Science_Wars_Server.GameUtilities;

namespace Science_Wars_Server.Minions.Biology
{
    public class MutantEightLeggedSpawningMinion : BiologyMinion
    {
        private static int cost = 0;
        private static int upgradeCost = 0;
        private static int income = 0;
        private static int killGold = 10;
        private static int healthCost = 0;

        public MutantEightLeggedSpawningMinion(Game game, Player ownerPlayer)
            : base(game, ownerPlayer)
        {
            // butun initializationlari burada yap. yok efendim can setlemek, yok efendim movementspeed bilmemne.
            stats.healthTotal = stats.health = 220;
            stats.baseMovementSpeed = 0.9f;
            stats.setBaseResistances(new List<DamageResistance>() { new DamageResistance(DamageType.FIRE, 1f), new DamageResistance(DamageType.PHYSICAL, 1f), new DamageResistance(DamageType.POISON, 1f) });
        }

        public override int getIncome()
        {
            return income;
        }

        public override int getKillGold()
        {
            return killGold;
        }

        public override int getHealthCost()
        {
            return healthCost;
        }

        public override int getCost()
        {
            return cost;
        }

        public override int getUpgradeCost()
        {
            return upgradeCost;
        }       

    }
}
