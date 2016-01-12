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
    class ContagiousTower_extra : ContagiousTower
    {
        protected override Missile createMissile(Minions.Minion m)
        {
            return new Contagious_extraMissile(this, m);
        }

        public ContagiousTower_extra(Board board, int indexOnBoard)
            : base(board, indexOnBoard)
        { }
    }
}
