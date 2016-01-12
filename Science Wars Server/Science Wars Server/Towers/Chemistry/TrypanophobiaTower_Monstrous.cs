using Science_Wars_Server.Boards;
using Science_Wars_Server.Minions;
using Science_Wars_Server.Missiles.Chemistry;
using Science_Wars_Server.Strategies.TargetStrategies;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Science_Wars_Server.Towers.Chemistry
{
    class TrypanophobiaTower_Monstrous : TrypanophobiaTower_Scary
    {
        private static int cost = 1000;

        private float nextAttackTime = 0;
        private float ATTACK_COOLDOWN = 4.0f;

        public TrypanophobiaTower_Monstrous(Board board, int indexOnBoard)
            : base(board, indexOnBoard)
        {
            // base constructor gerekli board ve index setlemelerini yapiyor. effects ve stats i initialize ediyor.
            stats.baseRange = 1.2f;
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
                    TrypanophobiaMissile missile = new TrypanophobiaMissile(this, m, 1.8f);
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
