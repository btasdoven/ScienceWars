using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.Scripts.Engine.Minions.Biology;
using System;

namespace Assets.Scripts.GUI.Minions
{
    class ImmortalStarfishChildMinion_DurableGUI : ImmortalStarfishChildMinionGUI
    {

        public ImmortalStarfishChildMinion_DurableGUI()
            : base(typeof(ImmortalStarfishChildMinion_Durable))	
		{
		}

        public ImmortalStarfishChildMinion_DurableGUI(Type minionType)
            : base(minionType)
        {
        }

        public override string getInfo()
        {
            return "This minion is the durable child of the " + makeInfoString("Immortal Starfish") +  ".";
        }

        public override string getUpgradeInfo()
        {
            return "Now has " + makePositiveString("150") + " health points.";
        }

    }
}
