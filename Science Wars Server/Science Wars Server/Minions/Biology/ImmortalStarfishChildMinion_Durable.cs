using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Science_Wars_Server.Minions.Biology
{
    class ImmortalStarfishChildMinion_Durable : ImmortalStarfishChildMinion
    {

        public ImmortalStarfishChildMinion_Durable(Game game, Player ownerPlayer)
            : base(game, ownerPlayer)
        {
            stats.healthTotal = stats.health = 150;
        }

        public override int getUpgradeCost()
        {
            return 0;
        }
    }
}
