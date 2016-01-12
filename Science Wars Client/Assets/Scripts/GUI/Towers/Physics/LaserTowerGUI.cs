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
using Assets.Scripts.Engine.Minions;

namespace Assets.Scripts.GUI.Towers
{
	public class LaserTowerGUI : TowerGUIImp
	{
		private static GameObject staticTowerObject;
		private static Texture2D staticTowerIcon;
		private static Texture2D staticTowerInfo;
		private static Projector staticRangeProjector;
        protected static Material rayMaterial;


        private const int _maxLaserCount = 1;
        protected virtual int MAX_LASER_COUNT { get { return _maxLaserCount; } }

        LineDrawer[] lineDrawers;
        Minion[] targetMinions;

        public LaserTowerGUI()
            : base(typeof(LaserTower))	
		{
			if (staticTowerObject != null) 
			{
				childStaticTowerObject = staticTowerObject;
				childStaticTowerIcon = staticTowerIcon;
				childStaticTowerInfo = staticTowerInfo;
				childStaticRangeProjector = staticRangeProjector;
			}
		}

        protected LaserTowerGUI(Type towerType)
            : base(towerType)
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
            return "Focuses a minion and sends laser beams that deal 240 Fire damage per second. This tower will not change its target until the target dies or moves out of range.";
        }

		//assign edilen objeler statik olmali
		public override void loadResources()
		{
			staticTowerObject = (GameObject)Resources.Load("3Ds/Towers/Physics/LaserTower/TowerObject");
            staticTowerIcon = (Texture2D)Resources.Load("3Ds/Towers/Physics/LaserTower/GUI/towerIcon");
            staticCreateSound = (AudioClip)Resources.Load("Sound/tower_build");
            rayMaterial = (Material)Resources.Load("3Ds/Towers/Physics/LaserTower/Materials/laserMat");
			staticRangeProjector = ((GameObject)Resources.Load ("3Ds/Scenes/Game/RangeProjector")).GetComponent<Projector>();

		}

        public override void createTower(Assets.Scripts.Engine.Towers.Tower t)
        {
            base.createTower(t);

            targetMinions = new Minion[MAX_LASER_COUNT];
            lineDrawers = new LineDrawer[MAX_LASER_COUNT];

            for (int i = 0; i < targetMinions.Length; i++)
            {
                GameObject lineHolder = new GameObject("line_"+i);
                lineHolder.transform.parent = towerObject.transform;

                LineRenderer fish = lineHolder.AddComponent<LineRenderer>();
                fish.material = new Material(rayMaterial);
                fish.SetWidth(0.02f, 0.02f);

                lineDrawers[i] = lineHolder.AddComponent<LineDrawer>();
                lineDrawers[i].line = fish;
                lineDrawers[i].visible = false;
                lineDrawers[i].transforms = new Vector3[] { tower.getWorldMissileCreatePosition(), Vector3.zero };

                lineDrawers[i].animationPeriod = 0.15f;
                lineDrawers[i].startColor = new Color(1f, 0f, 0f,0.36f);
                lineDrawers[i].endColor = new Color(0.39f, 0f, 0f, 0.7f);
                
            }
        }

        public override void step()
        {
            if (destroyable == false)
            {
                if (tower.destroyable == true || tower.board.boardState == Board.BoardState.COLLAPSING)
                    destroyTower();
                else
                {
                    towerObject.transform.position = tower.getWorldPosition();

                    for (int i = 0; i < targetMinions.Length; i++)
                    {
                        if (targetMinions[i] != null)
                        {
                            lineDrawers[i].transforms[1] = targetMinions[i].getWorldHeadPosition();
                            lineDrawers[i].visible = true;
                        }
                        else
                        {
                            lineDrawers[i].visible = false;
                        }
                    }
                }
            }
        }

        public void targetMinion(Minion minion)
        {
            for (int i = 0; i < targetMinions.Length; i++)
            {
                if (targetMinions[i] == null)
                {
                    targetMinions[i] = minion;
                    return;
                }
            }
            Debug.Log("LaserTowerGUI: bu lazer kulesi yeni bir hedefe odaklanabilmek icin once varolan hedeflerinden birinden vazgecmeli.");
        }

        public void untargetMinion(int minionId)
        {
            for (int i = 0; i < targetMinions.Length; i++)
            {
                if (targetMinions[i] != null && minionId == targetMinions[i].instanceId)
                {
                    targetMinions[i] = null;
                    return;
                }
            }
            Debug.Log("LaserTowerGUI: untarget islemi basarisiz. Boyle bir hedef zaten yok!");
        }
    }
}

