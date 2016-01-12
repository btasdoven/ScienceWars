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

namespace Science_Wars_Server.Missiles.Biology
{
    class ContagiousMissile : Missile
    {
        public ContagiousMissile(Tower ownerTower, Minion targetMinion) : base(ownerTower, targetMinion)
        {
            movementSpeed = 5;
            damageList.Add(new Damage(0, DamageType.FIRE));
            movementSpeed = 3.0f;
        }

        public override void step()
        {
            if (chase())
            {
                foreach (var damage in damageList)
                    targetMinion.dealDamage(damage,ownerTower.board.player);

                MinionEffect contagiousEffect = getMinionEffect(ownerTower.board.player);
                if (targetMinion.addEffect(contagiousEffect))
                    Messages.OutgoingMessages.Game.GAddEffectOnMinion.sendMessage(targetMinion.game.players, targetMinion, contagiousEffect);
                destroyable = true;
            }

        }

        protected virtual MinionEffect getMinionEffect(Player p)
        {
            return new ContagiousEffect(p);
        }
    }
}
