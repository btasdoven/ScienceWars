using Science_Wars_Server.Boards;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Science_Wars_Server.Towers.Biology
{
    class DroseraTower_starving : DroseraTower_hungry
    {
        private const float maximumLife = 750;
        protected override float MAXIMUMLIFE { get { return maximumLife; } }

        public DroseraTower_starving(Board board, int indexOnBoard)
            : base(board, indexOnBoard)
        {
        }
    }
}
