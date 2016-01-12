using Assets.Scripts.Engine.AreaEffects;
using Assets.Scripts.GUI.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts.GUI.AreaEffects
{
	class RadiationTowerAreaEffectGUI : IAreaEffectGUI
	{
		private static GameObject staticAreaEffectObject;
		
		private GameObject fogObject;
		private bool destroyable = false;
		
		private AreaEffect areaEffect;
		
		public void createAreaEffect(AreaEffect areaEffect)
		{
			fogObject = (GameObject)GameObject.Instantiate(staticAreaEffectObject, areaEffect.getWorldPosition(), Quaternion.identity);
			this.areaEffect = areaEffect;
		}
		
		public void destroyAreaEffect()
		{            
			if(fogObject != null)
				GameObject.Destroy(fogObject);
		}
		
		public bool isDestroyable()
		{
			return destroyable;
		}
		
		public void step()
		{
			if (areaEffect != null && areaEffect.destroyable)
			{
				destroyable = true;
				destroyAreaEffect();
			}         
		}
		
		public void loadResources()
		{
			staticAreaEffectObject = (GameObject)Resources.Load("3Ds/AreaEffects/RadiationTowerAreaEffect/AreaEffectObject");
		}
	}
}
