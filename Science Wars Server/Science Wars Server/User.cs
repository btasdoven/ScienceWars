using System.Collections.Generic;
using NetWorker.Utilities;
using Science_Wars_Server.GameUtilities;
using Science_Wars_Server.Messages;
using Science_Wars_Server.Messages.OutgoingMessages;
using Science_Wars_Server.Messages.OutgoingMessages.Login;
using Science_Wars_Server.ScienceTrees.ScienceNodes;
using Science_Wars_Server.Sessions;
using System;

namespace Science_Wars_Server
{
    public class User
    {
        private bool destroyable;

        public bool Destroyable
        {
            get { return destroyable; }
            set { this.destroyable = value; }
        }

        static int idGenerator = 0;

        public int id { get; private set; }
        public string username { get; private set; }

        public int physicsSciencePoint;
        public int chemistrySciencePoint;
        public int biologySciencePoint;

        public ScienceType selectedScienceTypeInQueue;
        public int selectedBoardTypeId;

        public bool[] unlockedTowers;              // TypeIdGenerator.getTowerIds.Count kadarlik yer al. Alttakileri de anlarsin artik. beyin lens degilse
                                                // Tower Type Id'sine gore 

        public bool[] unlockedMinions;             // Minion Type Id'sine gore

        public bool[] unlockedScienceNodes;         // ScienceNode type id'sine gore

        public enum UserState { LOBBY, QUEUE, GAME };
        public UserState userState = UserState.LOBBY;

        public Player player { get; set; }

        public Session session;           // the layer connecting to Networker in order to send message       
        Queue<RawMessage> messages = new Queue<RawMessage>();

        public User(Session session, string username, int physicsSciencePoint, int chemSciencePoint, int biologySciencePoint, bool[] unlockedScienceNodes)
        {
            id = idGenerator++;

            // bi sekilde ya databaseden okumak lazim ya da ...
            selectedBoardTypeId = 0;

            this.unlockedScienceNodes = unlockedScienceNodes;
            setUnlockedMinionsAndTowers(unlockedScienceNodes);  // aslinda lock kullanmak lazim. ancak herkes reader oldugu icin, hic writer olmadigi icin mutex kullanmaya gerek yok.

            this.session = session;
            this.username = username;
            this.physicsSciencePoint = physicsSciencePoint;
            this.chemistrySciencePoint = chemSciencePoint;
            this.biologySciencePoint = biologySciencePoint;

            LoginResult.sendMessage(this, true);
            EnterLobby.sendMessage(this);
        }

        private void setUnlockedMinionsAndTowers(bool[] unlockedScienceNodes)
        {
            unlockedTowers = new bool[TypeIdGenerator.getTowerTypeCount()];
            unlockedMinions = new bool[TypeIdGenerator.getMinionTypeCount()];

            for (int i = 0; i < unlockedScienceNodes.Length; ++i)
                if (unlockedScienceNodes[i])
                {
                    ScienceNode tmpNode = null;
                    if (ScienceNode.scienceNodeInst.TryGetValue(TypeIdGenerator.getScienceNodeTypes(i), out tmpNode))
                    {
                        if(tmpNode != null)
                            tmpNode.unlock(this);
                    }                  
                }
        }

        public void processMessages()
        {
            RawMessage newMessage;

            lock (messages)
            {
                while (messages.Count != 0)
                {
                    newMessage = messages.Dequeue();
                    int key = newMessage.getInt("id");
                    TypeIdGenerator.getMessageClass(key).processMessage(newMessage, this);
                }
            }
        }

        public void addMessage(RawMessage message)
        {
            lock (messages)
            {
                messages.Enqueue(message);
            }
        }

        #region State Changers

        public void setState(UserState state)
        {
            switch (userState)          // Onceki state i terket.
            {
                case UserState.LOBBY:
                    quitStateLobby();   break;
                case UserState.QUEUE:
                    quitStateQueue();   break;
                case UserState.GAME:
                    quitStateGame();    break;
            }

            switch (state)              // Yeni state e gir.
            {
                case UserState.LOBBY:
                    setStateLobby(); break;
                case UserState.QUEUE:
                    setStateQueue(); break;
                case UserState.GAME:
                    setStateGame(); break;
            }
            userState = state;
        }

        #region SETS

        private void setStateLobby()
        {
            Science_Wars_Server.Messages.OutgoingMessages.EnterLobby.sendMessage(this);
        }

        private void setStateQueue()
        {
            Science_Wars_Server.Messages.OutgoingMessages.Game.LEnterQueueResult.sendMessage(this, true);
        }

        private void setStateGame()
        {
            
        }

        #endregion

        #region QUITS
        
        private void quitStateGame()
        {
            if (player != null)
            {
                player = null;  // player.destroyable i true yapma. game hala bitirme isleri yapiyor olabilir.
            }
        }

        private void quitStateLobby()
        {

        }

        private void quitStateQueue()
        {

        }

        #endregion

        #endregion

    }
}
