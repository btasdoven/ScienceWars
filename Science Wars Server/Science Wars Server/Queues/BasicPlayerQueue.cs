using System;
using System.Collections.Generic;
using Science_Wars_Server.Messages.OutgoingMessages;
using Science_Wars_Server.Messages.OutgoingMessages.Game;

namespace Science_Wars_Server.Queues
{
    public class BasicPlayerQueue : IPlayerQueue
    {
        Runner runner;
        List<User> users;
        int maxPlayerCount;

        public BasicPlayerQueue(Runner runner, int maxPlayerCount)
        {
            this.runner = runner;
            this.maxPlayerCount = maxPlayerCount;
            users = new List<User>(maxPlayerCount);
        }

        /// <summary>
        /// Adds user to queue. Sets its state to QUEUE
        /// If there is enough players, creates 
        /// </summary>
        /// <param name="user"></param>
        public void addUser(User user)
        {
            if (user.Destroyable == false && user.userState == User.UserState.LOBBY)
            {
                users.Add(user);
                user.setState(User.UserState.QUEUE);
            }

            if (users.Count == maxPlayerCount)
            {
                List<User> nextQueue = new List<User>();

                foreach (var u in users)
                {
                    if (u.Destroyable == false)
                        nextQueue.Add(u);
                }
                users = nextQueue;
                
                if (users.Count == maxPlayerCount)
                {
                    Game game = new Game(users);
                    runner.AddGame(game);
                    users = new List<User>(maxPlayerCount); // listeyi bir sonraki playerları tutmak üzere sıfırla.
                }
            }

        }

        public void removeUser(User user)
        {
            users.Remove(user);
            user.setState(User.UserState.LOBBY);
        }
    }
}
