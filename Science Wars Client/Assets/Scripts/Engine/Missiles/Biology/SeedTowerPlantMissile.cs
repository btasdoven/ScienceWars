using Assets.Scripts.Engine.Helpers;
using Assets.Scripts.Engine.Minions;
using Assets.Scripts.Engine.Towers;
using UnityEngine;

namespace Assets.Scripts.Engine.Missiles.Biology
{
	class SeedTowerPlantMissile : Missile
	{
        public SeedTowerPlantMissile(int instanceId, Vector3 position, Minion targetMinion)
            : base(instanceId, position, targetMinion)
		{
		}
		
		public override void step()
		{
			if (chase())
			{
				targetMinion = null;
				destroyable = true;
			}
			
		}
		
		public bool chase()
		{
			if (targetMinion == null)
				return false;
			
			float movementSpeed = 5.0f; // TODO statstan al
			
			Vector3 minionPos = targetMinion.getWorldHeadPosition();
			float distanceToWalk = movementSpeed * Chronos.deltaTime;
			
			float currentDistance = (minionPos - position).magnitude;
			
			if (currentDistance <= distanceToWalk)
			{
				position = minionPos;
				return true;
			}
			
			position += (minionPos - position).normalized * distanceToWalk;
			return false;
			
		}
	}
}
