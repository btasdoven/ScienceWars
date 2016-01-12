using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Science_Wars_Server.GameUtilities;
using Science_Wars_Server.Strategies.TargetStrategies;

namespace Science_Wars_Server.Minions.Physics
{
    class FrankenScientistMinion : PhysicsMinion
    {
        private const int _requiredDeadMinionCount = 5; // kac minion toplayinca yeni minion cikaracagiz?
        private const int _totalSpawnLimit = 1; // en fazla 1 kere scrap golem spawnlayabilir.
        private const float _deadCaptureRange= .7f; // dead minionlari ne kadar mesafeden yakalayabilir?

        protected virtual int REQUIRED_DEAD_MINION_COUNT { get { return _requiredDeadMinionCount; } }        // artik bunlari override edebiliriz. 
        protected virtual int TOTAL_SPAWN_LIMIT { get { return _totalSpawnLimit; } }                         // bu sayede alt classlar gerekmedikce tanimlamaz.
        protected virtual float DEAD_CAPTURE_RANGE { get { return _deadCaptureRange; } }

        private const int cost = 2700;
        private const int upgradeCost = 4000;
        private const int income = 130;
        private const int killGold = 250;
        private const int healthCost = 1;
        
        protected static ArbitraryMinionTargetStrategy minionSelector = new ArbitraryMinionTargetStrategy();
        protected int remainingSpawnCount = 0;    // kac minion daha olusturma hakkimiz kaldi?
        protected int requiredDeadCount = 0;      // kac dead minion daha toplarsak yeni birtane yapabiliriz?
        
        public FrankenScientistMinion(Game game, Player ownerPlayer)
            : base(game, ownerPlayer)
        {
            // butun initializationlari burada yap. yok efendim can setlemek, yok efendim movementspeed bilmemne.
            stats.healthTotal = stats.health = 1100;
            stats.baseMovementSpeed = 0.65f;

            stats.setBaseResistances( new List<DamageResistance>(){ new DamageResistance(DamageType.PHYSICAL, .85f),new DamageResistance(DamageType.POISON, .85f)});
            requiredDeadCount = REQUIRED_DEAD_MINION_COUNT;
            remainingSpawnCount = TOTAL_SPAWN_LIMIT;
        }

        public override void step()
        {
            if (destroyable == false)
            {
                if (minionState == MinionState.ALIVE)
                {
                    if (stats.health <= 0)
                        onDeath();
                    else
                    {
                        walk();

                        if (remainingSpawnCount > 0)
                        {
                            // gerekli dead minionlari sec.
                            ICollection<Minion> targets = minionSelector.selectTargetsFromBoard(position.board, getWorldPosition(), requiredDeadCount, 0, DEAD_CAPTURE_RANGE, MinionStateSelection.DEAD);

                            foreach( Minion minion in targets)
                            {
                                minion.onDestroy(); // oluleri yerden temizle.
                            }

                            requiredDeadCount -= targets.Count;
                            
                            if(targets.Count != 0)
                                Messages.OutgoingMessages.Game.GMinion_FrankenScientist_stackChanged.sendMessage(this.position.board.player.game.players, this, REQUIRED_DEAD_MINION_COUNT - requiredDeadCount);

                            if (requiredDeadCount == 0) // yeteri kadar olu topladik mi?
                            {
                                ScrapGolemMinion fish = createNewGolem(game, ownerPlayer);
                                position.board.AddMinionSpecificPosition(fish, position.pathPosition , false);
                                fish.moveCustomDistance((new Random().Next(101)) / 200f - 0.25f);
                                Science_Wars_Server.Messages.OutgoingMessages.Game.GMinion_FrankenScientist_spawn.sendMessage(game.players, this, fish);
                                remainingSpawnCount--;
                                requiredDeadCount = REQUIRED_DEAD_MINION_COUNT;

                                Messages.OutgoingMessages.Game.GMinion_FrankenScientist_stackChanged.sendMessage(this.position.board.player.game.players, this, 0);
                            }
                        }
                    }
                }
                else if (minionState == MinionState.DEAD && isReadyToDestroy()) // minionState i tekrar kontrol ettim. ne olur ne olmaz yeni bir state eklersek patlamasin.
                    onDestroy();
            }
        }

        protected virtual ScrapGolemMinion createNewGolem(Game game, Player ownerPlayer)
        {
            return new ScrapGolemMinion(game, ownerPlayer);
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
