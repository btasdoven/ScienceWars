using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Science_Wars_Server.Messages.IncomingMessages.Lobby
{
    class GLoadingStateResult : IncomingMessageImp
    {
        public override void processMessage(NetWorker.Utilities.RawMessage message, User user)
        {
            if (user.userState == User.UserState.GAME && user.player != null)
            {
                user.player.loadedTheGame = true;

                bool allLoaded = true;

                foreach (var player in user.player.game.players)
                {
                    if (player.loadedTheGame == false)
                    {
                        allLoaded = false;
                        break;
                    }
                }

                if (allLoaded)
                {
                    user.player.game.setState( Science_Wars_Server.Game.GameState.STARTCOUNTDOWN);
                }
            }

            
        }
    }
}
