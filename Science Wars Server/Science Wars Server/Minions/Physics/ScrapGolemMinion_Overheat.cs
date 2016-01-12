using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Science_Wars_Server.GameUtilities;

namespace Science_Wars_Server.Minions.Physics
{
    class ScrapGolemMinion_Overheat : ScrapGolemMinion
    {
        public ScrapGolemMinion_Overheat(Game game, Player ownerPlayer)
            : base(game, ownerPlayer)
        {
            stats.baseMovementSpeed = 0.6f;
        }
    }
}
