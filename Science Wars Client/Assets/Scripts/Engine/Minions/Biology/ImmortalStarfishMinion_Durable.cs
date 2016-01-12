using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.Scripts.Engine.GameUtilities;

namespace Assets.Scripts.Engine.Minions.Biology
{
    class ImmortalStarfishMinion_Durable : ImmortalStarfishMinion
    {
        public ImmortalStarfishMinion_Durable()
            : base()
		{
            stats.setBaseResistances(new List<DamageResistance>() { new DamageResistance(DamageType.PHYSICAL, .7f), new DamageResistance(DamageType.POISON, .7f) });
		}

		
		public override string getName ()
		{
			return "Durable Immortal Starfish";
		}

        public override int getUpgradeCost()
        {
            return getCost() * 2;
        }
    }
}
