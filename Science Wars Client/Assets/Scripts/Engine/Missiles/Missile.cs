using System.Collections.Generic;
using Assets.Scripts.Engine.GameUtilities;
using Assets.Scripts.Engine.IGUI;
using Assets.Scripts.Engine.Minions;
using Assets.Scripts.Engine.Towers;
using UnityEngine;

namespace Assets.Scripts.Engine.Missiles
{
    public abstract class Missile
    {
        public int instanceId;

        public IStep tag;

        public Vector3 position;

        public Minion targetMinion;
        public Tower ownerTower;
        public bool destroyable;    // missile destroy edilmeye hazir oldugunda bu variable in true olmasi gerek.
        
        // TODO private List<Effect> effects;
        // TODO MissileStats stats - movementSpeed gibi

		protected List<Damage> damageList = new List<Damage>();

        protected Missile(int instanceId, Vector3 position, Minion minion)
        {
            this.instanceId = instanceId;
            this.targetMinion = minion;
            this.position = position;
        }

        protected Missile(int instanceId, Tower tower, Minion minion)
        {
            this.instanceId = instanceId;
            this.ownerTower = tower;
            this.targetMinion = minion;
			this.position = tower.getWorldMissileCreatePosition();
        }

        public abstract void step();
    }
}
