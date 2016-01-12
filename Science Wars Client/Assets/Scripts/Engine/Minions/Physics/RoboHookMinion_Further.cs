using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts.Engine.Minions.Physics
{
    class RoboHookMinion_Further : RoboHookMinion
    {

        private const float _hook_range_default = 3.3f; // 3.3 birim otesindeki minionlara atlayabilir 

        protected override float HOOK_RANGE_DEFAULT { get { return _hook_range_default; } } 

        public RoboHookMinion_Further()
            : base()
        {

        }

        public override string getName()
        {
            return "Further Robo Hook";
        }

        public override int getUpgradeCost()
        {
            return getCost() * 2;
        }
    }
}
