using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Science_Wars_Server.Boards;
using Science_Wars_Server.Minions;
using Science_Wars_Server.Missiles.Biology;
using Science_Wars_Server.Missiles.Physics;
using Science_Wars_Server.Strategies.TargetStrategies;

namespace Science_Wars_Server.Towers.Physics
{
    class BlackHoleTower : PhysicsTower
    {
        private static int cost = 4000;

        private float nextAttackTime = 0;
        private static float TELEPORT_COOLDOWN_DEFAULT = 4.0f;
        private static float TELEPORT_DISTANCE_DEFAULT = 2f;
        private static float TELEPORT_DIAMETER_DEFAULT = 0.5f;

        public BlackHoleTower(Board board, int indexOnBoard)
            : base(board, indexOnBoard)
        {
            // base constructor gerekli board ve index setlemelerini yapiyor. effects ve stats i initialize ediyor.
            stats.baseRange = 2f;
        }

        public override void step()
        {
            applyEffects();

            //attackTimeReduction kendi icerisine Chronos.deltaTime'i ekliyor. applyEffects'e bak.
            nextAttackTime -= stats.attackTimeReduction;

            if (nextAttackTime <= 0 && targetStrategy != null && !this.isStunned())
            {

                Collection<Minion> targetMinions = targetStrategy.selectTargetsFromBoard(board, getWorldPosition(), 1, 0, stats.baseRange, MinionStateSelection.ALIVE);

                if (targetMinions.Count < 1)
                    return;

                nextAttackTime = TELEPORT_COOLDOWN_DEFAULT;

                targetMinions = new NearestMinionTargetStrategy().selectTargetsFromBoard(board, targetMinions[0].getWorldPosition(), int.MaxValue, 0, TELEPORT_DIAMETER_DEFAULT, MinionStateSelection.ALIVE);

                Messages.OutgoingMessages.Game.GTower_BlackHole_teleport.sendMessage(board.player.game.players, this, targetMinions);

                foreach (Minion m in targetMinions)
                {
                    m.moveCustomDistance(-TELEPORT_DISTANCE_DEFAULT);
                }

            }
        }

        public override int getCost()
        {
            return cost;
        }
    }
}
