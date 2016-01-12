using System;
using UnityEngine;
using System.Collections;
using Assets.Scripts.Engine;

namespace Assets.Scripts.GUI.SceneSpecific.Game
{
	public class CameraController : MonoBehaviour {

		/*public float verticalScrollArea = 10f;
		
		public float horizontalScrollArea = 10f;
		
		public float verticalScrollSpeed = 10f;
		
		public float horizontalScrollSpeed = 10f;

		private float xMov = 0;

		private float yMov = 0;

		private int zoomAmount = 0;

		private int inZoom = -20;

		private int outZoom = 40;

		private static float dist = Assets.Scripts.Engine.Game.calculateBoardDistanceToCenter (Assets.Scripts.Engine.Game.players.Count);

		private static float moveXAmount = 0;

		private static float moveYAmount = 0;

		private static float moveXMax = 10f * 10f;

		private static float moveYmax = 10f * 10f;
		
		
		public void EnableControls(bool _enable) {
			
			
			
			if(_enable) {
				
				ZoomEnabled = true;
				
				MoveEnabled = true;
				
				CombinedMovement = true;
				
			} else {
				
				ZoomEnabled = false;
				
				MoveEnabled = false;
				
				CombinedMovement = false;
				
			}
			
		}
		
		
		
		public bool ZoomEnabled = true;
		
		public bool MoveEnabled = true;
		
		public bool CombinedMovement = true;
		
		
		
		private Vector2 _mousePos;
		
		private Vector3 _moveVector;
		
		private float _xMove;
		
		private float _yMove;
		
		private float _zMove;
		
		
		
		void Update () {

			dist = Assets.Scripts.Engine.Game.calculateBoardDistanceToCenter (Assets.Scripts.Engine.Game.players.Count);
			float distance = Vector3.Distance(transform.position,new Vector3(0,0,0));
			float squareEdge = distance * Mathf.Sqrt(2.0f);
			_mousePos = Input.mousePosition;
			
			
			
			//Move camera if mouse is at the edge of the screen
			
			if (MoveEnabled) {
				
				
				
				//Move camera if mouse is at the edge of the screen
				
				if (_mousePos.x < horizontalScrollArea)
					
				{
					if(-moveXMax < moveXAmount)
					{
						_xMove = -1;
						moveXAmount -= 1 * horizontalScrollSpeed;
					}
					else
						_xMove = 0;
					
				}
				
				else if (_mousePos.x >= Screen.width - horizontalScrollArea) {
					
					if(moveXMax > moveXAmount)
					{
						_xMove = 1;
						moveXAmount += 1 * horizontalScrollSpeed;
					}
					else
						_xMove = 0;
					
				}
				
				else {
					
					_xMove = 0;
					
				}
				
				
				
				if (_mousePos.y < verticalScrollArea) {

					if(-moveYmax < moveYAmount)
					{
						_zMove = -1;
						moveYAmount -= 1 * horizontalScrollSpeed;
					}
					else
						_zMove = 0;
					
				}
				
				else if (_mousePos.y >= Screen.height - verticalScrollArea) {
					
					if(moveYmax > moveYAmount)
					{
						_zMove = 1;
						moveYAmount += 1 * horizontalScrollSpeed;
					}
					else
						_zMove = 0;
					
				}
				
				else {
					
					_zMove = 0;
					
				}
				
				
				
			}
			
			else {
				
				_xMove = 0;
				
				_yMove = 0;
				
			}
			
			
			
			// Zoom Camera in or out
			
			if(ZoomEnabled) {
				
				if (Input.GetAxis("Mouse ScrollWheel") < 0) {

					if(zoomAmount  > inZoom)
					{
						_yMove = 1;
						zoomAmount--;
						moveXAmount = (moveXAmount / horizontalScrollSpeed) * (horizontalScrollSpeed+0.2f);
						moveYAmount = (moveYAmount / horizontalScrollSpeed) * (horizontalScrollSpeed+0.2f);
						horizontalScrollSpeed += 0.2f;
					}
					
				}
				
				else if (Input.GetAxis("Mouse ScrollWheel") > 0) {
					
					
					if(zoomAmount  < outZoom)
					{
						_yMove = -1;
						zoomAmount++;
						moveXAmount = (moveXAmount / horizontalScrollSpeed) * (horizontalScrollSpeed-0.2f);
						moveYAmount = (moveYAmount / horizontalScrollSpeed) * (horizontalScrollSpeed-0.2f);
						horizontalScrollSpeed -= 0.2f;
					}
					
				}
				
				else {
					
					_yMove = 0;
					
				}
				
			}
			
			else {
				
				_zMove = 0;
				
			}
			
			
			
			//move the object
			
			MoveMe(_xMove, _yMove, _zMove);
			
		}
		
		
		
		private void MoveMe(float x, float y, float z) {
			
			_moveVector = (new Vector3(-1 * z * horizontalScrollSpeed,

			                           y * verticalScrollSpeed, x * horizontalScrollSpeed) * Time.deltaTime);

			xMov += -1 * z;
			yMov += x ;

			transform.Translate(_moveVector, Space.World);
			
		}*/
		
		private float moveSpeed = 8;
		private int zoomAmount = 0;
		private const int ZOOM_IN = 12;
		private const int ZOOM_OUT = -3;
		private static int BOUNDARY = 5;//Math.Max(Screen.width,Screen.height)/30;
		private bool moveEnable = true;
		private bool movementFlag = false;

		GameObject mouseBorderPlane;

		// Use this for initialization
		void Start () {

			transform.rotation = Quaternion.Euler(PlayerMe.self.board.rotation);
			transform.position = PlayerMe.self.board.position;

			mouseBorderPlane = GameObject.CreatePrimitive(PrimitiveType.Plane);
			mouseBorderPlane.gameObject.layer = 5;
			Destroy(mouseBorderPlane.GetComponent<Renderer>());

			setMouseBorderPlane();

			GameObject cam = GameObject.Find("BackupCamera");
			cam.camera.enabled = false;
			//Camera.main.transform.parent = GameObject.Find("board_" + PlayerMe.self.board.instanceId).transform;

		}

		public void setMouseBorderPlane()
		{
			float minX = 0, minZ = -3, maxX = 0, maxZ = 3;
			foreach (Player p in Engine.Game.players)
				if (p.playerState == Player.PlayerState.ALIVE)
				{
					minX = Mathf.Min(p.board.position.x, minX);
					minZ = Mathf.Min(p.board.position.z, minZ);
					maxX = Mathf.Max(p.board.position.x, maxX);
					maxZ = Mathf.Max(p.board.position.z, maxZ);
				}
			
			minX -= 4;
			minZ -= 4;
			maxX += 4;
			maxZ += 4;
			
			mouseBorderPlane.transform.localScale = new Vector3((maxX - minX)/10, 1, (maxZ - minZ)/10);
			mouseBorderPlane.transform.position = new Vector3((maxX + minX)/2, -1f, (maxZ + minZ)/2);
			mouseBorderPlane.transform.rotation = transform.rotation;
		}

		void Update()
		{
	        if( PlayerMe.self.board.boardState != Board.BoardState.COLLAPSING)
	            transform.rotation = Quaternion.Euler(PlayerMe.self.board.rotation);

			if(moveEnable)
			{
				if (Input.GetAxis("Mouse ScrollWheel") > 0) // zoom in
				{
					if(ZOOM_IN > zoomAmount)
					{
						moveSpeed -= 0.4f;
						Camera.main.transform.position += Camera.main.transform.forward /2;
						zoomAmount++;
					}
				}
				if (Input.GetAxis("Mouse ScrollWheel") < 0) // zomm out
				{
					if(ZOOM_OUT < zoomAmount)
					{
						moveSpeed += 0.4f;
						Camera.main.transform.position -= Camera.main.transform.forward / 2;
						zoomAmount--;
					}
				}

				movementFlag = false;
				Vector3 newPos = transform.position;
				if (Input.mousePosition.x > Screen.width - BOUNDARY || Input.GetKey(KeyCode.RightArrow))
				{
					newPos += transform.forward * moveSpeed *  Time.deltaTime;
					movementFlag = true;
				}

				if (Input.mousePosition.x < 0 + BOUNDARY || Input.GetKey(KeyCode.LeftArrow))
				{
					newPos += -transform.forward * moveSpeed *  Time.deltaTime;
					movementFlag = true;
				}

				if (Input.mousePosition.y > Screen.height - BOUNDARY || Input.GetKey(KeyCode.UpArrow))
				{
					newPos += -transform.right * moveSpeed *  Time.deltaTime;
					movementFlag = true;
				}
				
				if (Input.mousePosition.y < 0 + BOUNDARY || Input.GetKey(KeyCode.DownArrow))
				{
				    newPos += transform.right * moveSpeed *  Time.deltaTime;
					movementFlag = true;
				}

				if (movementFlag) 
				{
					Vector3 oldPos = transform.position;
					transform.position = newPos;
					Ray ray = Camera.main.ScreenPointToRay (new Vector3(Screen.width/2, Screen.height/2, Input.mousePosition.z));
					if (!Physics.Raycast (ray.origin, ray.direction, 1000, 1 << 5) && (mouseBorderPlane.transform.position-oldPos).magnitude < (mouseBorderPlane.transform.position-newPos).magnitude)
						transform.position = oldPos;
				}
			}
		}


		void OnApplicationFocus(bool focusStatus)
		{
			moveEnable = focusStatus;
		}

		/*void Update() 
		{
			// Init camera translation for this frame.
			float translation = Vector3.zero;
			float camera = Camera.main;
			
			// Zoom in or out
			float zoomDelta = Input.GetAxis("Mouse ScrollWheel")*ZoomSpeed*Time.deltaTime;
			if (zoomDelta!=0)
			{
				translation -= Vector3.up * ZoomSpeed * zoomDelta;
			}
			
			// Start panning camera if zooming in close to the ground or if just zooming out.
			float pan = Camera.main.transform.eulerAngles.x - zoomDelta * PanSpeed;
			pan = Mathf.Clamp(pan, PanAngleMin, PanAngleMax);
			if (zoomDelta < 0 || camera.transform.position.y < (ZoomMax / 2))
			{
				camera.transform.eulerAngles = new Vector3(pan, 0, 0);
			}
			
			// Move camera with arrow keys
			translation += new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
			
			// Move camera with mouse
			if (Input.GetMouseButton(2)) // MMB
			{
				// Hold button and drag camera around
				translation -= new Vector3(Input.GetAxis("Mouse X") * DragSpeed * Time.deltaTime, 0, 
				                           Input.GetAxis("Mouse Y") * DragSpeed * Time.deltaTime);
			}
			else
			{
				// Move camera if mouse pointer reaches screen borders
				if (Input.mousePosition.x < ScrollArea)
				{
					translation += Vector3.right * -ScrollSpeed * Time.deltaTime;
				}
				
				if (Input.mousePosition.x >= Screen.width - ScrollArea)
				{
					translation += Vector3.right * ScrollSpeed * Time.deltaTime;
				}
				
				if (Input.mousePosition.y < ScrollArea)
				{
					translation += Vector3.forward * -ScrollSpeed * Time.deltaTime;
				}
				
				if (Input.mousePosition.y > Screen.height - ScrollArea)
				{
					translation += Vector3.forward * ScrollSpeed * Time.deltaTime;
				}
			}
			
			// Keep camera within level and zoom area
			float desiredPosition = camera.transform.position + translation;
			if (desiredPosition.x < -LevelArea || LevelArea < desiredPosition.x)
			{
				translation.x = 0;
			}
			if (desiredPosition.y < ZoomMin || ZoomMax < desiredPosition.y)
			{
				translation.y = 0;
			}
			if (desiredPosition.z < -LevelArea || LevelArea < desiredPosition.z)
			{
				translation.z = 0;
			}
			
			// Finally move camera parallel to world axis
			camera.transform.position += translation;
		}*/
	}
}