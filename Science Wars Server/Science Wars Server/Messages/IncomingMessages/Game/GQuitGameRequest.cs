using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NetWorker.Utilities;

namespace Science_Wars_Server.Messages.IncomingMessages.Lobby
{
    class GQuitGameRequest : IncomingMessageImp
    {
        public override void processMessage(RawMessage message, User user)
        {
            if (user.player != null && user.player.game != null)
            {
                user.player.game.removePlayer( user.player );
            }
        }
    }
}
