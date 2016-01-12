using System;
using Assets.Scripts.GUI.Interfaces;
using Assets.Scripts.GUI.ResourceLoaderGUI;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using Assets.Scripts.Engine;
using Assets.Scripts.GUI;
using Assets.Scripts.Engine.Towers.Physics;
using Assets.Scripts.Engine.Towers.Biology;


namespace Assets.Scripts.GUI.Towers
{
	public class SeedTowerGUI : TowerGUIImp
	{
		private static GameObject staticTowerObject;
		private static Texture2D staticTowerIcon ;
		private static Texture2D staticTowerInfo;
		private static Projector staticRangeProjector;
		
		public SeedTowerGUI() : base(typeof(SeedTower))	
		{
			if (staticTowerObject != null) 
			{
				childStaticTowerObject = staticTowerObject;
				childStaticTowerIcon = staticTowerIcon;
				childStaticTowerInfo = staticTowerInfo;
				childStaticRangeProjector = staticRangeProjector;
			}
		}

        public override string getInfo()
        {
            return "This tower has a seed stack with a limited size and the seeds create plants for a time.";
        }

		public override void step()
		{
			if(destroyable == false)
			{
				if (tower.destroyable == true || tower.board.boardState == Board.BoardState.COLLAPSING)
					destroyTower();
				else {
					towerObject.transform.position = tower.getWorldPosition();//board.getTowerPosition(tower.indexOnBoard);

					// TODO kac seed kaldigini goster.
				}
			}
		}

		//assign edilen objeler statik olmali
		public override void loadResources()
		{
            staticTowerObject = (GameObject)Resources.Load("3Ds/Towers/Biology/SeedTower/TowerObject");
            staticTowerIcon = Resources.Load<Texture2D>("3Ds/Towers/Biology/SeedTower/GUI/towerIcon");
			staticRangeProjector = ((GameObject)Resources.Load ("3Ds/Scenes/Game/RangeProjector")).GetComponent<Projector>();
            staticCreateSound = (AudioClip)Resources.Load("Sound/tower_build");
		}
	}
}

