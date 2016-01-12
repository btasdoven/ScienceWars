using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using Assets.Scripts.Engine.GameUtilities;
using Assets.Scripts.Engine.Towers;
using UnityEngine;
using System.Collections;
using Assets.Scripts.GUI.Interfaces;
using Assets.Scripts.GUI.ResourceLoaderGUI;
using Assets.Scripts.Engine;

namespace Assets.Scripts.GUI.Boards
{
	public class RegularBoardGUI : IBoardGUI {

		private static GameObject staticBoardObject;

		Board board;
		GameObject boardObject;
		
        #region IBoardGUI implementation
		
        public void createBoard (Board board)
		{
			this.board = board;
			board.tag = this;
			boardObject = (GameObject)GameObject.Instantiate(staticBoardObject);
			boardObject.name = "board_" + board.instanceId; 
			boardObject.transform.position = board.position;
			boardObject.transform.rotation = Quaternion.Euler( board.rotation );
			//Camera.main.transform.parent = boardObject.transform;
		}

		
        public void destroyBoard()
        {
			
            GameObject.Destroy(boardObject);
            destroyed = true;
         } 


        public bool isDestroyable()
        { 
			return destroyed;
        } 
	    #endregion

	    private bool destroyed = false;

		#region IStep implementation

	    private int counter = 0;    //DEBUG path cizdirirken kullaniliyor
		public void step ()
		{
		    if (destroyed == false)
		    {
		        if (board.boardState == Board.BoardState.COLLAPSING)
		        {
		            destroyBoard();
		            return;
		        }
		        boardObject.transform.position = board.position;
		        boardObject.transform.rotation = Quaternion.Euler(board.rotation);

		        #region /////////// DEBUG - pathi kirmizi cizgiyle cizdirmek icin - DEBUG /////////

		        int end = board.getPath().getPointCount();
		        counter++;
		        if (counter%10 == 0)
		            for (int i = 0; i < 3*(end - 3) - 1; i++)
		            {
		                MinionPosition mp = new MinionPosition();
		                mp.board = board;
		                mp.pathPosition = new PathPosition(i/3, (i%3)/3.0f);
		                Vector3 p1 = board.getPath().getWorldPosition(mp);
		                mp.pathPosition = new PathPosition((i + 1)/3, ((i + 1)%3)/3.0f);
		                Vector3 p2 = board.getPath().getWorldPosition(mp);
		                Debug.DrawLine(p1, p2, Color.red, .5f);
		            }

		        #endregion
		    }
		}

		#endregion

		#region IRequiresResourceGUI implementation

		public void loadResources ()
		{
			staticBoardObject = (GameObject)Resources.Load("3Ds/Boards/RegularBoard/BoardObject");
		}

		#endregion

        
    }
}