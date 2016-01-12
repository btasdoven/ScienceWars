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
    public class LaserTower_TripletGUI : LaserTower_TwinGUI
	{
        private const int _maxLaserCount = 3;
        protected override int MAX_LASER_COUNT { get { return _maxLaserCount; } }

        public LaserTower_TripletGUI()
            : base(typeof(LaserTower_Triplet))	
		{
		}

        protected LaserTower_TripletGUI(Type towerType)
            : base(towerType)
        {

        }

        public override string getInfo()
        {
            return "Focuses up to 3 minions and sends laser beams that deal 240 Fire damage per second. This tower will not change its target until the target dies or moves out of range.";
        }

    }
}

