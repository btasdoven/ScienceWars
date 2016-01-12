using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Science_Wars_Server.GameUtilities;
using Science_Wars_Server.Strategies.TargetStrategies;

namespace Science_Wars_Server.Minions.Biology
{
    class MutantEightLeggedMinion_Fertile : MutantEightLeggedMinion
    { 
        public MutantEightLeggedMinion_Fertile(Game game, Player ownerPlayer)
            : base(game, ownerPlayer)
        {
        }
        
        protected override MutantEightLeggedSpawningMinion createSpawning(Game game, Player ownerPlayer)
        {
            return new MutantEightLeggedSpawningMinion_WellFed(game, ownerPlayer);
        }

        public override int getUpgradeCost()
        {
            return 7000;
        }
    }
}
