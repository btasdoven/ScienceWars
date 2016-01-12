using Assets.Scripts.Engine.GameUtilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.Scripts.Engine.Minions.Biology;

namespace Assets.Scripts.Engine.Minions.Biology
{
    public class MutantEightLeggedMinion_WellFed : MutantEightLeggedMinion
	{

        public MutantEightLeggedMinion_WellFed()
            : base()
		{
            stats.health = stats.healthTotal = 1350;
            stats.baseMovementSpeed = 1.1f;
		}

	    public override string getName ()
		{
			return "Well Fed Mutant Eight Legged";
		}
        
        public override int getUpgradeCost()
        {
            return 7000;
        }
	}
}
