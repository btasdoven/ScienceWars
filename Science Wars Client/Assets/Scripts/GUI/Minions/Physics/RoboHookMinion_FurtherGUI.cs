using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.Scripts.Engine.Minions.Physics;

namespace Assets.Scripts.GUI.Minions
{
    class RoboHookMinion_FurtherGUI : RoboHookMinionGUI
    {
        public RoboHookMinion_FurtherGUI()
            : base(typeof(RoboHookMinion_Further))	
		{

		}

        public RoboHookMinion_FurtherGUI(Type minionType)
            : base(minionType)
        {

        }

        public override string getInfo()
        {
            return "Further Robo Hook can jump to more range than normal Robo Hook.";
        }

        public override string getUpgradeInfo()
        {
            return "Hook range increases to" +  makePositiveString("3.3") + ".";
        }
    }
}
