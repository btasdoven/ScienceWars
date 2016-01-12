using System.Security.Cryptography.X509Certificates;
using Assets.Scripts.Engine.IGUI;
using Assets.Scripts.Engine.Missiles;
using Assets.Scripts.GUI.ResourceLoaderGUI;

namespace Assets.Scripts.GUI.Interfaces
{
    public interface IMissileGUI : IStep, IRequiresResourceGUI
	{
		void createMissile(Missile missile);
        void destroyMissile();
        bool isDestroyable();
	}
}

