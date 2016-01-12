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

namespace Science_Wars_Server.Towers.Physics
{
    class LaserTower : PhysicsTower
    {
        private static int cost = 12000;

        private const int _simultaneousTargetLimit = 1; // ayni anda en fazla kac miniona saldirabilir.        
        protected virtual int SIMULTANEOUS_TARGET_LIMIT { get { return _simultaneousTargetLimit; } }
        protected const float ATTACK_COOLDOWN = 0.5f;

        protected Minion[] targets;
        protected float[] nextAttackTimes;

        public LaserTower(Board board, int indexOnBoard)
            : base(board, indexOnBoard)
        {
            stats.baseRange = 1.1f;

            targets = new Minion[SIMULTANEOUS_TARGET_LIMIT];
            nextAttackTimes = new float[SIMULTANEOUS_TARGET_LIMIT];
        }

        public override void step()
        {
            applyEffects();
                        
            for (int i = 0; i < targets.Count(); i++ )
            {
                Minion target = targets[i];
                nextAttackTimes[i] -= stats.attackTimeReduction;

                if (target == null)
                {
                    targets[i] = selectUniqueTarget();  // null da gelebilir. bu durumda hedef bulamamisiz demektir. sorun yok.
                    
                    if (targets[i] != null)
                    {
                        Messages.OutgoingMessages.Game.GTower_LaserTower_target.sendMessage( this.board.player.game.players, this, targets[i]);
                    }
                }
                else if (target.minionState == Minion.MinionState.DEAD || target.isInvulnerable() || target.isUntargetable() || target.destroyable ||
                    (this.getLocalPosition() - target.getLocalPosition()).magnitude > stats.baseRange)   // hedef dead, invulnerable ya da menzil disi mi?
                {                    
                    Messages.OutgoingMessages.Game.GTower_LaserTower_untarget.sendMessage(this.board.player.game.players,this, targets[i]);
                    targets[i] = null;    // bu hedefi listeden cikar. artik buna ates etmeyecegiz   
                }
                else if( nextAttackTimes[i] <= 0 ) // bu hedefi dovmeye devam
                {
                    target.dealDamage(new GameUtilities.Damage(60, GameUtilities.DamageType.FIRE),board.player, true);
                    nextAttackTimes[i] = ATTACK_COOLDOWN;
                }
            }

        }

        public override int getCost()
        {
            return cost;
        }

        private Minion selectUniqueTarget()
        {
            foreach (var v in this.board.minions)
            {
                if (v.Value.destroyable == true || v.Value.minionState != Minion.MinionState.ALIVE || v.Value.isUntargetable() == true || targets.Contains(v.Value) == true )
                    continue;

                if ((this.getLocalPosition() - v.Value.getLocalPosition()).magnitude <= stats.baseRange)      // hedef istenilen range'de mi?
                {
                    return v.Value;
                }
            }
            return null;
        }
    }
}
