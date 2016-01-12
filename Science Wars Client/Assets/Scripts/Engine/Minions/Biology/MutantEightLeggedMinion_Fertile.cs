using Assets.Scripts.Engine.GameUtilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.Scripts.Engine.Minions.Biology;

namespace Assets.Scripts.Engine.Minions.Biology
{
    public class MutantEightLeggedMinion_Fertile : MutantEightLeggedMinion
	{

        public MutantEightLeggedMinion_Fertile()
            : base()
		{
		}

	    public override string getName ()
		{
			return "Fertile Mutant Eight Legged";
		}

        public override MutantEightLeggedSpawningMinion createSpawning()
        {
            return new MutantEightLeggedSpawningMinion_WellFed();
        }

        public override int getUpgradeCost()
        {
            return 7000;
        }
	}
}
