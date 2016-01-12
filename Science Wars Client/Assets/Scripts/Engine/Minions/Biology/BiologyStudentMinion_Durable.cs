using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts.Engine.Minions.Biology
{
    class BiologyStudentMinion_Durable : BiologyStudentMinion
    {
        public BiologyStudentMinion_Durable()
            : base()
		{
            stats.health = stats.healthTotal = 120;
		}
		
		public override string getName ()
		{
			return "Durable Biology Student";
		}

        public override int getUpgradeCost()
        {
            return getCost() * 2;
        }
    }
}
