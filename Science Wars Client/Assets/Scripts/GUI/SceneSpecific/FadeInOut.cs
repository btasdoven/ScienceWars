using UnityEngine;
using System.Collections;

public class FadeInOut : MonoBehaviour {

    public Texture2D fadeTexture;
    public bool fadeIn = true;

    private float alpha = 0.0f;
    private float acc = 0.0001f;
    private float waitTime = 2.0f;
    void Start()
    {
        if (!fadeIn)
        {
            acc = 0.016f;
            alpha = 1;
        }
    }
    void Update()
    {
        if (fadeIn)
        {
            alpha = Mathf.Clamp01(alpha + acc);
            acc += 0.0001f;
            if (alpha == 1)
            {
                waitTime -= Time.deltaTime;
                if (waitTime <= 0)
                    fadeIn = false;
            }
        }
        else
        {
            alpha = Mathf.Clamp01(alpha - acc);
            acc -= 0.0001f;
            if (alpha == 0)
                Application.LoadLevel("ClientStarter");
        }
    }
    
    void OnGUI(){
        GUI.color = new Color(GUI.color.r, GUI.color.g, GUI.color.b, alpha);
        GUI.depth = 1000;
        GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), fadeTexture);
    }
}
