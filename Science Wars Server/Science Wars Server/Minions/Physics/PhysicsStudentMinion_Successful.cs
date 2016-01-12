using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Science_Wars_Server.GameUtilities;

namespace Science_Wars_Server.Minions.Physics
{
    class PhysicsStudentMinion_Successful : PhysicsStudentMinion
    {
        public PhysicsStudentMinion_Successful(Game game, Player ownerPlayer)
            : base(game, ownerPlayer)
        {
            stats.healthTotal = stats.health = 120;
        }

        public override int getUpgradeCost()
        {
            return getCost() * 2;
        }
     
    }
}
