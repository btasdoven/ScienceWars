using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Science_Wars_Server.GameUtilities;
using Science_Wars_Server.Messages.OutgoingMessages.Game;

namespace Science_Wars_Server.Messages.IncomingMessages.Lobby
{
    class LEnterQueueRequest : IncomingMessageImp
    {
        public override void processMessage(NetWorker.Utilities.RawMessage message, User user)
        {
            if (user.userState == User.UserState.LOBBY)
            {
                LEnterQueueResult.sendMessage(user, true);
                string qType = message.getUTF8String("st");
                user.selectedScienceTypeInQueue = (ScienceType) Enum.Parse(typeof(ScienceType), qType, true);
                Runner.queue.addUser(user);
            }
            else
                LEnterQueueResult.sendMessage(user, false);
        }
    }
}
