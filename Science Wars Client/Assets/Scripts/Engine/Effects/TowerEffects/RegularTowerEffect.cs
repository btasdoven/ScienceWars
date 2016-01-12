using Assets.Scripts.Engine.Towers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts.Engine.Effects.TowerEffects
{
	public class RegularTowerEffect : ITowerEffect
	{
		public RegularTowerEffect()
		{
			remainingTime = 3;
		}

		public override void step(Tower tower)
		{
			tower.stats.attackSpeedMult += 0.2f;                                  //attack speedi %20 arttirir.
			tower.stats.rangeDivider = Math.Min(tower.stats.rangeDivider, 0.3f);         //range'i %30'una dusur.

			tower.stats.attackTimeReduction += 0.3f;                              // attack speedi 0.3 kadar arttir.
		}
	}
}

