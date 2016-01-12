using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.Scripts.Engine.Minions.Biology;

namespace Assets.Scripts.GUI.Minions
{
    class DollyMinion_LesscdGUI : DollyMinionGUI
    {

        public DollyMinion_LesscdGUI()
            : base(typeof(DollyMinion_Lesscd))	
		{
		}

        public override string getInfo()
        {
            return "Dolly clones himself in every 4.5 seconds up to 2 copies, his clones also can clone himself but they should be in less level 3 in the clone family tree.";
        }

        public override string getUpgradeInfo()
        {
            return "Now copies himself in every " + makePositiveString("4.5") + " seconds.";
        }

    }
}
