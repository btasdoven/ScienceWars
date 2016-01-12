using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Science_Wars_Server.Towers;

namespace Science_Wars_Server.Effects.TowerEffects
{
    public class RegularTowerEffect : ITowerEffect
    {
        public RegularTowerEffect()
        {
            remainingTime = 3;
        }

        public override void step(Tower tower)
        {
            tower.stats.attackSpeedMult *= 1.2f;                                  //attack speedi %20 arttirir.
            tower.stats.rangeDivider = Math.Min(tower.stats.rangeDivider, 0.3f);         //range'i %30'una dusur.
        }
    }
}
