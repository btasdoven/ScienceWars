
using UnityEngine;
using System.Collections;

public class Tooltiper : MonoBehaviour {

	public string text;

	void OnTooltip (bool show)
	{
		if (show) {
			UITooltip.ShowText(text);
		}
		else
			UITooltip.ShowText(null);
	}
}
