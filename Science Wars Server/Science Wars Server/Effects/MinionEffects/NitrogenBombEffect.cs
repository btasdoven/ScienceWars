using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Science_Wars_Server.Effects.MinionEffects
{
    class NitrogenBombEffect : MinionEffect
    {
        public NitrogenBombEffect()
        {
            remainingTime = 2;
        }

        public override void step(Minions.Minion minion)
        {
            for (int i = 0; i < minion.stats.resistancesDivider.Count; i++)
                minion.stats.resistancesDivider[i] *= 0.5f;

            minion.stats.stunned = true;                          //stun.
        }

        public override bool isStackable()
        {
            return false;
        }
    }
}