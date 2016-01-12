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
    class MirrorSoldierMinion : PhysicsMinion
    {

        private static float DEFAULT_EFFECT_COOLDOWN_TIME = 8.0f;

        private static int cost = 1350;
        private static int upgradeCost = 0;
        private static int income = 108;
        private static int killGold = 337;
        private static int healthCost = 1;
        private static float effectCooldownTime;

        public MirrorSoldierMinion(Game game, Player ownerPlayer)
            : base(game, ownerPlayer)
        {
            // butun initializationlari burada yap. yok efendim can setlemek, yok efendim movementspeed bilmemne.
            stats.health = stats.healthTotal = 320;
            stats.baseMovementSpeed = 1.1f;
            effectCooldownTime = DEFAULT_EFFECT_COOLDOWN_TIME;
            
        }

        public override void step()
        {
            if (destroyable == false)
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

                            if (effectCooldownTime - Chronos.deltaTime <= 0)
                            {
                                effectCooldownTime = DEFAULT_EFFECT_COOLDOWN_TIME;
                                MirrorSoldierIlisionMinion newIlision = new MirrorSoldierIlisionMinion(this.game, this.ownerPlayer);

                                PathPosition newPos = new PathPosition(0, 0);

                                position.board.getPath().move(this.position.pathPosition, -0.2f , out newPos);

                                this.position.board.AddMinionSpecificPosition(newIlision, newPos);
                                Science_Wars_Server.Messages.OutgoingMessages.Game.GCopyMinionResult.sendMessage(game.players, newIlision);
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
