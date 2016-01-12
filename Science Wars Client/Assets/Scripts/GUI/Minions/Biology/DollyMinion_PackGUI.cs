using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.Scripts.Engine.Minions.Biology;

namespace Assets.Scripts.GUI.Minions
{
    class DollyMinion_PackGUI : DollyMinionGUI
    {

        public DollyMinion_PackGUI()
            : base(typeof(DollyMinion_Pack))	
		{
		}

        public override string getInfo()
        {
            return "Dolly clones himself in every 5 seconds up to 3 copies, his clones also can clone himself but they should be in less level 3 in the clone family tree.";
        }

        public override string getUpgradeInfo()
        {
            return "Now can clone himself up to " + makePositiveString("3") + " clones.";
        }

    }
}
