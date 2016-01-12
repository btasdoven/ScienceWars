using Science_Wars_Server.Boards;
using Science_Wars_Server.Missiles;
using Science_Wars_Server.Missiles.Biology;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Science_Wars_Server.Towers.Biology
{
    class ContagiousTower_effective : ContagiousTower
    {
        protected override Missile createMissile(Minions.Minion m)
        {
            return new Contagious_effectiveMissile(this, m);
        }

        public ContagiousTower_effective(Board board, int indexOnBoard)
            : base(board, indexOnBoard)
        { }
    }
}
