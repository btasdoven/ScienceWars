using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Science_Wars_Server.Minions;
using Science_Wars_Server.ScienceTrees.ScienceNodes;
using Science_Wars_Server.Towers;
using Science_Wars_Server.GameUtilities;

namespace Science_Wars_Server.ScienceTrees.ScienceNodes.Physics
{
    // TODO: Science Node'dan degil SciencePerson isimli bir classdan inherit etmeli.
    public class Newton : ScienceNode
    {
        public override void unlock(User user)
        {
            user.unlockedTowers[TypeIdGenerator.getTowerId(typeof(Science_Wars_Server.Towers.Physics.CatapultTower))] = true;
            user.unlockedTowers[TypeIdGenerator.getTowerId(typeof(Science_Wars_Server.Towers.Physics.BlackHoleTower))] = true;
            user.unlockedTowers[TypeIdGenerator.getTowerId(typeof(Science_Wars_Server.Towers.Physics.ElectricityTower))] = true;
            user.unlockedTowers[TypeIdGenerator.getTowerId(typeof(Science_Wars_Server.Towers.Physics.TeslaTower))] = true;

            user.unlockedTowers[TypeIdGenerator.getTowerId(typeof(Science_Wars_Server.Towers.Physics.BallistaTower))] = true;
            user.unlockedTowers[TypeIdGenerator.getTowerId(typeof(Science_Wars_Server.Towers.Physics.BallistaTower_fireBolt))] = true;
            user.unlockedTowers[TypeIdGenerator.getTowerId(typeof(Science_Wars_Server.Towers.Physics.BallistaTower_lavaBolt))] = true;

            user.unlockedTowers[TypeIdGenerator.getTowerId(typeof(Science_Wars_Server.Towers.Physics.LaserTower))] = true;
            user.unlockedTowers[TypeIdGenerator.getTowerId(typeof(Science_Wars_Server.Towers.Physics.LaserTower_Twin))] = true;
            user.unlockedTowers[TypeIdGenerator.getTowerId(typeof(Science_Wars_Server.Towers.Physics.LaserTower_Triplet))] = true;
            user.unlockedTowers[TypeIdGenerator.getTowerId(typeof(Science_Wars_Server.Towers.Physics.LaserTower_Quadruplet))] = true;
            user.unlockedTowers[TypeIdGenerator.getTowerId(typeof(Science_Wars_Server.Towers.Physics.LaserTower_Quintuplet))] = true;

            user.unlockedTowers[TypeIdGenerator.getTowerId(typeof(Science_Wars_Server.Towers.Physics.NailTrapTower))] = true;
            user.unlockedTowers[TypeIdGenerator.getTowerId(typeof(Science_Wars_Server.Towers.Physics.NailTrapTower_MoreSlow))] = true;
            user.unlockedTowers[TypeIdGenerator.getTowerId(typeof(Science_Wars_Server.Towers.Physics.NailTrapTower_MoreRange))] = true;

            user.unlockedMinions[TypeIdGenerator.getMinionId(typeof(Science_Wars_Server.Minions.Physics.MirrorSoldierMinion))] = true;

            user.unlockedMinions[TypeIdGenerator.getMinionId(typeof(Science_Wars_Server.Minions.Physics.RoboHookMinion))] = true;
            user.unlockedMinions[TypeIdGenerator.getMinionId(typeof(Science_Wars_Server.Minions.Physics.RoboHookMinion_3sImmune))] = true;
            user.unlockedMinions[TypeIdGenerator.getMinionId(typeof(Science_Wars_Server.Minions.Physics.RoboHookMinion_Further))] = true;

            user.unlockedMinions[TypeIdGenerator.getMinionId(typeof(Science_Wars_Server.Minions.Physics.QuantumSoldierMinion))] = true;
            user.unlockedMinions[TypeIdGenerator.getMinionId(typeof(Science_Wars_Server.Minions.Physics.QuantumSoldierMinion_Fast))] = true;
            user.unlockedMinions[TypeIdGenerator.getMinionId(typeof(Science_Wars_Server.Minions.Physics.QuantumSoldierMinion_Crew))] = true;
            user.unlockedMinions[TypeIdGenerator.getMinionId(typeof(Science_Wars_Server.Minions.Physics.QuantumSoldierMinion_Jumper))] = true;
            user.unlockedMinions[TypeIdGenerator.getMinionId(typeof(Science_Wars_Server.Minions.Physics.QuantumSoldierMinion_MultiJumper))] = true;

            user.unlockedMinions[TypeIdGenerator.getMinionId(typeof(Science_Wars_Server.Minions.Physics.PhysicsMScStudentMinion))] = true;
            user.unlockedMinions[TypeIdGenerator.getMinionId(typeof(Science_Wars_Server.Minions.Physics.PhysicsMScStudentMinion_Cheaper))] = true;
            user.unlockedMinions[TypeIdGenerator.getMinionId(typeof(Science_Wars_Server.Minions.Physics.PhysicsMScStudentMinion_Speedy))] = true;


            user.unlockedMinions[TypeIdGenerator.getMinionId(typeof(Science_Wars_Server.Minions.Physics.RetentiveTankMinion))] = true;

            user.unlockedMinions[TypeIdGenerator.getMinionId(typeof(Science_Wars_Server.Minions.Physics.PhysicsStudentMinion))] = true;
            user.unlockedMinions[TypeIdGenerator.getMinionId(typeof(Science_Wars_Server.Minions.Physics.PhysicsStudentMinion_Successful))] = true;
            user.unlockedMinions[TypeIdGenerator.getMinionId(typeof(Science_Wars_Server.Minions.Physics.PhysicsStudentMinion_Enraged))] = true;

            user.unlockedMinions[TypeIdGenerator.getMinionId(typeof(Science_Wars_Server.Minions.Physics.FrankenScientistMinion))] = true;
            user.unlockedMinions[TypeIdGenerator.getMinionId(typeof(Science_Wars_Server.Minions.Physics.FrankenScientistMinion_OnFire))] = true;
            user.unlockedMinions[TypeIdGenerator.getMinionId(typeof(Science_Wars_Server.Minions.Physics.FrankenScientistMinion_Baked))] = true;
            user.unlockedMinions[TypeIdGenerator.getMinionId(typeof(Science_Wars_Server.Minions.Physics.FrankenScientistMinion_PennyPincher))] = true;
            user.unlockedMinions[TypeIdGenerator.getMinionId(typeof(Science_Wars_Server.Minions.Physics.FrankenScientistMinion_LateWork))] = true;
        }
    }
}
