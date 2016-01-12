using Assets.Scripts.Engine.Helpers;
using Assets.Scripts.Engine.Minions;
using Assets.Scripts.Engine.Towers;
using UnityEngine;

namespace Assets.Scripts.Engine.Missiles.Chemistry
{
	class NitrogenBombMissile : Missile
	{
		public Vector3 targetPosition = new Vector3(0, 0, 0);
		public Vector3 speedDirection = new Vector3(0, 0, 0);
		float movementSpeed = 5.0f;         // total speed of the missile
		float strikeRange = 0.4f;             // strike range of the missile
		float lastDistanceToTarget;
		
		float gravity; 
		
		public NitrogenBombMissile(int instanceId, Tower ownerTower, Minion targetMinion) : base(instanceId,ownerTower, targetMinion)
		{
			//position = ownerTower.getWorldPosition();
			targetPosition = targetMinion.getWorldPosition();
			lastDistanceToTarget = (targetPosition - position).magnitude;
			
			calcSpeedDirection();
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
			
			float distanceToWalk = speedDirection.magnitude * Chronos.deltaTime;
			
			float currentDistance = (targetPosition - position).magnitude;
			
			if (currentDistance <= distanceToWalk || lastDistanceToTarget < currentDistance)
			{
				position = targetPosition;
				return true;
			}
			lastDistanceToTarget = currentDistance;
			
			position += speedDirection * Chronos.deltaTime;
			speedDirection.y -= gravity * Chronos.deltaTime;
			return false;
		}
		
		private void calcSpeedDirection()
		{
			var distV = (targetPosition - position);
			distV.y = 0;
			var dist = distV.magnitude;
			var alpha = Mathf.PI/4;
			
			var heightDiff = position.y - targetPosition.y;
			var t1 = heightDiff / movementSpeed * Mathf.Cos (alpha);
			var distExtra = Mathf.Sin (alpha) * movementSpeed * t1;
			
			gravity = Mathf.Sin(2 * alpha) * movementSpeed * movementSpeed / (dist - distExtra);
			
			speedDirection = (targetPosition - position).normalized;
			speedDirection.y = 0;
			speedDirection *= Mathf.Cos(alpha) * movementSpeed;
			speedDirection.y = Mathf.Sin(alpha) * movementSpeed;
		}
	}
}



