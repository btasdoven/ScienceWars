using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.Scripts.Engine.Minions.Biology;

namespace Assets.Scripts.GUI.Minions
{
    class ImmortalStarfishChildMinion_FastGUI : ImmortalStarfishChildMinion_DurableGUI
    {

        public ImmortalStarfishChildMinion_FastGUI()
            : base(typeof(ImmortalStarfishChildMinion_Fast))	
		{
		}

        public override string getInfo()
        {
            return "This minion is the faster child of the " + makeInfoString("Immortal Starfish") +  ".";
        }

        public override string getUpgradeInfo()
        {
            return "Now has " + makePositiveString("1.4") + " movement speed.";
        }

    }
}
