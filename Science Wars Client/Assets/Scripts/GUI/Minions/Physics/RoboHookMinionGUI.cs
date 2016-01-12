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
	public class RoboHookMinionGUI : MinionGUIImp
    {

		private static GameObject staticMinionObject;
		private static Texture2D staticMinionIcon;
		private static Texture2D staticMinionInfo;
		private static Projector staticRangeProjector;

        RoboHookMinion roboHookMinion;
        LineDrawer lineDrawer;

		public RoboHookMinionGUI() : base(typeof(RoboHookMinion))	
		{
			if (staticMinionObject != null) 
			{
				childStaticMinionObject = staticMinionObject;
				childStaticMinionIcon = staticMinionIcon;
				childStaticMinionInfo = staticMinionInfo;
				childStaticRangeProjector = staticRangeProjector;
			}
		}

        public RoboHookMinionGUI(Type minionType) // upgradeler bunu cagirabilsin diye
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

        public override string getInfo()
        {
            return "Robo Hook hooks himself another minion who is in front of him in 100 range every 5 seconds.";
        }

        public override string getUpgradeInfo()
        {
            return "";
        }

        public override void createMinion(Minion minion)
        {
            base.createMinion(minion);
            lineDrawer = minionObject.GetComponentInChildren<LineDrawer>() as LineDrawer;
            roboHookMinion = (RoboHookMinion)minion;    // parent tutuyor aslinda minionu, ama ben surekli RoboHookMinon a cast etmek istemiyorum. hazir cast edilmisini elimde tutacagim.
        }

        public override void step()
        {
            base.step();

            Minion hooked = roboHookMinion.hookedMinion;

            if (hooked == null)
            {
                lineDrawer.visible = false;
                
                foreach (var animation in animations)
                    if (animation.enabled == false)
                        animation.enabled = true;
            }
            else
            {
                lineDrawer.transforms = new Vector3[] { roboHookMinion.getWorldPosition() + new Vector3(0, 0.15f, 0), hooked.getWorldPosition() + new Vector3(0, 0.15f, 0) };
                lineDrawer.visible = true;
                foreach( var animation in animations)
                if (animation.enabled == true)
                    animation.enabled = false;
            }
        }
		#region IRequiresResourceGUI implementation

		public override void loadResources ()
		{
			staticMinionObject = (GameObject)Resources.Load("3Ds/Minions/Physics/RoboHookMinion/MinionObject");
			staticMinionIcon = Resources.Load<Texture2D>("3Ds/Minions/Physics/RoboHookMinion/GUI/minionIcon");
			staticRangeProjector = ((GameObject)Resources.Load ("3Ds/Scenes/Game/RangeProjector")).GetComponent<Projector>();
		}

		#endregion

	  
    }
}