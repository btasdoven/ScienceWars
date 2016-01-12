using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Science_Wars_Server.Minions
{
    public abstract class BiologyMinion : Minion
    {
        protected BiologyMinion(Game game, Player ownerPlayer) : base(game, ownerPlayer)
        {
        }
    }
}
