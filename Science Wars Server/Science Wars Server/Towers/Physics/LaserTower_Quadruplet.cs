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
    class LaserTower_Quadruplet : LaserTower_Triplet
    {
        private const int _simultaneousTargetLimit = 4; // ayni anda en fazla kac miniona saldirabilir.        
        protected override int SIMULTANEOUS_TARGET_LIMIT { get { return _simultaneousTargetLimit; } }


        public LaserTower_Quadruplet(Board board, int indexOnBoard)
            : base(board, indexOnBoard)
        {
        }
            
    }
}
