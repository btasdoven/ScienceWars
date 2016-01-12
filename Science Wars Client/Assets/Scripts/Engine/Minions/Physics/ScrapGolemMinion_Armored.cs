using Assets.Scripts.Engine.GameUtilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts.Engine.Minions.Physics
{
	public class ScrapGolemMinion_Armored : ScrapGolemMinion_Overheat
	{
        public ScrapGolemMinion_Armored()
            : base()
		{
            stats.setBaseResistances(new List<DamageResistance>(){
                new DamageResistance(DamageType.PHYSICAL,0.4f),
                new DamageResistance(DamageType.FIRE,0.4f),
                new DamageResistance(DamageType.POISON,0.4f)});
		}
		
		public override string getName ()
		{
			return "Armored Scrap Golem";
		}
	}
}
