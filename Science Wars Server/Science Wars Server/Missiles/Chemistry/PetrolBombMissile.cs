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

namespace Science_Wars_Server.Missiles.Chemistry
{
    class PetrolBombMissile : Missile
    {

        Vector3 targetPosition = new Vector3();
        Boards.Board targetBoard;
        
        public PetrolBombMissile(Tower ownerTower, Minion targetMinion) : base(ownerTower, targetMinion)
        {
            movementSpeed = 5.0f;
            damageList.Add(new Damage(0, DamageType.POISON));
            targetPosition = targetMinion.getWorldPosition();
            targetBoard = targetMinion.position.board;
        }

        public override void step()
        {
            if (chase())
            {
                AreaEffect areaEffect = new PetrolBombAreaEffect(ownerTower.board.player, targetPosition);
                Messages.OutgoingMessages.Game.GAddAreaEffect.sendMessage(ownerTower.board.player.game.players, areaEffect);
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
