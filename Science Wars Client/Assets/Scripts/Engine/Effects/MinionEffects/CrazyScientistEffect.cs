using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.Scripts.Engine.GameUtilities;

namespace Assets.Scripts.Engine.Effects.MinionEffects
{
	public class CrazyScientistEffect : MinionEffect
	{
		public CrazyScientistEffect()
		{
			remainingTime = 5;
		}

		public override void step(Minions.Minion minion)
		{
			minion.stats.healthRegenMult *= 1.2f;                //health regeni %20 artırır.
			minion.stats.movementSpeedMult *= 1.3f;              //movement speedi %30'una artırır.
		}
	}
}

