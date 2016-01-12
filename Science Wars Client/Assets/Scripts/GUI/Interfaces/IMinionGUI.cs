using Assets.Scripts.Engine.Effects.TowerEffects;
using Assets.Scripts.Engine.IGUI;
using Assets.Scripts.Engine.Minions;
using Assets.Scripts.GUI.ResourceLoaderGUI;
using Assets.Scripts.GUI.Graphics;
using UnityEngine;
using Assets.Scripts.Engine.Effects.MinionEffects;

namespace Assets.Scripts.GUI.Interfaces
{
    public interface IMinionGUI : IStep, IRequiresResourceGUI
	{
		void createMinion(Minion minion);
        void addEffect(MinionEffect effect);        
        void destroyMinion();
        void onMinionDied();
		void onMinionSelected();
		void onMinionUnselected();

        /// <summary>
        /// bu metod sadece bu GUI nin isi tamamen bittigi zaman true donmeli. Bu metod true dondukten sonra hicbir metod cagirilamayacak.
        /// </summary>
        /// <returns></returns>
        bool isDestroyable();

		void drawCreateMinionButtonGUI(GameObject button);
        void drawInfoPanelGUI();
        void drawUpgradeInfoPanelGUI(Rect rectangle);

        string getInfo();
        string getUpgradeInfo();
	}
}

