using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Science_Wars_Server.Minions.Physics
{
    class RoboHookMinion_Further : RoboHookMinion
    {

        private const float _hook_range_default = 3.3f; // 3.3 birim otesindeki minionlara atlayabilir 

        protected override float HOOK_RANGE_DEFAULT { get { return _hook_range_default; } } 

        public RoboHookMinion_Further(Game game, Player ownerPlayer)
            : base(game, ownerPlayer)
        {
            
        }

        public override int getUpgradeCost()
        {
            return getCost() * 2;
        }
    }
}
