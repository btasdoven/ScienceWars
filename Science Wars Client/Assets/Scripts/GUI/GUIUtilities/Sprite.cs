using UnityEngine;
using System.Collections;

public class Sprite : MonoBehaviour{
	
	[Range(1,64)]
	public int columnCount = 1;
	[Range(1,64)]
	public int rowCount = 1;
	
	public int frameCount = 1;
	
	public int currentFrame = 0;
	public float duration = 2;

    public bool lookAtCamera = true;
	public bool isPaused = false;
	public bool hideDuringPause = false;

	public enum Mode{ ONCE, LOOP_FOREVER};
	public Mode mode = Mode.LOOP_FOREVER;
	
	private float stepX;
	private float stepY;
	private float timeStep;
	
	private float lastFrameTime=0;
	
	private Mesh mesh;
	
	void Start()
	{
		stepX = 1.0f/columnCount;
		stepY = 1.0f/rowCount;		
		timeStep = duration/frameCount;
		
		mesh = CreateMesh();
	}
		
	void Update () {

		if( hideDuringPause)
		{
			if( isPaused == false)
				renderer.enabled = true;
			else
				renderer.enabled = false;
		}
		else if(renderer.enabled == false)
			renderer.enabled = true;

		timeStep = duration/frameCount;
		
		if(!isPaused && Time.time - lastFrameTime > timeStep)
		{
			lastFrameTime = Time.time;
			
			mesh.uv = new Vector2[]{ new Vector2((currentFrame%columnCount)*stepX+stepX ,(rowCount - currentFrame/columnCount)*stepY),
					  new Vector2((currentFrame%columnCount)*stepX ,(rowCount - currentFrame/columnCount)*stepY),
			
					  new Vector2((currentFrame%columnCount)*stepX+stepX ,(rowCount - currentFrame/columnCount)*stepY-stepY),
					  new Vector2((currentFrame%columnCount)*stepX ,(rowCount - currentFrame/columnCount)*stepY-stepY)};			
			
			currentFrame = (currentFrame+1)%frameCount;
			if( mode == Mode.ONCE && currentFrame == 0)
				isPaused = true;
		}

	    if (lookAtCamera)
	    {
	        transform.LookAt(Camera.main.transform, new Vector3(0, 1, 0));
	        transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles + new Vector3(90, 0, 0));
	    }

	}

	Mesh CreateMesh()
	{
		Mesh plane = new Mesh();
		
		plane.vertices = new Vector3[]{ new Vector3(.5f,0f,.5f),new Vector3(-.5f,0,.5f), new Vector3(.5f,0,-.5f), new Vector3(-.5f,0,-.5f) };
		plane.triangles = new int[]{ 2,1,0,3,1,2 };
		plane.normals = new Vector3[] { Vector3.up, Vector3.up, Vector3.up, Vector3.up };
		plane.uv = new Vector2[] { new Vector2(0,0), new Vector2(0,0), new Vector2(0,0), new Vector2(0,0)};
		
		MeshFilter current = gameObject.GetComponent( typeof(MeshFilter)) as MeshFilter;
		if(current == null)
			current = gameObject.AddComponent( typeof(MeshFilter)) as MeshFilter;
		current.mesh = plane;		
		
		return plane;
	}
}
