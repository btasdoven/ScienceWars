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

namespace Assets.Scripts.GUI.Towers
{
	public class LaserTower_QuadrupletGUI : LaserTower_TripletGUI
	{
        private const int _maxLaserCount = 4;
        protected override int MAX_LASER_COUNT { get { return _maxLaserCount; } }

        public LaserTower_QuadrupletGUI()
            : base(typeof(LaserTower_Quadruplet))	
		{
		}
			
	    protected LaserTower_QuadrupletGUI(Type towerType)
            : base(towerType)
        {
        }

        public override string getInfo()
        {
            return "Focuses up to 4 minions and sends laser beams that deal 240 Fire damage per second. This tower will not change its target until the target dies or moves out of range.";
        }

    }
}

