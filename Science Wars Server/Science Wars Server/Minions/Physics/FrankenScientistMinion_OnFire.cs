using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Science_Wars_Server.GameUtilities;
using Science_Wars_Server.Strategies.TargetStrategies;

namespace Science_Wars_Server.Minions.Physics
{
    class FrankenScientistMinion_OnFire : FrankenScientistMinion
    {
        public FrankenScientistMinion_OnFire(Game game, Player ownerPlayer)
            : base(game, ownerPlayer)
        {            
        }

        protected override ScrapGolemMinion createNewGolem(Game game, Player ownerPlayer)
        {
            return new ScrapGolemMinion_Overheat(game, ownerPlayer);
        }
    }
}
