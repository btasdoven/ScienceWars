namespace Assets.Scripts.Engine
{
    public class User
    {
        public string username;
        public int id;
        public Player player;

        public enum UserState
        {
            LOBBY,
            QUEUE,
            GAME
        };

        public UserState userState { get; private set; }

        public User()
        {
			userState = UserState.LOBBY;
			setStateLobby();
        }

        public User(string uname, int uid, Player p)
        {
            username = uname;
            id = uid;
            player = p;
        }

		#region State Changers
		
		public void setState(UserState state)
		{
			switch (userState)                  // Onceki state i terket.
			{
			case UserState.LOBBY:
				quitStateLobby(); break;
			case UserState.QUEUE:
				quitStateQueue(); break;
			case UserState.GAME:
				quitStateGame(); break;
			}
			userState = state;
			switch (state)                      // yeni state e gir.
			{
			case UserState.LOBBY:
				setStateLobby(); break;
			case UserState.QUEUE:
				setStateQueue(); break;
			case UserState.GAME:
				setStateGame(); break;
			}
			

		}
		
		#region SETS
		
		public void setStateLobby()
		{
		}
		public void setStateQueue()
		{            
		}
		public void setStateGame()
		{            
		}
		
		#endregion
		
		#region QUITS
		
		public void quitStateLobby()
		{
		}
		public void quitStateQueue()
		{		
		}
		public void quitStateGame()
		{		
		}

		#endregion
		
		#endregion
    }
}
