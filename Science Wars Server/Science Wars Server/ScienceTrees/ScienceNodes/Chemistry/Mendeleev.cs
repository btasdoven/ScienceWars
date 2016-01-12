using System;
using Science_Wars_Server.GameUtilities;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Science_Wars_Server.ScienceTrees.ScienceNodes.Chemistry
{
    class Mendeleev : ScienceNode
    {
        public override void unlock(User user)
        {
            user.unlockedTowers[TypeIdGenerator.getTowerId(typeof(Science_Wars_Server.Towers.Chemistry.AcidTower))] = true;
            user.unlockedTowers[TypeIdGenerator.getTowerId(typeof(Science_Wars_Server.Towers.Chemistry.PetrolBombTower))] = true;
            user.unlockedTowers[TypeIdGenerator.getTowerId(typeof(Science_Wars_Server.Towers.Chemistry.NitrogenBombTower))] = true;
            user.unlockedTowers[TypeIdGenerator.getTowerId(typeof(Science_Wars_Server.Towers.Chemistry.RadiationTower))] = true;

            user.unlockedTowers[TypeIdGenerator.getTowerId(typeof(Science_Wars_Server.Towers.Chemistry.TrypanophobiaTower))] = true;
            user.unlockedTowers[TypeIdGenerator.getTowerId(typeof(Science_Wars_Server.Towers.Chemistry.TrypanophobiaTower_Faster))] = true;
            user.unlockedTowers[TypeIdGenerator.getTowerId(typeof(Science_Wars_Server.Towers.Chemistry.TrypanophobiaTower_Scary))] = true;
            user.unlockedTowers[TypeIdGenerator.getTowerId(typeof(Science_Wars_Server.Towers.Chemistry.TrypanophobiaTower_Monstrous))] = true;

            user.unlockedMinions[TypeIdGenerator.getMinionId(typeof(Science_Wars_Server.Minions.Chemistry.CrazyScientistMinion))] = true;
            user.unlockedMinions[TypeIdGenerator.getMinionId(typeof(Science_Wars_Server.Minions.Chemistry.ChemistryStudentMinion_Fast))] = true;
            user.unlockedMinions[TypeIdGenerator.getMinionId(typeof(Science_Wars_Server.Minions.Chemistry.ChemistryStudentMinion_Durable))] = true;

            user.unlockedMinions[TypeIdGenerator.getMinionId(typeof(Science_Wars_Server.Minions.Chemistry.ChemLabStudentMinion))] = true;
            user.unlockedMinions[TypeIdGenerator.getMinionId(typeof(Science_Wars_Server.Minions.Chemistry.ChemistryStudentMinion))] = true;
            user.unlockedMinions[TypeIdGenerator.getMinionId(typeof(Science_Wars_Server.Minions.Chemistry.FoggerMinion))] = true;
            user.unlockedMinions[TypeIdGenerator.getMinionId(typeof(Science_Wars_Server.Minions.Chemistry.FirstAidTentMinion))] = true;
            user.unlockedMinions[TypeIdGenerator.getMinionId(typeof(Science_Wars_Server.Minions.Chemistry.ProtectorMinion))] = true;

        }
    }
}
