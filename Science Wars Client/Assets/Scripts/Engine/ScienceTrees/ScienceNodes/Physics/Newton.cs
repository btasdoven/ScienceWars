using Assets.Scripts.Engine.GameUtilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts.Engine.ScienceTrees.ScienceNodes.Physics
{
    public class Newton : ScienceNode
    {
        public override void unlock()
        {
			UserMe.unlockedTowers[TypeIdGenerator.getTowerId(typeof(Engine.Towers.Physics.CatapultTower))] = true;
			UserMe.unlockedTowers[TypeIdGenerator.getTowerId(typeof(Engine.Towers.Physics.BlackHoleTower))] = true;
			UserMe.unlockedTowers[TypeIdGenerator.getTowerId(typeof(Engine.Towers.Physics.ElectricityTower))] = true;
			UserMe.unlockedTowers[TypeIdGenerator.getTowerId(typeof(Engine.Towers.Physics.TeslaTower))] = true;

			UserMe.unlockedTowers[TypeIdGenerator.getTowerId(typeof(Engine.Towers.Physics.BallistaTower))] = true;
			UserMe.unlockedTowers[TypeIdGenerator.getTowerId(typeof(Engine.Towers.Physics.BallistaTower_fireBolt))] = true;
			UserMe.unlockedTowers[TypeIdGenerator.getTowerId(typeof(Engine.Towers.Physics.BallistaTower_lavaBolt))] = true;

            UserMe.unlockedTowers[TypeIdGenerator.getTowerId(typeof(Engine.Towers.Physics.LaserTower))] = true;
            UserMe.unlockedTowers[TypeIdGenerator.getTowerId(typeof(Engine.Towers.Physics.LaserTower_Twin))] = true;
            UserMe.unlockedTowers[TypeIdGenerator.getTowerId(typeof(Engine.Towers.Physics.LaserTower_Triplet))] = true;
            UserMe.unlockedTowers[TypeIdGenerator.getTowerId(typeof(Engine.Towers.Physics.LaserTower_Quadruplet))] = true;
            UserMe.unlockedTowers[TypeIdGenerator.getTowerId(typeof(Engine.Towers.Physics.LaserTower_Quintuplet))] = true;

			UserMe.unlockedTowers[TypeIdGenerator.getTowerId(typeof(Engine.Towers.Physics.NailTrapTower))] = true;
			UserMe.unlockedTowers[TypeIdGenerator.getTowerId(typeof(Engine.Towers.Physics.NailTrapTower_MoreSlow))] = true;
			UserMe.unlockedTowers[TypeIdGenerator.getTowerId(typeof(Engine.Towers.Physics.NailTrapTower_MoreRange))] = true;

			UserMe.unlockedMinions[TypeIdGenerator.getMinionId(typeof(Engine.Minions.Physics.MirrorSoldierMinion))] = true;

			UserMe.unlockedMinions[TypeIdGenerator.getMinionId(typeof(Engine.Minions.Physics.QuantumSoldierMinion))] = true;
            UserMe.unlockedMinions[TypeIdGenerator.getMinionId(typeof(Engine.Minions.Physics.QuantumSoldierMinion_Fast))] = true;
            UserMe.unlockedMinions[TypeIdGenerator.getMinionId(typeof(Engine.Minions.Physics.QuantumSoldierMinion_Crew))] = true;
            UserMe.unlockedMinions[TypeIdGenerator.getMinionId(typeof(Engine.Minions.Physics.QuantumSoldierMinion_Jumper))] = true;
            UserMe.unlockedMinions[TypeIdGenerator.getMinionId(typeof(Engine.Minions.Physics.QuantumSoldierMinion_MultiJumper))] = true;

            UserMe.unlockedMinions[TypeIdGenerator.getMinionId(typeof(Engine.Minions.Physics.RoboHookMinion))] = true;
            UserMe.unlockedMinions[TypeIdGenerator.getMinionId(typeof(Engine.Minions.Physics.RoboHookMinion_3sImmune))] = true;
            UserMe.unlockedMinions[TypeIdGenerator.getMinionId(typeof(Engine.Minions.Physics.RoboHookMinion_Further))] = true;

			UserMe.unlockedMinions[TypeIdGenerator.getMinionId(typeof(Engine.Minions.Physics.PhysicsMScStudentMinion))] = true;
            UserMe.unlockedMinions[TypeIdGenerator.getMinionId(typeof(Engine.Minions.Physics.PhysicsMScStudentMinion_Cheaper))] = true;
            UserMe.unlockedMinions[TypeIdGenerator.getMinionId(typeof(Engine.Minions.Physics.PhysicsMScStudentMinion_Speedy))] = true;

			UserMe.unlockedMinions[TypeIdGenerator.getMinionId(typeof(Engine.Minions.Physics.RetentiveTankMinion))] = true;

            UserMe.unlockedMinions[TypeIdGenerator.getMinionId(typeof(Engine.Minions.Physics.PhysicsStudentMinion))] = true;
            UserMe.unlockedMinions[TypeIdGenerator.getMinionId(typeof(Engine.Minions.Physics.PhysicsStudentMinion_Successful))] = true;
            UserMe.unlockedMinions[TypeIdGenerator.getMinionId(typeof(Engine.Minions.Physics.PhysicsStudentMinion_Enraged))] = true;

            UserMe.unlockedMinions[TypeIdGenerator.getMinionId(typeof(Engine.Minions.Physics.FrankenScientistMinion))] = true;
            UserMe.unlockedMinions[TypeIdGenerator.getMinionId(typeof(Engine.Minions.Physics.FrankenScientistMinion_OnFire))] = true;
            UserMe.unlockedMinions[TypeIdGenerator.getMinionId(typeof(Engine.Minions.Physics.FrankenScientistMinion_Baked))] = true;
            UserMe.unlockedMinions[TypeIdGenerator.getMinionId(typeof(Engine.Minions.Physics.FrankenScientistMinion_PennyPincher))] = true;
            UserMe.unlockedMinions[TypeIdGenerator.getMinionId(typeof(Engine.Minions.Physics.FrankenScientistMinion_LateWork))] = true;
		}
    }
}
