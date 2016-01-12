using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Science_Wars_Server.GameUtilities;
using Science_Wars_Server.Strategies.TargetStrategies;

namespace Science_Wars_Server.Minions.Physics
{
    class FrankenScientistMinion_Baked : FrankenScientistMinion_OnFire
    {
        public FrankenScientistMinion_Baked(Game game, Player ownerPlayer)
            : base(game, ownerPlayer)
        {            
        }

        protected override ScrapGolemMinion createNewGolem(Game game, Player ownerPlayer)
        {
            return new ScrapGolemMinion_Armored(game, ownerPlayer); // TODO
        }    
    }
}
