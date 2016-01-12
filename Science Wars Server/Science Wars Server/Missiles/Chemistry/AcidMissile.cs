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

namespace Science_Wars_Server.Missiles.Chemistry
{
    class AcidMissile : Missile
    {
        public AcidMissile(Tower ownerTower, Minion targetMinion) : base(ownerTower, targetMinion)
        {
            movementSpeed = 5.0f;
            damageList.Add(new Damage(0, DamageType.POISON));
        }
        
        public override void step()
        {
            if( chase() )
            {
                foreach (var damage in damageList)
                    targetMinion.dealDamage(damage, ownerTower.board.player);

                AcidOverTimeEffect acidEffect = new AcidOverTimeEffect(ownerTower.board.player);
                if (targetMinion.addEffect(acidEffect))
                    Messages.OutgoingMessages.Game.GAddEffectOnMinion.sendMessage(targetMinion.game.players, targetMinion, acidEffect);
                destroyable = true;
            }

        }
    }
}
