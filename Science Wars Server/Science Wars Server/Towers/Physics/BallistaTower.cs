using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Science_Wars_Server.Boards;
using Science_Wars_Server.Minions;
using Science_Wars_Server.Missiles.Physics;
using Science_Wars_Server.Strategies.TargetStrategies;
using Science_Wars_Server.Missiles;

namespace Science_Wars_Server.Towers.Physics
{
    class BallistaTower : PhysicsTower
    {
        private static int cost = 1200;

        private float nextAttackTime = 0;
        private float ATTACK_COOLDOWN = 0.75f;

        public BallistaTower(Board board, int indexOnBoard)
            : base(board, indexOnBoard)
        {
            // base constructor gerekli board ve index setlemelerini yapiyor. effects ve stats i initialize ediyor.
            stats.baseRange = 1.6f;
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

                nextAttackTime = ATTACK_COOLDOWN;

                foreach (Minion m in targetMinions)
                {
                    Missile missile = createMissile(m);
                    board.player.game.addMissile(missile);
                }
            }
        }

        protected virtual Missile createMissile(Minion m)
        {
            return new BallistaMissile(this, m);
        }

        public override int getCost()
        {
            return cost;
        }
    }
}
