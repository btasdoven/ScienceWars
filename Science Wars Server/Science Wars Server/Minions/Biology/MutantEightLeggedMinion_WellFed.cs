using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Science_Wars_Server.GameUtilities;
using Science_Wars_Server.Strategies.TargetStrategies;

namespace Science_Wars_Server.Minions.Biology
{
    class MutantEightLeggedMinion_WellFed : MutantEightLeggedMinion
    {
        public MutantEightLeggedMinion_WellFed(Game game, Player ownerPlayer)
            : base(game, ownerPlayer)
        {
            stats.healthTotal = stats.health = 1350;
            stats.movementSpeed = 1.1f;
        }

        public override int getUpgradeCost()
        {
            return 7000;
        }
    }
}
