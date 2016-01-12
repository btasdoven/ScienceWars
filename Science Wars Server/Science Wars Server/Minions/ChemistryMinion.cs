using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Science_Wars_Server.Minions
{
    public abstract class ChemistryMinion : Minion
    {
        protected ChemistryMinion(Game game, Player ownerPlayer) : base(game, ownerPlayer)
        {
        }
    }
}
