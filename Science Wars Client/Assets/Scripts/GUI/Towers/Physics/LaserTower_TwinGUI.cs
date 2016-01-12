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
    public class LaserTower_TwinGUI : LaserTowerGUI
	{
        private const int _maxLaserCount = 2;
        protected override int MAX_LASER_COUNT { get { return _maxLaserCount; } }

        public LaserTower_TwinGUI()
            : base(typeof(LaserTower_Twin))	
		{
		}

        protected LaserTower_TwinGUI(Type towerType)
            : base(towerType)
        {
        }

        public override string getInfo()
        {
            return "Focuses up to 2 minions and sends laser beams that deal 240 Fire damage per second. This tower will not change its target until the target dies or moves out of range.";
        }
    }
}

