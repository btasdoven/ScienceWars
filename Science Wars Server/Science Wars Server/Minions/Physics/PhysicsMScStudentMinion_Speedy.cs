using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Science_Wars_Server.Minions.Physics
{
    class PhysicsMScStudentMinion_Speedy : PhysicsMScStudentMinion
    {
        public PhysicsMScStudentMinion_Speedy (Game game, Player ownerPlayer)
            : base(game, ownerPlayer)
        {
            stats.baseMovementSpeed = 1.45f;
        }

        public override int getUpgradeCost()
        {
            return getCost() * 2;
        }
    }
}
