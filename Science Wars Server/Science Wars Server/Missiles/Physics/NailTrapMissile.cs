using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Science_Wars_Server.Effects.MinionEffects;
using Science_Wars_Server.GameUtilities;
using Science_Wars_Server.Helpers;
using Science_Wars_Server.Minions;
using Science_Wars_Server.Towers;
using Science_Wars_Server.AreaEffects;

namespace Science_Wars_Server.Missiles.Physics
{
    public class NailTrapMissile : Missile
    {

        Vector3 targetPosition = new Vector3();
        Boards.Board targetBoard;
        // determin
        public float slowAmount = 0.75f;
        public float dmgPerSecond = 30.0f;

        public NailTrapMissile(Tower ownerTower, Minion targetMinion,float slowAmount,float dmgPerSecond)
            : base(ownerTower, targetMinion)
        {
            movementSpeed = 50.0f;
            damageList.Add(new Damage(0, DamageType.POISON));
            targetPosition = targetMinion.getWorldPosition();
            targetBoard = targetMinion.position.board;
            this.slowAmount = slowAmount;
            this.dmgPerSecond = dmgPerSecond;
        }

        public override void step()
        {
            if (chase())
            {
                NailTrapAreaEffect areaEffect = new NailTrapAreaEffect(ownerTower.board.player, targetPosition,slowAmount,dmgPerSecond);
                Messages.OutgoingMessages.Game.GAddNailTrapAreaEffect.sendMessage(ownerTower.board.player.game.players, areaEffect);
                targetBoard.player.game.addAreaEffect(areaEffect);
                destroyable = true;
            }

        }


        public bool chase()
        {
            Vector3 minionPos = targetPosition;
            float distanceToWalk = movementSpeed * Chronos.deltaTime;

            float currentDistance = (minionPos - position).magnitude;

            if (currentDistance <= distanceToWalk)
            {
                position = minionPos;
                return true;
            }

            position += (minionPos - position).normalized * distanceToWalk;
            return false;
        }
    }
}
