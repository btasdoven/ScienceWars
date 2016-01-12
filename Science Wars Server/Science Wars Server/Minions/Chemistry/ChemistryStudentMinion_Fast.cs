using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Science_Wars_Server.Minions.Chemistry
{
    class ChemistryStudentMinion_Fast : ChemistryStudentMinion
    {

        public ChemistryStudentMinion_Fast(Game game, Player ownerPlayer)
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
