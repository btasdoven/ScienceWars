using Assets.Scripts.Engine.IGUI;
using Assets.Scripts.GUI.ResourceLoaderGUI;

namespace Assets.Scripts.GUI.Interfaces
{
    public interface IBoardGUI : IStep, IRequiresResourceGUI
	{
        void createBoard(Assets.Scripts.Engine.Board board);
        void destroyBoard();
        bool isDestroyable();
	}
}

