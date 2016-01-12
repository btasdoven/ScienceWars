using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Science_Wars_Server.Statistics
{
    public class PlayerStats
    {
        public Player ownerPlayer;

        public int minionsSend;
        public int minionsKilled;
        public int minionsPassed;

        public int income;
        public int cash;

        public float moneyEarned;
        public float moneySpend;

        public int towersBuilt;

        public int missilesFired;


        public PlayerStats(Player player)
        {
            this.ownerPlayer = player;

            this.minionsSend = 0;
            this.minionsKilled = 0;
            this.minionsPassed = 0;

            this.moneyEarned = 0.0f;
            this.moneySpend = 0.0f;

            this.towersBuilt = 0;

            this.income = 0;
            this.cash = 0;
        }



    }
}
