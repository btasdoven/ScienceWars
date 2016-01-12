using Assets.Scripts.Engine.GameUtilities;
using Assets.Scripts.Engine.IGUI;
using UnityEngine;

namespace Assets.Scripts.Engine.AreaEffects
{
    public abstract class AreaEffect
    {
		private int instanceId;

        public IStep tag;
        public bool destroyable;    // TODO areaEffect destroy edilmeye hazir oldugunda bu variable in true olmasi gerek.

        public Player ownerPlayer;
        protected Vector3 worldPosition;

        protected AreaEffect(int instanceId, Player ownerPlayer, Vector3 worldPosition)
        {
            this.instanceId = instanceId;
            this.ownerPlayer = ownerPlayer;
            this.worldPosition = worldPosition;
        }

        /// <summary>
        /// Function that is called in each frame.
        /// </summary>
        public abstract void step();

        public virtual Vector3 getWorldPosition()
        {
            return worldPosition;
        }
    }
}
