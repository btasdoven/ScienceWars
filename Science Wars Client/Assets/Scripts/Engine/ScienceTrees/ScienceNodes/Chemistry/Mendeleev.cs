using Assets.Scripts.Engine.GameUtilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts.Engine.ScienceTrees.ScienceNodes.Chemistry
{
	public class Mendeleev : ScienceNode
	{
		public override void unlock()
		{
			UserMe.unlockedTowers[TypeIdGenerator.getTowerId(typeof(Engine.Towers.Chemistry.AcidTower))] = true;
			UserMe.unlockedTowers[TypeIdGenerator.getTowerId(typeof(Engine.Towers.Chemistry.PetrolBombTower))] = true;
			UserMe.unlockedTowers[TypeIdGenerator.getTowerId(typeof(Engine.Towers.Chemistry.NitrogenBombTower))] = true;
			UserMe.unlockedTowers[TypeIdGenerator.getTowerId(typeof(Engine.Towers.Chemistry.RadiationTower))] = true;

            UserMe.unlockedTowers[TypeIdGenerator.getTowerId(typeof(Engine.Towers.Chemistry.TrypanophobiaTower))] = true;
            UserMe.unlockedTowers[TypeIdGenerator.getTowerId(typeof(Engine.Towers.Chemistry.TrypanophobiaTower_Faster))] = true;
            UserMe.unlockedTowers[TypeIdGenerator.getTowerId(typeof(Engine.Towers.Chemistry.TrypanophobiaTower_Scary))] = true;
            UserMe.unlockedTowers[TypeIdGenerator.getTowerId(typeof(Engine.Towers.Chemistry.TrypanophobiaTower_Monstrous))] = true;

			UserMe.unlockedMinions[TypeIdGenerator.getMinionId(typeof(Engine.Minions.Chemistry.CrazyScientistMinion))] = true;

			UserMe.unlockedMinions[TypeIdGenerator.getMinionId(typeof(Engine.Minions.Chemistry.ChemistryStudentMinion))] = true;
            UserMe.unlockedMinions[TypeIdGenerator.getMinionId(typeof(Engine.Minions.Chemistry.ChemistryStudentMinion_Fast))] = true;
            UserMe.unlockedMinions[TypeIdGenerator.getMinionId(typeof(Engine.Minions.Chemistry.ChemistryStudentMinion_Durable))] = true;

			UserMe.unlockedMinions[TypeIdGenerator.getMinionId(typeof(Engine.Minions.Chemistry.ChemLabStudentMinion))] = true;
            UserMe.unlockedMinions[TypeIdGenerator.getMinionId(typeof(Engine.Minions.Chemistry.FoggerMinion))] = true;
			UserMe.unlockedMinions[TypeIdGenerator.getMinionId(typeof(Engine.Minions.Chemistry.FirstAidTentMinion))] = true;
			UserMe.unlockedMinions[TypeIdGenerator.getMinionId(typeof(Engine.Minions.Chemistry.ProtectorMinion))] = true;
		}
	}
}
