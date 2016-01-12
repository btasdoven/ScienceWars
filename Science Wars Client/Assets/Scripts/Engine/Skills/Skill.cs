using Assets.Scripts.Engine.GameUtilities;
using Assets.Scripts.Engine.IGUI;

namespace Assets.Scripts.Engine.Skills
{
    public abstract class Skill
    {
		private int instanceId;

        public IStep tag;

        public abstract void step();
    }
}
