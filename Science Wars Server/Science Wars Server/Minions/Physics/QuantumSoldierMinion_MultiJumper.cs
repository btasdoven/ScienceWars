using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Science_Wars_Server.Effects.MinionEffects;
using Science_Wars_Server.GameUtilities;
using Science_Wars_Server.Helpers;

namespace Science_Wars_Server.Minions.Physics
{
    class QuantumSoldierMinion_MultiJumper : QuantumSoldierMinion_Jumper
    {
        public QuantumSoldierMinion_MultiJumper(Game game, Player ownerPlayer)
            : base(game, ownerPlayer)
        {
           
        }


        public override void dealDamage(Damage damage, Player damageDealer, bool notifyPlayer = true)
        {
            if (nextTeleportTime <= 0)
            {
                onJumpStarted();
                nextTeleportTime = NEXT_TELEPORT_COOLDOWN_DEFAULT;
                List<Minion> minionList = new List<Minion>();

                int effectCount = 3;
                foreach (var m in this.position.board.minions)
                {
                    if (m.Value != this && (this.getWorldPosition() - m.Value.getWorldPosition()).magnitude < APPLY_EFFECT_RANGE_DEFAULT)
                    {
                        minionList.Add(m.Value);
                        m.Value.moveCustomDistance(TELEPORT_DISTANCE_DEFAULT);

                        effectCount--;

                        if (effectCount == 0)
                            break;
                    }
                }

                Messages.OutgoingMessages.Game.GMinion_QuantumSoldier_teleport.sendMessage(position.board.player.game.players, this, minionList);
                moveCustomDistance(TELEPORT_DISTANCE_DEFAULT);
                onJumpEnded();
            }
            base.dealDamage(damage, damageDealer, notifyPlayer);
        }

        public override int getUpgradeCost()
        {
            return getCost() * 2;
        }
    }
}
