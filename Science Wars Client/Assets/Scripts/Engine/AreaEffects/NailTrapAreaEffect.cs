using Assets.Scripts.Engine.Helpers;
using Assets.Scripts.Engine.Effects.MinionEffects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts.Engine.AreaEffects
{
	class NailTrapAreaEffect : AreaEffect
	{
		private static float DURATION_DEFAUT = 2.5f;
		private static float RADIUS_DEFAULT = 0.5f;
		
		private float remainingDuration;

		private float dmgPerSecond = 30.0f;
		private float slowAmount = 0.75f;
		
		public NailTrapAreaEffect(int instanceId, Player ownerPlayer, Vector3 worldPosition,float slowAmount,float dmgPerSecond)
			: base(instanceId, ownerPlayer, worldPosition)
		{
			remainingDuration = DURATION_DEFAUT;
			this.slowAmount = slowAmount;
			this.dmgPerSecond = dmgPerSecond;
		}
		
		public override void step()
		{
			foreach (var m in ownerPlayer.board.minions)
			{
				if ( m.Value.minionState == Assets.Scripts.Engine.Minions.Minion.MinionState.DEAD)
					continue;
				
				// calculate the distance of each minion to this minion
				var dist = (m.Value.getWorldPosition() - worldPosition).magnitude;
				
				// if the minion in the range then deal amage
				if (dist < RADIUS_DEFAULT)
				{
					//GameUtilities.Damage damage = new GameUtilities.Damage(dmgPerSecond * Chronos.deltaTime, GameUtilities.DamageType.PHYSICAL);
					//m.Value.dealDamage(damage);
				}
			}
			
			remainingDuration -= Chronos.deltaTime;
			if (remainingDuration <= 0)
				destroyable = true;
		}
	}
}
