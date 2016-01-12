using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Science_Wars_Server.GameUtilities;
using Science_Wars_Server.Messages.OutgoingMessages.Game;

namespace Science_Wars_Server.Messages.IncomingMessages.Lobby
{
    class LCancelQueueRequest : IncomingMessageImp
    {
        public override void processMessage(NetWorker.Utilities.RawMessage message, User user)
        {
            if (user.userState == User.UserState.QUEUE)
            {
                LCancelQueueResult.sendMessage(user, true);
                Runner.queue.removeUser(user);
            }
            else
                LCancelQueueResult.sendMessage(user, false);
        }
    }
}
