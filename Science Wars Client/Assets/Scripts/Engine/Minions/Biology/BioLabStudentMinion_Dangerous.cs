using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts.Engine.Minions.Biology
{
    class BioLabStudentMinion_Dangerous : BioLabStudentMinion
    {

        public BioLabStudentMinion_Dangerous()
            : base()
		{
            
		}

        public override int getHealthCost()
        {
            return 2;
        }
		
		public override string getName ()
		{
			return "Dangerous Biology Lab Student";
		}

        public override int getUpgradeCost()
        {
            return getCost() * 2;
        }

    }
}
