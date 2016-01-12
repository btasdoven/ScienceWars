using Assets.Scripts.Engine;
using Assets.Scripts.Engine.IGUI;
using Assets.Scripts.GUI.Graphics;


public class GUIHandler : UnityEngine.MonoBehaviour
{
    public Graphics graphics;


	// Use this for initialization
	void Start ()
	{
        DontDestroyOnLoad(gameObject);

        Runner.Graphics = graphics;
	}	
}
