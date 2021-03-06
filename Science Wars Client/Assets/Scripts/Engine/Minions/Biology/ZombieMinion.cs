﻿using Assets.Scripts.Engine.GameUtilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts.Engine.Minions.Biology
{
    public class ZombieMinion : BiologyMinion
    {
        private static int cost = 3100;
        private static int income = 135;
        private static int killGold = 775;
        private static int healthCost = 1;

        public ZombieMinion()
            : base()
        {
            // butun initializationlari burada yap. yok efendim can setlemek, yok efendim movementspeed bilmemne.
            stats.health = stats.healthTotal = 880;
            stats.baseMovementSpeed = 0.9f;
        }

        public override int getCost()
        {
            return cost;
        }

        public override int getIncome()
        {
            return income;
        }

        public override int getKillGold()
        {
            return killGold;
        }

        public override int getHealthCost()
        {
            return healthCost;
        }

        public override string getName()
        {
            return "Zombie";
        }

        #region implemented abstract members of Minion

        protected override float getLocalHeadHeight()
        {
            return 0.3f;
        }

        #endregion
    }
}
