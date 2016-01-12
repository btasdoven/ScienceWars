using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Science_Wars_Server.Effects.MinionEffects
{
    class ContagiousEffect_extra : ContagiousEffect
    {
        private const float infectionRange = 0.95f;
        protected override float INFECTION_RANGE { get { return infectionRange; } }

        public ContagiousEffect_extra(Player ownerPlayer)
            :base(ownerPlayer)
        {
            remainingTime = 3.0f;
            this.ownerPlayer = ownerPlayer;
        }
    }
}
