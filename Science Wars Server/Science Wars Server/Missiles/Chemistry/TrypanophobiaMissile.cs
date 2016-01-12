using Science_Wars_Server.Effects.MinionEffects;
using Science_Wars_Server.GameUtilities;
using Science_Wars_Server.Minions;
using Science_Wars_Server.Towers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Science_Wars_Server.Missiles.Chemistry
{
    class TrypanophobiaMissile : Missile
    {
        float runBackTime;

        public TrypanophobiaMissile(Tower ownerTower, Minion targetMinion, float runBackTime)
            : base(ownerTower, targetMinion)
        {
            this.runBackTime = runBackTime;
            movementSpeed = 5.0f;
            damageList.Add(new Damage(60, DamageType.PHYSICAL));
        }
        
        public override void step()
        {
            if( chase() )
            {
                foreach (var damage in damageList)
                    targetMinion.dealDamage(damage,ownerTower.board.player);

                TrypanophobiaEffect effect = new TrypanophobiaEffect(runBackTime);
                if (targetMinion.addEffect(effect))
                    Messages.OutgoingMessages.Game.GMinion_Trypanophobia_addEffect.sendMessage(targetMinion.game.players, targetMinion, runBackTime);
                destroyable = true;
            }

        }
    }
}
