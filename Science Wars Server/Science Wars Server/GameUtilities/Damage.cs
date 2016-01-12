
namespace Science_Wars_Server.GameUtilities
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
