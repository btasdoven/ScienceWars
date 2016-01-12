using Science_Wars_Server.Boards;
using Science_Wars_Server.Missiles;
using Science_Wars_Server.Missiles.Physics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Science_Wars_Server.Towers.Physics
{
    class BallistaTower_lavaBolt : BallistaTower_fireBolt
    {
        protected override Missile createMissile(Minions.Minion m)
        {
            return new Ballista_lavaBoltMissile(this, m);
        }

        public BallistaTower_lavaBolt(Board board, int indexOnBoard)
            : base(board, indexOnBoard)
        {
        }
    }
}
