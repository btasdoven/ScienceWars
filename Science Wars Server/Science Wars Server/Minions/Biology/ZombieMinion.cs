using System;
using System.Collections.Generic;
using Science_Wars_Server.Effects.MinionEffects;
using Science_Wars_Server.GameUtilities;
using Science_Wars_Server.Helpers;

namespace Science_Wars_Server.Minions.Biology
{
    public class ZombieMinion : BiologyMinion
    {
        private static float DEFAULT_EFFECT_COOLDOWN_TIME = 3.0f;

        private static int cost = 3100;
        private static int upgradeCost = 0;
        private static int income = 135;
        private static int killGold = 775;
        private static int healthCost = 1;
        private bool diedBefore = false;
        private static float effectCooldownTime;

        public ZombieMinion(Game game, Player ownerPlayer)
            : base(game, ownerPlayer)
        {
            // butun initializationlari burada yap. yok efendim can setlemek, yok efendim movementspeed bilmemne.
            stats.healthTotal = stats.health = 880;
            stats.baseMovementSpeed = 0.9f;
            effectCooldownTime = DEFAULT_EFFECT_COOLDOWN_TIME;
        }

        public override void step()
        {
            if( destroyable == false)
            {
                if (minionState == MinionState.ALIVE)
                {
                    if (stats.health <= 0)
                    {
                        onDeath();
                    }
                    else
                    {
                        walk();
                    }
                }
                else if(minionState == MinionState.DEAD && !diedBefore)
                {
                    effectCooldownTime -= Chronos.deltaTime;
                    if (effectCooldownTime - Chronos.deltaTime <= 0)
                    {
                        diedBefore = true;
                        minionState = MinionState.ALIVE;
                        stats.health = 264;
                        stats.baseMovementSpeed = 1.1f;
                        Messages.OutgoingMessages.Game.GMinion_Zombie_Raise.sendMessage(game.players, this);
                    }
                }
                else if (minionState == MinionState.DEAD && isReadyToDestroy()) // minionState i tekrar kontrol ettim. ne olur ne olmaz yeni bir state eklersek patlamasin.
                        onDestroy();
            }
        }

        public override void onDeath()
        {
            if (!diedBefore)
            {
                minionState = MinionState.DEAD; // ilk ölüşünde, öldüren kişiye para vermiyoruz.
                Messages.OutgoingMessages.Game.GMinionHealthInfo.sendMessage(game.players,this);
            }
            else
                base.onDeath();
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
    }
}
