using Assets.Scripts.Engine.Effects.TowerEffects;
using Assets.Scripts.Engine.IGUI;
using Assets.Scripts.Engine.Towers;
using Assets.Scripts.GUI.ResourceLoaderGUI;
using UnityEngine;

namespace Assets.Scripts.GUI.Interfaces
{
	public interface ITowerGUI : IStep, IRequiresResourceGUI
	{
    	void createTower(Tower t);
        void addEffect(ITowerEffect effect);
        void destroyTower();
		void onTowerSelected();
		void onTowerUnselected();

        /// <summary>
        /// bu metod sadece bu GUI nin isi tamamen bittigi zaman true donmeli. Bu metod true dondukten sonra hicbir metod cagirilamayacak.
        /// </summary>
        /// <returns></returns>
        bool isDestroyable();
       
        /// <summary>
        /// Kullanicinin kule yapmak icin tikladigi GUI butonunu cizdir. MonoBehaviour.onGUI() metodu icinde cagirildigi icin UnityEngine.GUI classina ait metodlari bu metodun implementasyonunda kullanabilirsiniz.
        /// </summary>
		void drawCreateTowerButtonGUI(GameObject button);
		void drawInfoPanelGUI();
        void drawUpgradeInfoPanelGUI(Rect rectangle);

        string getInfo();
        string getUpgradeInfo();

        Tower getTower();
	}
}

