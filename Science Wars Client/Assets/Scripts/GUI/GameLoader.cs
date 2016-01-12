using UnityEngine;
using System.Collections;
using Assets.Scripts.GUI.ResourceLoaderGUI;

public class GameLoader : MonoBehaviour {
    
	void Start()
	{
		if (Application.loadedLevelName != "Game") {
			Assets.Scripts.GUI.ResourceLoaderGUI.ResourceLoaderGUI.loadResources();
			Application.LoadLevel ("Game");
		}
	}

}
