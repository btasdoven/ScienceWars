﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Science_Wars_Server.GameUtilities;
using Science_Wars_Server.Helpers;
using Science_Wars_Server.Minions;
using Science_Wars_Server.Towers;

namespace Science_Wars_Server.Missiles.Physics
{
    class Ballista_fireBoltMissile : Missile
    {
        public Ballista_fireBoltMissile(Tower ownerTower, Minion targetMinion)
            : base(ownerTower, targetMinion)
        {
            movementSpeed = 3.0f;
            damageList.Add(new Damage(25, DamageType.PHYSICAL));
            damageList.Add(new Damage(25, DamageType.FIRE));
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
