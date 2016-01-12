using System.Collections.Generic;
using Science_Wars_Server.GameUtilities;
using Science_Wars_Server.Helpers;
using Science_Wars_Server.Minions;
using Science_Wars_Server.Towers;

namespace Science_Wars_Server.Missiles
{
    public abstract class Missile
    {
        protected static int idGenerator = 0;
        public int instanceId;

        protected float movementSpeed = 5; // TODO Minion statstan al
        
        protected Missile(Vector3 startWorldPosition, Tower ownerTower, Minion targetMinion)
        {
            instanceId = idGenerator++;
            this.targetMinion = targetMinion;
            this.ownerTower = ownerTower;
            this.position = startWorldPosition;
        }

        protected Missile(Tower ownerTower, Minion targetMinion)
        {
            instanceId = idGenerator++;
            this.ownerTower = ownerTower;
            this.targetMinion = targetMinion;
            this.position = ownerTower.getWorldPosition();
        }

     
        public Vector3 position;

        public Minion targetMinion;
        public Tower ownerTower;
        public bool destroyable;        // TODO missile yokedilmeye hazir oldugunda true donmesi gerek.

        // TODO List<Effect> effects
        // TODO MissileStats stats -movementSpeed gibi

        protected List<Damage> damageList = new List<Damage>();

        public abstract void step();

        public virtual bool chase()
        {
            Vector3 minionPos = targetMinion.getWorldPosition();
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
