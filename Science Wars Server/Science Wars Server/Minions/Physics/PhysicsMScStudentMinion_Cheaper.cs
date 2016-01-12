using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Science_Wars_Server.Minions.Physics
{
    class PhysicsMScStudentMinion_Cheaper : PhysicsMScStudentMinion
    {
        public PhysicsMScStudentMinion_Cheaper (Game game, Player ownerPlayer)
            : base(game, ownerPlayer)
        {

        }

        public override int getCost()
        {
            return 700;
        }

        public override int getUpgradeCost()
        {
            return getCost() * 2;
        }
    }
}
