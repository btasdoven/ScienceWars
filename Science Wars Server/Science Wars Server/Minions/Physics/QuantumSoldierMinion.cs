using System;
using System.Collections.Generic;
using Science_Wars_Server.Effects.MinionEffects;
using Science_Wars_Server.GameUtilities;
using Science_Wars_Server.Helpers;

namespace Science_Wars_Server.Minions.Physics
{
    class QuantumSoldierMinion : PhysicsMinion
    {
        private static int cost = 2000;
        private static int upgradeCost = 0;
        private static int income = 120;
        private static int killGold = 500;
        private static int healthCost = 1;

        protected static float NEXT_TELEPORT_COOLDOWN_DEFAULT = 12.0f;
        protected static float TELEPORT_DISTANCE_DEFAULT = 1.3f;
        protected static float APPLY_EFFECT_RANGE_DEFAULT = 0.5f;

        protected float nextTeleportTime;

        public QuantumSoldierMinion(Game game, Player ownerPlayer)
            : base(game, ownerPlayer)
        {
            // butun initializationlari burada yap. yok efendim can setlemek, yok efendim movementspeed bilmemne.
            stats.healthTotal = stats.health = 480;
            stats.baseMovementSpeed = 1f;
            stats.setBaseResistances(new List<DamageResistance>(){new DamageResistance(DamageType.POISON, .8f)});
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

        public virtual void onJumpEnded()
        {

        }

        public virtual void onJumpStarted()
        {

        }
   

        public override void dealDamage(Damage damage, Player damageDealer, bool notifyPlayer = true)
        {
            if (nextTeleportTime <= 0)
            {
                onJumpStarted();
                nextTeleportTime = NEXT_TELEPORT_COOLDOWN_DEFAULT;
                List<Minion> minionList = new List<Minion> ();
                Messages.OutgoingMessages.Game.GMinion_QuantumSoldier_teleport.sendMessage(position.board.player.game.players, this, minionList);
                moveCustomDistance(TELEPORT_DISTANCE_DEFAULT);
                onJumpEnded();
            }
            base.dealDamage(damage, damageDealer, notifyPlayer);
        }

        public override int getCost()
        {
            return cost;
        }

        public override int getUpgradeCost()
        {
            return upgradeCost;
        }  
    }
}
