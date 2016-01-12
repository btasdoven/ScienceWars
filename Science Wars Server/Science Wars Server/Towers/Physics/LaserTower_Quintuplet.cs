using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Science_Wars_Server.Boards;
using Science_Wars_Server.Minions;
using Science_Wars_Server.Missiles.Physics;
using Science_Wars_Server.Strategies.TargetStrategies;

namespace Science_Wars_Server.Towers.Physics
{
    class LaserTower_Quintuplet : LaserTower_Quadruplet
    {
        private const int _simultaneousTargetLimit = 5; // ayni anda en fazla kac miniona saldirabilir.        
        protected override int SIMULTANEOUS_TARGET_LIMIT { get { return _simultaneousTargetLimit; } }


        public LaserTower_Quintuplet(Board board, int indexOnBoard)
            : base(board, indexOnBoard)
        {
        }
            
    }
}
