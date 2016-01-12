using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts.Engine.Minions.Biology
{
    class DollyMinion_Lesscd : DollyMinion
    {

        public DollyMinion_Lesscd()
            : base()
		{
            
		}
		
		public override string getName ()
		{
			return "Less Cooldown Dolly";
		}

        public override int getUpgradeCost()
        {
            return getCost() * 2;
        }

    }
}
