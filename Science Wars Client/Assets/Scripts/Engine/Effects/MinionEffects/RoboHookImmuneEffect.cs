using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts.Engine.Effects.MinionEffects
{
    class RoboHookImmuneEffect : MinionEffect
    {

        public RoboHookImmuneEffect()
        {
            remainingTime = 3.0f;
        }

        public override void step(Minions.Minion minion)
        {
            minion.stats.invulnerable = true;
        }
    }
}
