using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Science_Wars_Server.Boards;
using Science_Wars_Server.GameUtilities;
using Science_Wars_Server.Helpers;

namespace Science_Wars_Server.Minions.Physics
{
    class MirrorSoldierIlisionMinion : PhysicsMinion
    {
        private static float DEFAULT_EFFECT_COOLDOWN_TIME = 3.0f;

        private static int cost = 0;
        private static int upgradeCost = 0;
        private static int income = 0;
        private static int killGold = 0;
        private static int healthCost = 0;
        private static float effectCooldownTime;

        public MirrorSoldierIlisionMinion(Game game, Player ownerPlayer)
            : base(game, ownerPlayer)
        {
            // butun initializationlari burada yap. yok efendim can setlemek, yok efendim movementspeed bilmemne.
            stats.health = stats.healthTotal = 320;
            stats.baseMovementSpeed = 1.1f;
            effectCooldownTime = DEFAULT_EFFECT_COOLDOWN_TIME;
            stats.invulnerable = true;
        }

        public override void step()
        {
            if (destroyable == false)
            {
                stats.invulnerable = true;
                if (minionState == MinionState.ALIVE)
                {
                    if (stats.health <= 0)
                    {
                        onDeath();
                    }
                    else
                    {
                        walk();

                            if (effectCooldownTime - Chronos.deltaTime <= 0)
                            {
                                this.destroyable = true;
                                Messages.OutgoingMessages.Game.GDestroyMinionInfo.sendMessage(this.game.players, this);
                            }
                            else
                            {
                                effectCooldownTime -= Chronos.deltaTime;
                            }
                
                    }
                }
                else if (minionState == MinionState.DEAD && isReadyToDestroy()) // minionState i tekrar kontrol ettim. ne olur ne olmaz yeni bir state eklersek patlamasin.
                    onDestroy();
            }
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
