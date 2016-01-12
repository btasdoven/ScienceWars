using System;
using System.Collections.Generic;
using Science_Wars_Server.Effects.MinionEffects;
using Science_Wars_Server.GameUtilities;
using Science_Wars_Server.Helpers;


namespace Science_Wars_Server.Minions.Chemistry
{
    class ChemLabStudentMinion : ChemistryMinion
    {
        private static int cost = 800;
        private static int upgradeCost = 0;
        private static int income = 93;
        private static int killGold = 200;
        private static int healthCost = 1;


        public ChemLabStudentMinion(Game game, Player ownerPlayer)
            : base(game, ownerPlayer)
        {
            // butun initializationlari burada yap. yok efendim can setlemek, yok efendim movementspeed bilmemne.
            stats.health = stats.healthTotal = 160;
            stats.baseMovementSpeed = 0.8f;
            stats.setBaseResistances(new List<DamageResistance>() { new DamageResistance(DamageType.FIRE, .8f) });
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
