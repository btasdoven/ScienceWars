using Science_Wars_Server.Boards;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Science_Wars_Server.Towers.Biology
{
    class DroseraTower_crazy :DroseraTower
    {
        private const float healthPerSecond = 140;
        protected override float HEALTHPERSECOND { get { return healthPerSecond; } }

        public DroseraTower_crazy(Board board, int indexOnBoard)
            : base(board, indexOnBoard)
        {
        }
    }
}
