using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Science_Wars_Server.GameUtilities;

namespace Science_Wars_Server.Minions.Physics
{
    class PhysicsStudentMinion : PhysicsMinion
    {
       private static int cost = 500;
       private static int upgradeCost = 0;
        private static int income = 80;
        private static int killGold = 125;
        private static int healthCost = 1;

        public PhysicsStudentMinion(Game game, Player ownerPlayer)
            : base(game, ownerPlayer)
        {
            // butun initializationlari burada yap. yok efendim can setlemek, yok efendim movementspeed bilmemne.
            stats.healthTotal = stats.health = 100;
            stats.baseMovementSpeed = 0.7f;
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
