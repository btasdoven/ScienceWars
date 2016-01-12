using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.Scripts.Engine.GameUtilities;
using Assets.Scripts.Engine.Helpers;

namespace Assets.Scripts.Engine.Effects.MinionEffects
{
	public class NailTrapSlowEffect : MinionEffect
	{

		// %25 slow icin bu sayıyı 0.75 yapmalisin boylece , hızı o kadar olacak.
		public float slowAmount;

		public NailTrapSlowEffect(float slowAmount)
		{
			remainingTime = 1.0f;
			this.slowAmount = slowAmount;
		}
		
		public override void step(Minions.Minion minion)
		{
			minion.stats.movementSpeedMult *= slowAmount;              //movement speedi %30'una artırır.
		}
	}
}

