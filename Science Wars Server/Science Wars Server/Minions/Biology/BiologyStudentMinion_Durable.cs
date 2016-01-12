using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Science_Wars_Server.Minions.Biology
{
    class BiologyStudentMinion_Durable : BiologyStudentMinion
    {
        public BiologyStudentMinion_Durable(Game game, Player ownerPlayer)
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
