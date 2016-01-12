using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Science_Wars_Server.Minions
{
    public abstract class PhysicsMinion : Minion
    {
        protected PhysicsMinion(Game game, Player ownerPlayer) : base(game, ownerPlayer)
        {
        }
    }
}
