using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Science_Wars_Server.Effects.MinionEffects
{
    class ProtectorEffect : MinionEffect
    {

        public ProtectorEffect()
        {
            remainingTime = 3.0f;
        }

        public override void step(Minions.Minion minion)
        {
            for (int i = 0; i < minion.stats.resistancesMult.Count; ++i )
            {
                minion.stats.resistancesMult[i] *= 1.3f;
            }
        }

        public override bool isStackable()
        {
            return false;
        }
    }
}
