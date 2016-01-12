using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Science_Wars_Server.Helpers;
using Science_Wars_Server.GameUtilities;

namespace Science_Wars_Server.Effects.MinionEffects
{
    class AcidOverTimeEffect : MinionEffect
    {
        public static float DAMAGE_OVER_1_SEC = 7.0f;
        public static DamageType damageType = DamageType.POISON;

        public AcidOverTimeEffect(Player ownerPlayer)
        {
            remainingTime = 5.0f;
            this.ownerPlayer = ownerPlayer;
        }

        public override void step(Minions.Minion minion)
        {
            minion.dealDamage(new Damage(DAMAGE_OVER_1_SEC * Chronos.deltaTime, damageType),ownerPlayer, false);
        }

        public override bool isStackable()
        {
            return true;
        }
        
    }
}
