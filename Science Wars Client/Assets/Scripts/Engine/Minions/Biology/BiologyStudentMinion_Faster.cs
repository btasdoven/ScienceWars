using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts.Engine.Minions.Biology
{
    class BiologyStudentMinion_Faster : BiologyStudentMinion
    {
        public BiologyStudentMinion_Faster()
            : base()
		{
            stats.baseMovementSpeed = 0.7f;
		}
		
		public override string getName ()
		{
			return "Speedy Biology Student";
		}

        public override int getUpgradeCost()
        {
            return getCost() * 2;
        }
    }
}
