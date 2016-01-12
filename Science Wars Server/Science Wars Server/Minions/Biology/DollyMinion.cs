using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Science_Wars_Server.Boards;
using Science_Wars_Server.GameUtilities;
using Science_Wars_Server.Helpers;


namespace Science_Wars_Server.Minions.Biology
{
    class DollyMinion : BiologyMinion
    {
        private const float _default_effect_cooldown_time = 5.0f;
        private const int _max_copies = 2;

        protected virtual float DEFAULT_EFFECT_COOLDOWN_TIME { get { return _default_effect_cooldown_time;} }
        protected virtual int MAX_COPIES { get {return _max_copies;}}

        private int numOfCopies = 0;

        /// <summary>
        /// Bu degisken dolly'in kopyalama islemini ne zaman bitirecegini tutmak icin kullanılıyorç
        /// </summary>
        private int  heritanceLevel = 0;
        private static int cost = 1100;
        private static int upgradeCost = 0;
        private static int income = 102;
        private static int killGold = 275;
        private static int healthCost = 1;
        private static float effectCooldownTime;

        public DollyMinion(Game game, Player ownerPlayer)
            : base(game, ownerPlayer)
        {
            // butun initializationlari burada yap. yok efendim can setlemek, yok efendim movementspeed bilmemne.
            stats.healthTotal = stats.health = 220;
            stats.baseMovementSpeed = 0.8f;
            effectCooldownTime = DEFAULT_EFFECT_COOLDOWN_TIME;
            this.heritanceLevel = 0;
        }

        public DollyMinion(Game game, Player ownerPlayer,int  heritanceLevel)
            : base(game, ownerPlayer)
        {
            // butun initializationlari burada yap. yok efendim can setlemek, yok efendim movementspeed bilmemne.
            stats.healthTotal = stats.health = 35;
            stats.baseMovementSpeed = 0.8f;
            effectCooldownTime = DEFAULT_EFFECT_COOLDOWN_TIME;
            this.heritanceLevel = heritanceLevel;
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

                        if (heritanceLevel < 3 && numOfCopies < MAX_COPIES)
                        {
                            if (effectCooldownTime - Chronos.deltaTime <= 0)
                            {
                                effectCooldownTime = DEFAULT_EFFECT_COOLDOWN_TIME;
                                DollyMinion newDolly = new DollyMinion(this.game, this.ownerPlayer, heritanceLevel + 1);

                                PathPosition newPos = new PathPosition(0, 0);

                                numOfCopies++;
                                position.board.getPath().move(this.position.pathPosition, -0.2f * numOfCopies, out newPos);

                                this.position.board.AddMinionSpecificPosition(newDolly, newPos);
                                Science_Wars_Server.Messages.OutgoingMessages.Game.GCopyMinionResult.sendMessage(game.players, newDolly);
                            }
                            else
                            {
                                effectCooldownTime -= Chronos.deltaTime;
                            }
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
