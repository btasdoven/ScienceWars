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
    class BallistaTower_fireBolt : BallistaTower
    {
        protected override Missile createMissile(Minions.Minion m)
        {
            return new Ballista_fireBoltMissile(this, m);
        }

        public BallistaTower_fireBolt(Board board, int indexOnBoard)
            : base(board, indexOnBoard)
        {
        }
    }
}
