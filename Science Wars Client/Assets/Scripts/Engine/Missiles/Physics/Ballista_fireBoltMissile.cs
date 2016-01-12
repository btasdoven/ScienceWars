using Assets.Scripts.Engine.Helpers;
using Assets.Scripts.Engine.Minions;
using Assets.Scripts.Engine.Towers;
using UnityEngine;

namespace Assets.Scripts.Engine.Missiles.Physics
{
	class Ballista_fireBoltMissile : Missile
	{
		public Ballista_fireBoltMissile(int instanceId, Tower ownerTower, Minion targetMinion) : base(instanceId,ownerTower, targetMinion)
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
			
			float movementSpeed = 3.0f; // TODO statstan al
			
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
