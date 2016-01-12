using System;
using System.Collections.Generic;
using Science_Wars_Server.Effects.MinionEffects;
using Science_Wars_Server.GameUtilities;

namespace Science_Wars_Server.Minions.Biology
{
    public class BioLabStudentMinion : BiologyMinion
    {
        private static int cost = 850;
        private static int upgradeCost = 0;
        private static int income = 95;
        private static int killGold = 212;
        private static int healthCost = 1;

        public BioLabStudentMinion(Game game, Player ownerPlayer)
            : base(game, ownerPlayer)
        {
            // butun initializationlari burada yap. yok efendim can setlemek, yok efendim movementspeed bilmemne.
            stats.healthTotal = stats.health = 90;
            stats.baseMovementSpeed = 0.75f;
            stats.setBaseResistances(new List<DamageResistance>() { new DamageResistance(DamageType.FIRE, .9f), new DamageResistance(DamageType.POISON, .9f)});
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
