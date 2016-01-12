using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NetWorker;
using NetWorker.Utilities;
using Science_Wars_Server.GameUtilities;

namespace Science_Wars_Server.Messages.OutgoingMessages.Game
{
    class LEnterQueueResult : OutgoingMessageImp
    {
        public static void sendMessage(User user, bool result)
        {
            RawMessage msg = new RawMessage();
            msg.putInt("id", TypeIdGenerator.getMessageId(typeof(LEnterQueueResult)));
            
            msg.putBool("r", result);
            user.session.client.SendMessage(msg);
        }
    }
}
