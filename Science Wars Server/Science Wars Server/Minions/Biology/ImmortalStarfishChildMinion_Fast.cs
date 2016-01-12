using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Science_Wars_Server.Minions.Biology
{
    class ImmortalStarfishChildMinion_Fast : ImmortalStarfishChildMinion_Durable
    {

        public ImmortalStarfishChildMinion_Fast(Game game, Player ownerPlayer)
            : base(game, ownerPlayer)
        {
            stats.baseMovementSpeed = 1.4f;
        }

        public override int getUpgradeCost()
        {
            return getCost() * 2;
        }

    }
}
