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
    class ElectricityTower : PhysicsTower
    {
        private static int cost = 1500;

        private float nextAttackTime = 0;
        private float ATTACK_COOLDOWN = 1.0f;

        public ElectricityTower(Board board, int indexOnBoard)
            : base(board, indexOnBoard)
        {
            // base constructor gerekli board ve index setlemelerini yapiyor. effects ve stats i initialize ediyor.
            stats.baseRange = 2.0f;
        }

        public override void step()
        {
            applyEffects();

            //attackTimeReduction kendi icerisine Chronos.deltaTime'i ekliyor. applyEffects'e bak.
            nextAttackTime -= stats.attackTimeReduction;

            if (nextAttackTime <= 0 && targetStrategy != null && !this.isStunned())
            {
                Collection<Minion> targetMinions = targetStrategy.selectTargetsFromBoard(board, getWorldPosition(), 8, 0, stats.baseRange, MinionStateSelection.ALIVE);

                if (targetMinions.Count < 1)
                    return;

                nextAttackTime = ATTACK_COOLDOWN;
                
                foreach (Minion m in targetMinions)
                {
                    ElectricityMissile missile = new ElectricityMissile(this, m);
                    board.player.game.addMissile(missile);
                }

            }
        }

        public override int getCost()
        {
            return cost;
        }
    }
}
