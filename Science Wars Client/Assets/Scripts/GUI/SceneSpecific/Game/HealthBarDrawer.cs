using UnityEngine;
using System.Collections;

public class HealthBarDrawer : MonoBehaviour
{
    private static Texture2D backgroundTexture;
    private static Texture2D foregroundTexture;

    public int baseWidth = 256;
    public int baseHeight = 32;
    public int health = 100;
    public int maxHealth = 100;

    private int width = 256;
    private int height = 32;
	// Update is called once per frame
	void Start () 
    {
	    if (backgroundTexture == null)
	    {
	        backgroundTexture = Resources.Load<Texture2D>("2Ds/Game/HealthBar/hb_bg");
            foregroundTexture = Resources.Load<Texture2D>("2Ds/Game/HealthBar/hb_fg");
	    }
	}

    void OnGUI()
    {
        if (health > maxHealth)
            health = maxHealth;
        if (health < 0)
            health = 0;

        Vector3 screenPos = Camera.main.WorldToScreenPoint(transform.position);
        screenPos.y = Screen.height - screenPos.y;

        var distance = (transform.position - Camera.main.transform.position).magnitude;

        width  = (int) (baseWidth/distance);
        height = (int) (baseHeight/distance);

        GUI.depth -= 1000;
        GUI.DrawTexture( new Rect( screenPos.x - width/2, screenPos.y-height/2, width,height), backgroundTexture, ScaleMode.StretchToFill );
        GUI.DrawTextureWithTexCoords(new Rect(screenPos.x - width / 2 + width / 20, screenPos.y - height/2, (health/(float)maxHealth)*(width - width / 10), height), foregroundTexture, new Rect(0, 0, health/100f, 1));
        GUI.depth += 1000;
        
    }
}
