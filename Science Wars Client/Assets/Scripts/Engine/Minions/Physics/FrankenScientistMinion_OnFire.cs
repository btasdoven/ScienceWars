using Assets.Scripts.Engine.GameUtilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts.Engine.Minions.Physics
{
	public class FrankenScientistMinion_OnFire : FrankenScientistMinion
	{
        public FrankenScientistMinion_OnFire()
            : base()
		{			
		}
		
		public override string getName ()
		{
			return "On Fire Frankenscientist";
		}

        public override ScrapGolemMinion createScrapGolem()
        {
            return new ScrapGolemMinion_Overheat();
        }
	}
}
