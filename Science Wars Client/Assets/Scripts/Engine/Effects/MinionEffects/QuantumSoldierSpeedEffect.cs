using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts.Engine.Effects.MinionEffects
{
    class QuantumSoldierSpeedEffect : MinionEffect
    {

        public QuantumSoldierSpeedEffect()
		{
			remainingTime = 2;
		}

        public override void step(Minions.Minion minion)
        {
            minion.stats.movementSpeedMult *= 2;
        }
    }
}
