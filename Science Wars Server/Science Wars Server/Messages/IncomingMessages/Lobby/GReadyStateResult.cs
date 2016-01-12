using System;
using NetWorker.Utilities;
using System.Collections.Generic;
using Science_Wars_Server;
using Science_Wars_Server.Messages.OutgoingMessages.Game;

namespace Science_Wars_Server.Messages.IncomingMessages.Lobby
{
    class GReadyStateResult : IncomingMessageImp
    {
        public override void processMessage(RawMessage message, User user)
        {
            if (message.getBool("r"))
            {
                if (user.userState == User.UserState.GAME)
                {
                    OutgoingMessages.Game.GReadyStateResult.sendMessage(user.player.game.players, message.getBool("r"));
                    user.player.readyInQueue = true;

                    bool anyoneDisconnected = false;
                    bool flagAllReady = true;
                    User disconnectedUser = null;
                    foreach (Player p in user.player.game.players)
                        if (p.user.Destroyable)
                        {
                            anyoneDisconnected = true;
                            disconnectedUser = p.user;
                            break;
                        }
                        else if (!p.readyInQueue)
                        {
                            flagAllReady = false;
                            break;
                        }

                    if (anyoneDisconnected)
                        destroyGame(disconnectedUser);
                    else if (flagAllReady)
                        user.player.game.setState(Science_Wars_Server.Game.GameState.LOADING);

                    
                }
            }
            else
            {
                destroyGame(user);
            }
        }

        private void destroyGame(User guiltyUser)
        {
            Science_Wars_Server.Game gameToBeDestroyed = guiltyUser.player.game;
            foreach (Player player in guiltyUser.player.game.players)
            {
                if (player.user == guiltyUser || player.user.Destroyable == true)
                {
                    player.user.setState(User.UserState.LOBBY);
                }
                
                else if (player.user != guiltyUser && player.user.Destroyable == false)
                {
                    Runner.queue.addUser(player.user);
                    LReturnQueue.sendMessage(player.user);
                }
                    
            }

            gameToBeDestroyed.destroy();
        }
    }
}
