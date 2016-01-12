using Assets.Scripts.Engine.Helpers;
using Assets.Scripts.Engine.Minions;
using Assets.Scripts.Engine.Towers;
using Assets.Scripts.Engine.Effects.MinionEffects;
using UnityEngine;

namespace Assets.Scripts.Engine.Missiles.Biology
{
    class AcidMissile : Missile
    {
        public AcidMissile(int instanceId, Tower ownerTower, Minion targetMinion) : base(instanceId,ownerTower, targetMinion)
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
