using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Science_Wars_Server.Effects.MinionEffects
{
    class RoboHookImmuneEffect : MinionEffect
    {

        public RoboHookImmuneEffect()
        {
            remainingTime = 3.0f;
        }

        public override bool isStackable()
        {
            return false;
        }

        public override void step(Minions.Minion minion)
        {
            minion.stats.invulnerable = true;
        }
    }
}
