using System.Net.Configuration;
using System.Security.Cryptography;
using UnityEngine;
using System.Collections;
using Assets.Scripts.GUI.ResourceLoaderGUI;
using Assets.Scripts.GUI.Interfaces;
using Assets.Scripts.Engine.Minions;
using Assets.Scripts.Engine;
using Assets.Scripts.Engine.Effects.MinionEffects;
using Assets.Scripts.Engine.Minions.Physics;

namespace Assets.Scripts.GUI.Minions    // physics namespace icine koymadim, Activator.Instanciate derken Physics i gostermiyoruz suanda.
{
	public class PhysicsStudentMinion_EnragedGUI : PhysicsStudentMinion_SuccessfulGUI
	{
        public PhysicsStudentMinion_EnragedGUI()
            : base(typeof(PhysicsStudentMinion_Enraged))	
		{
		}

        public override string getInfo()
        {
            return "Enraged physics student is a more durable version of successfull physics student.";
        }

        public override string getUpgradeInfo()
        {
            return "Gains " + makePositiveString("%10") + " resistance aganist all damage types.";
        }

	}
}