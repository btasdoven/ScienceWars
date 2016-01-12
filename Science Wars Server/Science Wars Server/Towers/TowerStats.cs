using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Science_Wars_Server.Towers
{
    public class TowerStats
    {
        // multipliers and dividers
        public float rangeMult = 1;
        public float rangeDivider = 1;

        public float attackSpeedMult = 1;
        public float attackSpeedDivider = 1;

        // stats
        public float baseRange;

        public bool stunned;

        public float range;
        public float attackTimeReduction;

        public void restore()
        {
            stunned = false;
            range = baseRange;
            attackTimeReduction = 0;

            rangeMult = 1;
            rangeDivider = 1;
            attackSpeedMult = 1;
            attackSpeedDivider = 1;
        }
    }
}
