using UnityEngine;
using System.Collections;

public class Elise : MonoBehaviour {

	// Use this for initialization
	void Start () {
		animation ["walk"].time = 0.6f;
		animation ["walk"].speed = 0f;
		animation.CrossFade ("walk");
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
