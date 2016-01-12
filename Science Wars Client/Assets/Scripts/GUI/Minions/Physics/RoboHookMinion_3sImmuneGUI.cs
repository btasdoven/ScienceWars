using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.Scripts.Engine.Minions.Physics;

namespace Assets.Scripts.GUI.Minions
{
    class RoboHookMinion_3sImmuneGUI : RoboHookMinionGUI
    {
        public RoboHookMinion_3sImmuneGUI()
            : base(typeof(RoboHookMinion_3sImmune))	
		{

		}

        public RoboHookMinion_3sImmuneGUI(Type minionType)
            : base(minionType)
        {

        }

        public override string getInfo()
        {
            return "Immune Robo Hook becomes invulnerable when hooking for 3 seconds.";
        }

        public override string getUpgradeInfo()
        {
            return "With this upgrade Robo Hook becomes invulnerable when hooking for 3 seconds.";
        }
    }
}
