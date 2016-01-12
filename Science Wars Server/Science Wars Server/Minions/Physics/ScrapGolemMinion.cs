using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Science_Wars_Server.GameUtilities;

namespace Science_Wars_Server.Minions.Physics
{
    class ScrapGolemMinion : PhysicsMinion
    {
       private static int cost = 0;
       private static int upgradeCost = 0;
        private static int income = 0;
        private static int killGold = 250;
        private static int healthCost = 1;

        public ScrapGolemMinion(Game game, Player ownerPlayer)
            : base(game, ownerPlayer)
        {
            // butun initializationlari burada yap. yok efendim can setlemek, yok efendim movementspeed bilmemne.
            stats.healthTotal = stats.health = 2000;
            stats.baseMovementSpeed = 0.45f;
            stats.setBaseResistances(new List<DamageResistance>(){
                new DamageResistance(DamageType.PHYSICAL,0.6f),
                new DamageResistance(DamageType.FIRE,0.6f),
                new DamageResistance(DamageType.POISON,0.6f)});
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
