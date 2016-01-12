using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Science_Wars_Server.GameUtilities;
using Science_Wars_Server.Helpers;
using Science_Wars_Server.Minions.Biology;
using Science_Wars_Server.Strategies.TargetStrategies;

namespace Science_Wars_Server.Minions.Biology
{
    class MutantEightLeggedMinion : BiologyMinion
    {
        private const float _deadCaptureRange= .7f; // dead minionlari ne kadar mesafeden yakalayabilir?
        protected const float DEAD_SEARCH_COOLDOWN = .5f;  // her frame aramayalim ölüleri, çok cost'lu olur. 0.5 saniyede 1 ariyoruz.

        protected virtual float DEAD_CAPTURE_RANGE { get { return _deadCaptureRange; } }

        private const int cost = 4800;
        private const int upgradeCost = 0;
        private const int income = 150;
        private const int killGold = 250;
        private const int healthCost = 2;
        
        protected static ArbitraryMinionTargetStrategy minionSelector = new ArbitraryMinionTargetStrategy();

        protected float remainingDeadSearchTime = DEAD_SEARCH_COOLDOWN;
        
        public MutantEightLeggedMinion(Game game, Player ownerPlayer)
            : base(game, ownerPlayer)
        {
            // butun initializationlari burada yap. yok efendim can setlemek, yok efendim movementspeed bilmemne.
            stats.healthTotal = stats.health = 1150;
            stats.baseMovementSpeed = 0.9f;

            stats.setBaseResistances(new List<DamageResistance>() { new DamageResistance(DamageType.PHYSICAL, .75f), new DamageResistance(DamageType.FIRE, .75f), new DamageResistance(DamageType.POISON, .75f) });
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

                        remainingDeadSearchTime -= Chronos.deltaTime;
                        if(remainingDeadSearchTime <= 0)        // her frame targetSelection yapmayalim. zamani geldiyse sadece.
                        {
                            remainingDeadSearchTime = DEAD_SEARCH_COOLDOWN;
                            // gerekli dead minionlari sec.
                            ICollection<Minion> targets = minionSelector.selectTargetsFromBoard(position.board, getWorldPosition(), int.MaxValue, 0, DEAD_CAPTURE_RANGE, MinionStateSelection.DEAD);

                            if (targets.Count != 0)
                            {
                                List<MutantEightLeggedSpawningMinion> spawnings =
                                    new List<MutantEightLeggedSpawningMinion>(targets.Count);

                                foreach (Minion minion in targets)
                                {
                                    if( minion is MutantEightLeggedSpawningMinion)
                                        continue;

                                    MutantEightLeggedSpawningMinion fish = createSpawning(game, ownerPlayer);  // metod override edildigi icin, upgrade baska spawning olusturuyor
                                    minion.position.board.AddMinionSpecificPosition(fish, minion.position.pathPosition,false); // userlara soyleme.
                                    spawnings.Add(fish);
                                }

                                Messages.OutgoingMessages.Game.GMinion_MutantEightLegged_spawn.sendMessage(
                                    game.players, this, spawnings, targets);

                                foreach (var minion in targets)
                                    minion.onDestroy(); // oluleri yerden temizle.
                            }

                        }
                    }
                }
                else if (minionState == MinionState.DEAD && isReadyToDestroy()) // minionState i tekrar kontrol ettim. ne olur ne olmaz yeni bir state eklersek patlamasin.
                    onDestroy();
            }
        }

        protected virtual MutantEightLeggedSpawningMinion createSpawning(Game game, Player ownerPlayer)
        {
            return new MutantEightLeggedSpawningMinion(game, ownerPlayer);
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
