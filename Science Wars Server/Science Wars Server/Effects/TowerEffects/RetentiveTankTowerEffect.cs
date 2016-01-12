using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Science_Wars_Server.Effects.TowerEffects
{
    class RetentiveTankTowerEffect : ITowerEffect
    {
        public RetentiveTankTowerEffect()
        { 
            remainingTime = 5;
        }
    
        public override void step(Towers.Tower tower)
        {
            tower.stats.stunned = true;
        }
    }
}
