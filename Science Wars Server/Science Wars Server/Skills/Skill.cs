using Science_Wars_Server.GameUtilities;
namespace Science_Wars_Server.Skills
{
    public abstract class Skill
    {
        private static int idGenerator = 0;
        private int instanceId;

        protected Skill()
        {
            instanceId = idGenerator++;
        }

        public abstract float getCooldown();

        public abstract void step();
    }
}
