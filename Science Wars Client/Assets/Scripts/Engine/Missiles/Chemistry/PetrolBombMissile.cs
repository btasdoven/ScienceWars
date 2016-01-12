using Assets.Scripts.Engine.Helpers;
using Assets.Scripts.Engine.Minions;
using Assets.Scripts.Engine.Towers;
using Assets.Scripts.Engine.Effects.MinionEffects;
using UnityEngine;

namespace Assets.Scripts.Engine.Missiles.Biology
{
	class PetrolBombMissile : Missile
	{

		Vector3 targetPosition = new Vector3(0, 0, 0);

		public PetrolBombMissile(int instanceId, Tower ownerTower, Minion targetMinion) : base(instanceId,ownerTower, targetMinion)
		{
			targetPosition = targetMinion.getWorldPosition();
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
			
			Vector3 minionPos = targetPosition;
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
