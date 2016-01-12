using System;
using Science_Wars_Server.Helpers;
using System.Collections.Generic;
using NetWorker.Utilities;
using NetWorker.Host;
using Science_Wars_Server.Sessions;
using Science_Wars_Server.GameUtilities;
using Science_Wars_Server.Queues;
using NetWorker.EventArgs;
using Science_Wars_Server.Database;

namespace Science_Wars_Server
{
    public class Runner
    {     
        Server server = new Server();
        public static IDatabaseAccessLayer dal;
        Dictionary<Client, User> userdictionary = new Dictionary<Client,User>();

        public static LinkedList<Game> games = new LinkedList<Game>();
        public static LinkedList<User> users = new LinkedList<User>();
        public static BasicPlayerQueue queue;

        public Runner(string ip, int port)
        {
            TypeIdGenerator.getTowerType(0);
			// db does nox exist. Do not worry about the ID and password :)
            dal = new MySQLDatabaseAccessor("127.0.0.1", 3306, "sciencewarsdb", "root", "admin");

            ResourceLoader.loadResources();
            queue = new BasicPlayerQueue(this, 2);
            server.clientArrivedEvent += server_clientArrivedEvent;
            server.clientRemovedEvent += server_clientRemovedEvent;
            server.messageArrivedEvent += server_messageArrivedEvent;
            
            server.StartServer(ip, port);
        }

        /// <summary>
        /// Main loop for the server. It should handle everything except login.
        /// </summary>
        /// <param name="runInterval">Frame time in miliseconds</param>
        public void run(long runInterval)
        {
            Chronos.setInterval(runInterval);      // sunucu dongusunu her 1 runInterval milisaniyede tamamlayacak.

            while (true)
            {
                try
                {
                    while (true)
                    {
                        Chronos.waitForTheRightMoment();    // fps yi ayarliyor.                 

                        processUserMessages();

                        stepAllGames();
                    }

                }
                catch (Exception e)
                {
                    Console.Write(e.ToString() + "\nStack Trace:\n" + e.StackTrace);
                }

            }
        }

        private void processUserMessages()
        {
            lock (userdictionary)        // yeni login olanlar listeye kaynamasin diye lock luyoruz.
            {
                LinkedListNode<User> userNode = users.First;
                LinkedListNode<User> tmpNode = null;

                while (userNode != null)
                {
                    if (userNode.Value.Destroyable == true)
                    {
                        tmpNode = userNode;
                        userNode = userNode.Next;
                        users.Remove(tmpNode);
                    }
                    else
                    {
                        userNode.Value.processMessages();
                        userNode = userNode.Next;
                    }
                }
            }
        }

        private void stepAllGames()
        {
            LinkedListNode<Game> gameNode = games.First;
            LinkedListNode<Game> tmpNode = null;

            while (gameNode != null)
            {
                if (gameNode.Value.destroyable == true)
                {
                    tmpNode = gameNode;
                    gameNode = gameNode.Next;
                    games.Remove(tmpNode);
                }
                else
                {
                    gameNode.Value.step();
                    gameNode = gameNode.Next;
                }
            }
        }

        public void AddGame(Game game)
        {
            games.AddLast(game);
        }

        private void AddUser(User user)
        {
            lock (userdictionary)
            {
                if (userdictionary.ContainsKey(user.session.client) == false)
                {
                    userdictionary.Add(user.session.client, user);
                    users.AddLast(user);

                    Console.WriteLine("User Added: " + user.username);
                }
            }
        }
        
        private void RemoveUser(Client client)
        {
            lock (userdictionary)
            {
                User user;
                if (userdictionary.TryGetValue(client, out user))
                {
                    user.Destroyable = true;
                    userdictionary.Remove(client);

                    Console.WriteLine("User removed: " + user.username);
                }
            }
        }
        
        void server_messageArrivedEvent(object sender, MessageArrivedEventArgs e)
        {
            User user;
            bool objectFound = false;

            lock( userdictionary)
            {
                objectFound = userdictionary.TryGetValue(e.sender, out user);
            }
            
            if( objectFound )   // user bulunamadiysa muhtemelen login olmamis biridir. Login olmadan, userlar userDictionary ye eklenmezler.
                user.addMessage(e.message);
        }

        void server_clientRemovedEvent(object sender, ClientEventArgs e)
        {
            RemoveUser(e.client);            
        }

        void server_clientArrivedEvent(object sender, ClientEventArgs e)
        {
            Session ses = new Session(e.client);
            LoginManager loginManager = new LoginManager(this, ses, dal);
            loginManager.launch();

            Console.WriteLine("Client arrived and redirected to LoginManager. ");
        }

        public void userLoggedIn(User user)
        {
            AddUser(user);
        }
    }
}
