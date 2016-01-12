using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Science_Wars_Server.Helpers;
using Science_Wars_Server.GameUtilities;

namespace Science_Wars_Server.Effects.MinionEffects
{
    class NailTrapSlowEffect : MinionEffect
    {
        // %25 slow icin bu sayıyı 0.75 yapmalisin boylece , hızı o kadar olacak.
        public float slowAmount;

        public NailTrapSlowEffect(float slowAmount)
        {
            // cok kucuk bir sayı yapıyorum amacı sadece bir step boyunca bu effect etkili olsun diye cunku bu effect alan icerisinde oldugumuz surece aktif olmalı.
            remainingTime = 1.0f;
            this.slowAmount = slowAmount;
        }

        public override void step(Minions.Minion minion)
        {
            minion.stats.movementSpeedMult *= slowAmount;
        }

        public override bool isStackable()
        {
            return false;
        }

    }
}
