using Science_Wars_Server.Boards;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Science_Wars_Server.Towers.Biology
{
    class DroseraTower_hungry : DroseraTower
    {
        private const float maximumLife = 600;
        protected override float MAXIMUMLIFE { get { return maximumLife; } }

        public DroseraTower_hungry(Board board, int indexOnBoard)
            : base(board, indexOnBoard)
        {
        }
    }
}
