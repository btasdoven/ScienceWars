using System;
using Assets.Scripts.GUI.Interfaces;
using Assets.Scripts.GUI.ResourceLoaderGUI;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using Assets.Scripts.Engine;
using Assets.Scripts.GUI;
using Assets.Scripts.Engine.Towers.Biology;
using Assets.Scripts.Engine.Minions;

namespace Assets.Scripts.GUI.Towers
{
	public class DroseraTower_starvingGUI : DroseraTower_hungryGUI
	{
		public DroseraTower_starvingGUI()
			: base(typeof(DroseraTower_starving))	
		{
		}
		
		protected DroseraTower_starvingGUI(Type towerType)
			: base(towerType)
		{
		}
		
		public override string getUpgradeInfo()
		{
			return "Now, drosera can eat minions have maximum" + makePositiveString("750") + " health";
		}
		
		public override string getInfo()
		{
			return "This gigantic plant can eat any minion have lifepoint less than 750 and consume it over 120 health per second. After digestion it is ready to attack again!";
		}
	}
}

