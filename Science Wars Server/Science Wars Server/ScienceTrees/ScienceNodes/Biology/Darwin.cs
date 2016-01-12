using System;
using Science_Wars_Server.GameUtilities;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Science_Wars_Server.ScienceTrees.ScienceNodes.Biology
{
    class Darwin : ScienceNode
    {
        public override void unlock(User user)
        {
            user.unlockedTowers[TypeIdGenerator.getTowerId(typeof(Science_Wars_Server.Towers.Biology.ContagiousTower))] = true;
            user.unlockedTowers[TypeIdGenerator.getTowerId(typeof(Science_Wars_Server.Towers.Biology.ContagiousTower_extra))] = true;
            user.unlockedTowers[TypeIdGenerator.getTowerId(typeof(Science_Wars_Server.Towers.Biology.ContagiousTower_effective))] = true;

            user.unlockedTowers[TypeIdGenerator.getTowerId(typeof(Science_Wars_Server.Towers.Biology.DroseraTower))] = true;
            user.unlockedTowers[TypeIdGenerator.getTowerId(typeof(Science_Wars_Server.Towers.Biology.DroseraTower_crazy))] = true;
            user.unlockedTowers[TypeIdGenerator.getTowerId(typeof(Science_Wars_Server.Towers.Biology.DroseraTower_hungry))] = true;
            user.unlockedTowers[TypeIdGenerator.getTowerId(typeof(Science_Wars_Server.Towers.Biology.DroseraTower_starving))] = true;
            user.unlockedTowers[TypeIdGenerator.getTowerId(typeof(Science_Wars_Server.Towers.Biology.DroseraTower_insane))] = true;

            user.unlockedTowers[TypeIdGenerator.getTowerId(typeof(Science_Wars_Server.Towers.Biology.SeedTower))] = true;
            user.unlockedTowers[TypeIdGenerator.getTowerId(typeof(Science_Wars_Server.Towers.Biology.SeedTower_7Stack))] = true;
            user.unlockedTowers[TypeIdGenerator.getTowerId(typeof(Science_Wars_Server.Towers.Biology.SeedTower_2Target))] = true;


            user.unlockedTowers[TypeIdGenerator.getTowerId(typeof(Science_Wars_Server.Towers.Biology.OneToAllTower))] = true;
            user.unlockedTowers[TypeIdGenerator.getTowerId(typeof(Science_Wars_Server.Towers.Biology.OneToAllTower_strong))] = true;
            user.unlockedTowers[TypeIdGenerator.getTowerId(typeof(Science_Wars_Server.Towers.Biology.OneToAllTower_toxic))] = true;

            user.unlockedMinions[TypeIdGenerator.getMinionId(typeof(Science_Wars_Server.Minions.Biology.DollyMinion))] = true;
            user.unlockedMinions[TypeIdGenerator.getMinionId(typeof(Science_Wars_Server.Minions.Biology.DollyMinion_Lesscd))] = true;
            user.unlockedMinions[TypeIdGenerator.getMinionId(typeof(Science_Wars_Server.Minions.Biology.DollyMinion_Pack))] = true;

            user.unlockedMinions[TypeIdGenerator.getMinionId(typeof(Science_Wars_Server.Minions.Biology.ImmortalStarfishMinion))] = true;
            user.unlockedMinions[TypeIdGenerator.getMinionId(typeof(Science_Wars_Server.Minions.Biology.ImmortalStarfishMinion_Loyal))] = true;
            user.unlockedMinions[TypeIdGenerator.getMinionId(typeof(Science_Wars_Server.Minions.Biology.ImmortalStarfishMinion_FastLoyal))] = true;
            user.unlockedMinions[TypeIdGenerator.getMinionId(typeof(Science_Wars_Server.Minions.Biology.ImmortalStarfishMinion_Durable))] = true;
            user.unlockedMinions[TypeIdGenerator.getMinionId(typeof(Science_Wars_Server.Minions.Biology.ImmortalStarfishMinion_Strong))] = true;

            user.unlockedMinions[TypeIdGenerator.getMinionId(typeof(Science_Wars_Server.Minions.Biology.BiologyStudentMinion))] = true;
            user.unlockedMinions[TypeIdGenerator.getMinionId(typeof(Science_Wars_Server.Minions.Biology.BiologyStudentMinion_Faster))] = true;
            user.unlockedMinions[TypeIdGenerator.getMinionId(typeof(Science_Wars_Server.Minions.Biology.BiologyStudentMinion_Durable))] = true;

            user.unlockedMinions[TypeIdGenerator.getMinionId(typeof(Science_Wars_Server.Minions.Biology.BioLabStudentMinion))] = true;
            user.unlockedMinions[TypeIdGenerator.getMinionId(typeof(Science_Wars_Server.Minions.Biology.BioLabStudentMinion_Shielded))] = true;
            user.unlockedMinions[TypeIdGenerator.getMinionId(typeof(Science_Wars_Server.Minions.Biology.BioLabStudentMinion_Dangerous))] = true;

            user.unlockedMinions[TypeIdGenerator.getMinionId(typeof(Science_Wars_Server.Minions.Biology.ZombieMinion))] = true;

            user.unlockedMinions[TypeIdGenerator.getMinionId(typeof(Science_Wars_Server.Minions.Biology.MutantEightLeggedMinion))] = true;
            user.unlockedMinions[TypeIdGenerator.getMinionId(typeof(Science_Wars_Server.Minions.Biology.MutantEightLeggedMinion_Fertile))] = true;
            user.unlockedMinions[TypeIdGenerator.getMinionId(typeof(Science_Wars_Server.Minions.Biology.MutantEightLeggedMinion_WellFed))] = true;
        }
    }
}
