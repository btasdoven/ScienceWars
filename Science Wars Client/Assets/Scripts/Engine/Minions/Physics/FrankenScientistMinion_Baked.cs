using Assets.Scripts.Engine.GameUtilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts.Engine.Minions.Physics
{
	public class FrankenScientistMinion_Baked : FrankenScientistMinion_OnFire
	{
        public FrankenScientistMinion_Baked()
            : base()
		{			
		}
		
		public override string getName ()
		{
			return "Baked Frankenscientist";
		}

        public override ScrapGolemMinion createScrapGolem()
        {
            return new ScrapGolemMinion_Armored();
        }
	}
}
