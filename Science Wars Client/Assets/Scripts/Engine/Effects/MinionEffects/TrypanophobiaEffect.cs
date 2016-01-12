using Assets.Scripts.Engine.Minions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts.Engine.Effects.MinionEffects
{
    class TrypanophobiaEffect : MinionEffect
	{
        public TrypanophobiaEffect(float runBackTime)
		{
			remainingTime = runBackTime;
		}
		
		public override void step(Minion minion)
		{
            minion.stats.movementDirection = -1.0f;
		}
    }
}
