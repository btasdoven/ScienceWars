using System.Net.Configuration;
using System.Security.Cryptography;
using UnityEngine;
using System.Collections;
using Assets.Scripts.GUI.ResourceLoaderGUI;
using Assets.Scripts.GUI.Interfaces;
using Assets.Scripts.Engine.Minions;
using Assets.Scripts.Engine;
using Assets.Scripts.Engine.Effects.MinionEffects;
using Assets.Scripts.Engine.Minions.Biology;

namespace Assets.Scripts.GUI.Minions
{
	public class ZombieMinionGUI : MinionGUIImp
	{
		private static GameObject staticMinionObject;
		private static Texture2D staticMinionIcon;
		private static Texture2D staticMinionInfo;
		private static Projector staticRangeProjector;

	    public void onMinionRaise()
        {
            foreach (var animation in animations)
            {
                animation.enabled = true;
                animation.CrossFade("walk");
            }
        }
		
		public ZombieMinionGUI() : base(typeof(ZombieMinion))	
		{
			if (staticMinionObject != null) 
			{
				childStaticMinionObject = staticMinionObject;
				childStaticMinionIcon = staticMinionIcon;
				childStaticMinionInfo = staticMinionInfo;
				childStaticRangeProjector = staticRangeProjector;
			}
		}

	    public override void onMinionDied()
	    {
	        base.onMinionDied();
            
            foreach (var animation in animations)
            {
                animation.enabled = true;
                animation.CrossFadeQueued("getup2",0f, QueueMode.CompleteOthers).speed = 3f;
            }
	    }

	    public override float walkAnimationSpeedMultiplier()
	    {
	        return 4.0f;
	    }

	    public override void loadResources ()
		{
			staticMinionObject = (GameObject)Resources.Load("3Ds/Minions/Biology/ZombieMinion/MinionObject"); 
			staticMinionIcon = Resources.Load<Texture2D>("3Ds/Minions/Biology/ZombieMinion/GUI/minionIcon");
			staticRangeProjector = ((GameObject)Resources.Load ("3Ds/Scenes/Game/RangeProjector")).GetComponent<Projector>();
		}
		
		
	}
}