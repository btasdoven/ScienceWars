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
using System;

namespace Assets.Scripts.GUI.Minions    // physics namespace icine koymadim, Activator.Instanciate derken Physics i gostermiyoruz suanda.
{
	public class QuantumSoldierMinionGUI : MinionGUIImp
    {

		private static GameObject staticMinionObject;
		private static Texture2D staticMinionIcon;
		private static Texture2D staticMinionInfo;
		private static Projector staticRangeProjector;

        private Sprite teleportAnimation;

		public QuantumSoldierMinionGUI() : base(typeof(QuantumSoldierMinion))	
		{
			if (staticMinionObject != null) 
			{
				childStaticMinionObject = staticMinionObject;
				childStaticMinionIcon = staticMinionIcon;
				childStaticMinionInfo = staticMinionInfo;
				childStaticRangeProjector = staticRangeProjector;
			}
		}

        public QuantumSoldierMinionGUI(Type minionType)
            : base(minionType)
        {
            if (staticMinionObject != null)
            {
                childStaticMinionObject = staticMinionObject;
                childStaticMinionIcon = staticMinionIcon;
                childStaticMinionInfo = staticMinionInfo;
                childStaticRangeProjector = staticRangeProjector;
            }
        }

        public override void createMinion(Minion minion)
        {
            base.createMinion(minion);

            teleportAnimation = minionObject.GetComponentInChildren<Sprite>() as Sprite;            
        }

        public override string getInfo()
        {
            return "Quantum Solider teleports himself to 130 range forward when he tooks damage every 12 seconds.";
        }

        public override string getUpgradeInfo()
        {
            return "";
        }

        public void teleport()
        {
            teleportAnimation.isPaused = false;
        }

		#region IRequiresResourceGUI implementation

		public override void loadResources ()
		{
			staticMinionObject = (GameObject)Resources.Load("3Ds/Minions/Physics/QuantumSoldierMinion/MinionObject");
			staticMinionIcon = Resources.Load<Texture2D>("3Ds/Minions/Physics/QuantumSoldierMinion/GUI/minionIcon");
			staticRangeProjector = ((GameObject)Resources.Load ("3Ds/Scenes/Game/RangeProjector")).GetComponent<Projector>();
		}

		#endregion

	    
    }
}