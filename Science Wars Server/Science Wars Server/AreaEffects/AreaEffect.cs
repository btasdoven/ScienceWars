using Science_Wars_Server.GameUtilities;
using Science_Wars_Server.Helpers;
namespace Science_Wars_Server.AreaEffects
{
    public abstract class AreaEffect
    {
        private static int idGenerator = 0;
        public int instanceId;
        public bool destroyable;    // TODO bu areaEffect yokedilmeye hazir oldugunda true donmesi gerek.

        public Player ownerPlayer;
        protected Vector3 worldPosition;

        protected AreaEffect(Player ownerPlayer, Vector3 worldPosition)
        {
            this.instanceId = idGenerator++;
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
