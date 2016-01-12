using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Science_Wars_Server.Minions.Biology
{
    class BiologyStudentMinion_Faster : BiologyStudentMinion
    {
        public BiologyStudentMinion_Faster(Game game, Player ownerPlayer)
            : base(game, ownerPlayer)
        {
            stats.baseMovementSpeed = 0.7f; 
        }

        public override int getUpgradeCost()
        {
            return getCost() * 2;
        }
    }
}
