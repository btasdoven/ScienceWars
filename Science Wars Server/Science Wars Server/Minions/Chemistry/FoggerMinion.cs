using System;
using System.Collections.Generic;
using Science_Wars_Server.Effects.MinionEffects;
using Science_Wars_Server.GameUtilities;
using Science_Wars_Server.Helpers;
using Science_Wars_Server.AreaEffects;


namespace Science_Wars_Server.Minions.Chemistry
{
    class FoggerMinion : ChemistryMinion
    {
        private static int cost = 2250;
        private static int upgradeCost = 0;
        private static int income = 124;
        private static int killGold = 562;
        private static int healthCost = 1;

        private bool bombSent =false;

        public FoggerMinion(Game game, Player ownerPlayer)
            : base(game, ownerPlayer)
        {
            // butun initializationlari burada yap. yok efendim can setlemek, yok efendim movementspeed bilmemne.
            stats.health = stats.healthTotal = 560;
            stats.baseMovementSpeed = 0.6f;
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

        public override void dealDamage(Damage damage, Player damageDealer, bool notifyPlayer = true)
        {
            if (bombSent == false)
            {
                bombSent = true;

                AreaEffect areaEffect = new FogBombAreaEffect( ownerPlayer, getWorldPosition() );
                Messages.OutgoingMessages.Game.GAddAreaEffect.sendMessage(position.board.player.game.players, areaEffect);
                position.board.player.game.addAreaEffect(areaEffect);
            }

            base.dealDamage(damage, damageDealer, notifyPlayer);
        }
    }
}
