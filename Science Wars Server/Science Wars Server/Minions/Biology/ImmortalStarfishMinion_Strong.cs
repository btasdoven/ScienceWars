using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Science_Wars_Server.GameUtilities;
using Science_Wars_Server.Helpers;

namespace Science_Wars_Server.Minions.Biology
{
    class ImmortalStarfishMinion_Strong : ImmortalStarfishMinion_Durable
    {
        public ImmortalStarfishMinion_Strong(Game game, Player ownerPlayer)
            : base(game, ownerPlayer)
        {
            stats.healthTotal = stats.health = 700;
        }

        public override int getUpgradeCost()
        {
            return 0;
        }
    }
}
