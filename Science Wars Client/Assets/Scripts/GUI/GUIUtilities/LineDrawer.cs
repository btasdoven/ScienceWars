using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
class LineDrawer : UnityEngine.MonoBehaviour
{
    public Vector3[] transforms;
    public bool visible = true;

    public LineRenderer line;

    public float animationPeriod = 0f;
    public Color startColor;
    public Color endColor;
    public string colorNameToChange = "_TintColor";
    private float animTime=0;
    private bool animDirection = true;

    void Awake()
    {
	    line = GetComponent<LineRenderer>() as LineRenderer;	
	    line.useWorldSpace = true;        
    }

    void Update () 
    {
	    if( visible )
	    {
            if (animationPeriod != 0f)
            {
                if (animDirection)
                {
                    animTime += Time.deltaTime / animationPeriod;

                    if (animTime > 1)
                        animDirection = false;
                }
                else
                {
                    animTime -= Time.deltaTime / animationPeriod;

                    if (animTime < 0f)
                        animDirection = true;
                }


                line.material.SetColor(colorNameToChange, new Color(startColor.r + (endColor.r - startColor.r) * animTime,
                                                                    startColor.g + (endColor.g - startColor.g) * animTime,
                                                                    startColor.b + (endColor.b - startColor.b) * animTime,
                                                                    startColor.a + (endColor.a - startColor.a) * animTime));
            }


		    line.SetVertexCount(transforms.Length);
		
		    for( var i=0; i< transforms.Length; i++)
		    {
			    Vector3 pos = transforms[i];			
			    line.SetPosition(i, pos);
		    }
	    }
	    else
	    {
		    line.SetVertexCount(0);		
	    }
	
    }

    void SetVisible(bool visibility)
    {
 	    visible = visibility;
    }
}