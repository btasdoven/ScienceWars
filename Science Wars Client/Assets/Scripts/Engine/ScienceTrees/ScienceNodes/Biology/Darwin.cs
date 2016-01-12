using Assets.Scripts.Engine.GameUtilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts.Engine.ScienceTrees.ScienceNodes.Biology
{
	public class Darwin : ScienceNode
	{
		public override void unlock()
		{
			UserMe.unlockedTowers[TypeIdGenerator.getTowerId(typeof(Engine.Towers.Biology.ContagiousTower))] = true;
			UserMe.unlockedTowers[TypeIdGenerator.getTowerId(typeof(Engine.Towers.Biology.ContagiousTower_extra))] = true;
			UserMe.unlockedTowers[TypeIdGenerator.getTowerId(typeof(Engine.Towers.Biology.ContagiousTower_effective))] = true;

			UserMe.unlockedTowers[TypeIdGenerator.getTowerId(typeof(Engine.Towers.Biology.DroseraTower))] = true;
			UserMe.unlockedTowers[TypeIdGenerator.getTowerId(typeof(Engine.Towers.Biology.DroseraTower_crazy))] = true;
			UserMe.unlockedTowers[TypeIdGenerator.getTowerId(typeof(Engine.Towers.Biology.DroseraTower_hungry))] = true;
			UserMe.unlockedTowers[TypeIdGenerator.getTowerId(typeof(Engine.Towers.Biology.DroseraTower_insane))] = true;
			UserMe.unlockedTowers[TypeIdGenerator.getTowerId(typeof(Engine.Towers.Biology.DroseraTower_starving))] = true;

			UserMe.unlockedTowers[TypeIdGenerator.getTowerId(typeof(Engine.Towers.Biology.OneToAllTower))] = true;
			UserMe.unlockedTowers[TypeIdGenerator.getTowerId(typeof(Engine.Towers.Biology.OneToAllTower_toxic))] = true;
			UserMe.unlockedTowers[TypeIdGenerator.getTowerId(typeof(Engine.Towers.Biology.OneToAllTower_strong))] = true;

			UserMe.unlockedTowers[TypeIdGenerator.getTowerId(typeof(Engine.Towers.Biology.SeedTower))] = true;
			UserMe.unlockedTowers[TypeIdGenerator.getTowerId(typeof(Engine.Towers.Biology.SeedTower_2Target))] = true;
			UserMe.unlockedTowers[TypeIdGenerator.getTowerId(typeof(Engine.Towers.Biology.SeedTower_7Stack))] = true;

			UserMe.unlockedMinions[TypeIdGenerator.getMinionId(typeof(Engine.Minions.Biology.DollyMinion))] = true;
            UserMe.unlockedMinions[TypeIdGenerator.getMinionId(typeof(Engine.Minions.Biology.DollyMinion_Lesscd))] = true;
            UserMe.unlockedMinions[TypeIdGenerator.getMinionId(typeof(Engine.Minions.Biology.DollyMinion_Pack))] = true;

            UserMe.unlockedMinions[TypeIdGenerator.getMinionId(typeof(Engine.Minions.Biology.ImmortalStarfishMinion))] = true;
            UserMe.unlockedMinions[TypeIdGenerator.getMinionId(typeof(Engine.Minions.Biology.ImmortalStarfishMinion_Loyal))] = true;
            UserMe.unlockedMinions[TypeIdGenerator.getMinionId(typeof(Engine.Minions.Biology.ImmortalStarfishMinion_FastLoyal))] = true;
            UserMe.unlockedMinions[TypeIdGenerator.getMinionId(typeof(Engine.Minions.Biology.ImmortalStarfishMinion_Durable))] = true;
            UserMe.unlockedMinions[TypeIdGenerator.getMinionId(typeof(Engine.Minions.Biology.ImmortalStarfishMinion_Strong))] = true;

			UserMe.unlockedMinions[TypeIdGenerator.getMinionId(typeof(Engine.Minions.Biology.BiologyStudentMinion))] = true;
            UserMe.unlockedMinions[TypeIdGenerator.getMinionId(typeof(Engine.Minions.Biology.BiologyStudentMinion_Faster))] = true;
            UserMe.unlockedMinions[TypeIdGenerator.getMinionId(typeof(Engine.Minions.Biology.BiologyStudentMinion_Durable))] = true;

			UserMe.unlockedMinions[TypeIdGenerator.getMinionId(typeof(Engine.Minions.Biology.BioLabStudentMinion))] = true;
            UserMe.unlockedMinions[TypeIdGenerator.getMinionId(typeof(Engine.Minions.Biology.BioLabStudentMinion_Dangerous))] = true;
            UserMe.unlockedMinions[TypeIdGenerator.getMinionId(typeof(Engine.Minions.Biology.BioLabStudentMinion_Shielded))] = true;

			UserMe.unlockedMinions[TypeIdGenerator.getMinionId(typeof(Engine.Minions.Biology.ZombieMinion))] = true;

            UserMe.unlockedMinions[TypeIdGenerator.getMinionId(typeof(Engine.Minions.Biology.MutantEightLeggedMinion))] = true;
            UserMe.unlockedMinions[TypeIdGenerator.getMinionId(typeof(Engine.Minions.Biology.MutantEightLeggedMinion_Fertile))] = true;
            UserMe.unlockedMinions[TypeIdGenerator.getMinionId(typeof(Engine.Minions.Biology.MutantEightLeggedMinion_WellFed))] = true;
		}
	}
}
