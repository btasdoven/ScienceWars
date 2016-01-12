using Science_Wars_Server.Boards;
using Science_Wars_Server.Missiles.Physics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Science_Wars_Server.Towers.Biology
{
    class OneToAllTower_toxic : OneToAllTower
    {
        protected override Missiles.Missile createMissile(Minions.Minion m)
        {
            return new OneToAll_toxicMissile(this, m);
        }

        public OneToAllTower_toxic(Board board, int indexOnBoard)
            : base(board, indexOnBoard)
        {
        }
    }
}
