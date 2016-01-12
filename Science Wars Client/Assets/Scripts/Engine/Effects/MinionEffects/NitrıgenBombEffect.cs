using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.Scripts.Engine.GameUtilities;

namespace Assets.Scripts.Engine.Effects.MinionEffects
{
	public class NitrogenBombEffect : MinionEffect
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
	}
}

