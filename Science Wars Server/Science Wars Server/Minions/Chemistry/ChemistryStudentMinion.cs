using System;
using System.Collections.Generic;
using Science_Wars_Server.Effects.MinionEffects;
using Science_Wars_Server.GameUtilities;
using Science_Wars_Server.Helpers;


namespace Science_Wars_Server.Minions.Chemistry
{
    class ChemistryStudentMinion : ChemistryMinion
    {
        private static int cost = 500;
        private static int upgradeCost = 0;
        private static int income = 80;
        private static int killGold = 125;
        private static int healthCost = 1;


        public ChemistryStudentMinion(Game game, Player ownerPlayer)
            : base(game, ownerPlayer)
        {
            // butun initializationlari burada yap. yok efendim can setlemek, yok efendim movementspeed bilmemne.
            stats.health = stats.healthTotal = 120;
            stats.baseMovementSpeed = 0.65f;
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
