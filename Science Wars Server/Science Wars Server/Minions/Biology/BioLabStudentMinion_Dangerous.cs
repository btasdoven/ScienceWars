using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Science_Wars_Server.Minions.Biology
{
    class BioLabStudentMinion_Dangerous : BioLabStudentMinion
    {
        public BioLabStudentMinion_Dangerous(Game game, Player ownerPlayer)
            : base(game, ownerPlayer)
        {
            
        }

        public override int getHealthCost()
        {
            return 2;
        }

        public override int getUpgradeCost()
        {
            return getCost() * 2;
        }
    }
}
