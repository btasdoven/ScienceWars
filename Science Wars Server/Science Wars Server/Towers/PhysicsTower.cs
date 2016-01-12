using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Science_Wars_Server.Boards;

namespace Science_Wars_Server.Towers
{
    public abstract class PhysicsTower : Tower
    {
        protected PhysicsTower(Board board, int indexOnBoard) : base(board, indexOnBoard)
        {
        }
    }
}
