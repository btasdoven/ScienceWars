using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Science_Wars_Server.Effects.MinionEffects
{
    class QuantumSoldierSpeedEffect : MinionEffect
    {
        public override bool isStackable()
        {
            return false;
        }

        public QuantumSoldierSpeedEffect()
        {
            remainingTime = 2.0f;
        }

        public override void step(Minions.Minion minion)
        {
            minion.stats.movementSpeedMult *= 2;
        }
    }
}
