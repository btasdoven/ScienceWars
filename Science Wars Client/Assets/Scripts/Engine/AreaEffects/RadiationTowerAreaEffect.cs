using Assets.Scripts.Engine.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts.Engine.AreaEffects
{
	class RadiationTowerAreaEffect : AreaEffect
	{
		private static float DURATION_DEFAUT = 0.5f;
		private static float RADIUS_DEFAULT = 3.0f;
        private static float DEFAULT_DAMAGE = 30.0f;
		
		private float remainingDuration;
		
		public RadiationTowerAreaEffect(int instanceId, Player ownerPlayer, Vector3 worldPosition)
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
                    GameUtilities.Damage damageFire = new GameUtilities.Damage((DEFAULT_DAMAGE / dist) * Chronos.deltaTime, GameUtilities.DamageType.FIRE);
                    GameUtilities.Damage damagePoison = new GameUtilities.Damage((DEFAULT_DAMAGE / dist) * Chronos.deltaTime, GameUtilities.DamageType.POISON);
					m.Value.dealDamage(damageFire);
					m.Value.dealDamage(damagePoison);
				}
			}
			
			remainingDuration -= Chronos.deltaTime;
			if (remainingDuration <= 0)
				destroyable = true;
		}
	}
}
