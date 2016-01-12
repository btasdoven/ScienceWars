using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Science_Wars_Server.Effects.MinionEffects
{
    class CrazyScientistEffect : MinionEffect
    {
        public CrazyScientistEffect()   // owner player set'lemeye gerek yok. cunku hasar vermiyor bu etki.
        {
            remainingTime = 5;
        }

        public override void step(Minions.Minion minion)
        {
            minion.stats.healthRegenMult *= 1.2f;                //health regeni %20 artırır.
            minion.stats.movementSpeedMult *= 1.3f;              //movement speedi %30'una artırır.
        }

        public override bool isStackable()
        {
            return false;
        }
    }
}
