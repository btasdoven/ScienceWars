using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Science_Wars_Server.Effects.MinionEffects
{
    class ContagiousEffect_effective : ContagiousEffect
    {
        public ContagiousEffect_effective(Player ownerPlayer)
            :base(ownerPlayer)
        {
            remainingTime = 4.0f;
            this.ownerPlayer = ownerPlayer;
        }
    }
}
