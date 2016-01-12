using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts.Engine.GameUtilities
{
    public class Damage
    {
        public float amount;
        public DamageType damageType;

        public Damage(float amount, DamageType damageType)
        {
            this.amount = amount;
            this.damageType = damageType;
        }
    }
}
