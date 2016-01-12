using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Science_Wars_Server.Boards;
using Science_Wars_Server.Minions;
using Science_Wars_Server.Missiles.Biology;
using Science_Wars_Server.Strategies.TargetStrategies;
using Science_Wars_Server.Missiles;
using Science_Wars_Server.GameUtilities;

namespace Science_Wars_Server.Towers.Biology
{
    class DroseraTower : BiologyTower
    {
        private static int cost = 13500;

        private float nextAttackTime = 0;
        
        private const float healthPerSecond = 120;
        protected virtual float HEALTHPERSECOND { get { return healthPerSecond; } }
        private const float maximumLife = 500;
        protected virtual float MAXIMUMLIFE { get { return maximumLife; } }

        public DroseraTower(Board board, int indexOnBoard)
            : base(board, indexOnBoard)
        {
            // base constructor gerekli board ve index setlemelerini yapiyor. effects ve stats i initialize ediyor.
            stats.baseRange = 0.8f;
        }

        public override void step()
        {
            applyEffects();

            //attackTimeReduction kendi icerisine Chronos.deltaTime'i ekliyor. applyEffects'e bak.
            nextAttackTime -= stats.attackTimeReduction;

            if (nextAttackTime <= 0 && targetStrategy != null && !this.isStunned())
            {
                Collection<Minion> targetMinions = targetStrategy.selectTargetsFromBoard(board, getWorldPosition(), Int32.MaxValue, 0, stats.baseRange, MinionStateSelection.ALIVE);

                if (targetMinions.Count < 1)
                    return;

                foreach (Minion m in targetMinions)
                {
                    if(m.stats.health < MAXIMUMLIFE)
                    {
                        nextAttackTime = m.stats.health / HEALTHPERSECOND;
                        m.dealDamage(new Damage(Int32.MaxValue, DamageType.PHYSICAL), this.board.player);
                        m.dealDamage(new Damage(Int32.MaxValue, DamageType.FIRE), this.board.player);
                        m.dealDamage(new Damage(Int32.MaxValue, DamageType.POISON), this.board.player);
                        if (m.stats.health <= 0)
                        {
                            Messages.OutgoingMessages.Game.GTower_DoseraTower_Bite.sendMessage(m.game.players, this, m);
                            m.onDeath();
                            m.onDestroy();
                        }
                        break;
                    } 
                }
            }
        }

        public override int getCost()
        {
            return cost;
        }
    }
}
