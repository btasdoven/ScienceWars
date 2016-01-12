using Assets.Scripts.Engine.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts.Engine.AreaEffects
{
	class PetrolBombAreaEffect : AreaEffect
	{
		private static float DURATION_DEFAUT = 7f;
		private static float RADIUS_DEFAULT = 1.5f;
		
		private float remainingDuration;
		
		public PetrolBombAreaEffect(int instanceId, Player ownerPlayer, Vector3 worldPosition)
			: base(instanceId, ownerPlayer, worldPosition)
		{
			remainingDuration = DURATION_DEFAUT;
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
					// server should deal damage.
					GameUtilities.Damage damage = new GameUtilities.Damage(110.0f * Chronos.deltaTime,GameUtilities.DamageType.FIRE);
					m.Value.dealDamage(damage);
				}
			}
			
			remainingDuration -= Chronos.deltaTime;
			if (remainingDuration <= 0)
				destroyable = true;
		}
	}
}
