using System;
using System.Collections.Generic;
using Science_Wars_Server.Effects.MinionEffects;
using Science_Wars_Server.GameUtilities;

namespace Science_Wars_Server.Minions.Biology
{
    public class ImmortalStarfishChildMinion : BiologyMinion
    {
        private static int cost = 0;
        private static int upgradeCost = 0;
        private static int income = 0;
        private static int killGold = 0;
        private static int healthCost = 1;

        public ImmortalStarfishChildMinion(Game game, Player ownerPlayer)
            : base(game, ownerPlayer)
        {
            // butun initializationlari burada yap. yok efendim can setlemek, yok efendim movementspeed bilmemne.
            stats.healthTotal = stats.health = 130;
            stats.baseMovementSpeed = 1.3f;
            stats.setBaseResistances(new List<DamageResistance>(){});
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
