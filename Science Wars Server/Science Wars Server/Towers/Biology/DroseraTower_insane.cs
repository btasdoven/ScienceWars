using Science_Wars_Server.Boards;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Science_Wars_Server.Towers.Biology
{
    class DroseraTower_insane : DroseraTower_crazy
    {
        private const float healthPerSecond = 170;
        protected override float HEALTHPERSECOND { get { return healthPerSecond; } }

        public DroseraTower_insane(Board board, int indexOnBoard)
            : base(board, indexOnBoard)
        {
        }
    }
}
