using Assets.Scripts.Engine.Towers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts.Engine.Effects.TowerEffects
{
	public class RetentiveTankTowerEffect : ITowerEffect
	{
		public RetentiveTankTowerEffect()
		{
			remainingTime = 5;
		}
		
		public override void step(Tower tower)
		{
			tower.stats.stunned = true;
		}
	}
}

