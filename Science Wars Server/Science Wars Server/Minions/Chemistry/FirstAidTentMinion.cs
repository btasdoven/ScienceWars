using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Science_Wars_Server.GameUtilities;
using Science_Wars_Server.Helpers;
using Science_Wars_Server.Strategies.TargetStrategies;

namespace Science_Wars_Server.Minions.Chemistry
{
    class FirstAidTentMinion : ChemistryMinion
    {
        private static int cost = 4700;
        private static int upgradeCost = 0;
        private static int income = 149;
        private static int killGold = 1175;
        private static int healthCost = 4;

        private float EFFECT_RADIUS = 1.0f;

        public FirstAidTentMinion(Game game, Player ownerPlayer)
            : base(game, ownerPlayer)
        {
            // butun initializationlari burada yap. yok efendim can setlemek, yok efendim movementspeed bilmemne.
            stats.healthTotal = stats.health = 1020;
            stats.baseMovementSpeed = 0.45f;
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

        public override int getCost()
        {
            return cost;
        }

        public override int getUpgradeCost()
        {
            return upgradeCost;
        }       

        public override void onDeath()
        {
            base.onDeath();

            NearestMinionTargetStrategy targetSelector = new NearestMinionTargetStrategy();
            ICollection<Minion> targets = targetSelector.selectTargetsFromBoard(position.board, this.getWorldPosition(), int.MaxValue, 0, EFFECT_RADIUS, MinionStateSelection.ALIVE);
            foreach (var minion in targets)
            {
                    minion.stats.healToMaxHP();
                    Messages.OutgoingMessages.Game.GMinionHealthInfo.sendMessage(this.game.players, minion);
            }                        
        }
    }
}
