using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Science_Wars_Server.Boards;
using Science_Wars_Server.Strategies.TargetStrategies;

namespace Science_Wars_Server.Towers
{
    public abstract class ChemistryTower : Tower
    {
        protected ChemistryTower(Board board, int indexOnBoard)
            : base(board, indexOnBoard)
        {
            // base constructor gerekli setlemeleri yapiyor. bir sey yapmaya gerek yok
        }
    }
}
