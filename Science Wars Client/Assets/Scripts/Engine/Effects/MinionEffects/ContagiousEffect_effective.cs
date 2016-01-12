using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.Scripts.Engine.GameUtilities;
using Assets.Scripts.Engine.Helpers;
using UnityEngine;

namespace Assets.Scripts.Engine.Effects.MinionEffects
{
	public class ContagiousEffect_effective : MinionEffect
	{
		public static float DAMAGE_OVER_1_SEC = 50.0f;
		public static DamageType damageType = DamageType.FIRE;
		
		public ContagiousEffect_effective()
		{
			remainingTime = 4.0f;
		}
		
		public override void step(Minions.Minion minion)
		{
			minion.dealDamage( new Damage( DAMAGE_OVER_1_SEC * Chronos.deltaTime, damageType));			
		}
	}
}

