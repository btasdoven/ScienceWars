using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Science_Wars_Server.Effects.MinionEffects
{
    class TrypanophobiaEffect : MinionEffect
    {
        public TrypanophobiaEffect(float runBackTime)
        {
            remainingTime = runBackTime;
        }

        public override void step(Minions.Minion minion)
        {
            minion.stats.movementDirection = -1.0f;
        }

        public override bool isStackable()
        {
            return false;
        }
    }
}
