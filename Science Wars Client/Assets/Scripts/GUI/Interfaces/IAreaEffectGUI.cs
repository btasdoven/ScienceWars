using Assets.Scripts.Engine.AreaEffects;
using Assets.Scripts.Engine.IGUI;
using Assets.Scripts.GUI.ResourceLoaderGUI;
using UnityEngine;

namespace Assets.Scripts.GUI.Interfaces
{
		public interface IAreaEffectGUI : IStep, IRequiresResourceGUI
		{
            void createAreaEffect(AreaEffect areaEffect);
            void destroyAreaEffect();
            bool isDestroyable();
		}
}

