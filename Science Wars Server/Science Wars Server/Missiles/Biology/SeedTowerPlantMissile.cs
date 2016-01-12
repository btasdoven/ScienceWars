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
    public class SeedTowerPlantMissile : Missile
    {
        public Vector3 startWorldPosition;

        public SeedTowerPlantMissile(Tower ownerTower, Vector3 startWorldPosition, Minion targetMinion) 
            : base(startWorldPosition, ownerTower, targetMinion)
        {
            this.startWorldPosition = startWorldPosition;
            movementSpeed = 5.0f;
            damageList.Add(new Damage(50, DamageType.FIRE));
        }

        public override void step()
        {
            if (chase())
            {
                foreach (var damage in damageList)
                    targetMinion.dealDamage(damage, ownerTower.board.player);
                destroyable = true;
            }
        }
    }
}
