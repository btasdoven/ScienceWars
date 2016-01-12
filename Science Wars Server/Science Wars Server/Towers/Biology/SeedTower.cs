using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Science_Wars_Server.Boards;
using Science_Wars_Server.Minions;
using Science_Wars_Server.Missiles.Biology;
using Science_Wars_Server.AreaEffects;
using Science_Wars_Server.Helpers;
using Science_Wars_Server.GameUtilities;
using Science_Wars_Server.Messages.OutgoingMessages.Game;
using Science_Wars_Server.Strategies.TargetStrategies;

namespace Science_Wars_Server.Towers.Biology
{
    class SeedTower : BiologyTower
    {
        private static int cost = 1000;
        private static int MAX_STACK_SIZE = 5;
        private static float SEED_RELOAD_TIME = 10.0f;
        private static float SEED_CREATION_DELAY = 0.2f;

        public int seedCountInStack = 0;
        private float nextReloadTime = 0;
        private float nextSeedCreateTime = 0;

        public SeedTower(Board board, int indexOnBoard)
            : base(board, indexOnBoard)
        {
            // base constructor gerekli board ve index setlemelerini yapiyor. effects ve stats i initialize ediyor.
            stats.baseRange = 1.1f;
            targetStrategy = new NearestMinionTargetStrategy();
        }

        public override void step()
        {
            applyEffects();

            //attackTimeReduction kendi icerisine Chronos.deltaTime'i ekliyor. applyEffects'e bak.
            nextReloadTime -= stats.attackTimeReduction;
            nextSeedCreateTime -= stats.attackTimeReduction;

            if (nextReloadTime <= 0 && seedCountInStack < MAX_STACK_SIZE)
            {
                seedCountInStack++;
                GTower_SeedTower_stackSeed.sendMessage(board.player.game.players, this);
                nextReloadTime = SEED_RELOAD_TIME;
            }

            Collection<Minion> targetMinions = targetStrategy.selectTargetsFromBoard(board, getWorldPosition(), 1, 0, stats.baseRange, MinionStateSelection.ALIVE);

            if (targetMinions.Count > 0 && seedCountInStack > 0 && nextSeedCreateTime <= 0)
            {
                SeedTowerMissile missile = new SeedTowerMissile(this, targetMinions.First(), 1);
                board.player.game.addMissile(missile);
                seedCountInStack--;
                nextSeedCreateTime = SEED_CREATION_DELAY;
            }
        }

        public override int getCost()
        {
            return cost;
        }
    }
}
