using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NetWorker;
using NetWorker.Utilities;
using Science_Wars_Server.GameUtilities;

namespace Science_Wars_Server.Messages.OutgoingMessages.Lobby
{
    class LChatMessage : OutgoingMessageImp
    {
        public static void sendMessage(string senderUsername,string message)
        {
            RawMessage msg = new RawMessage();
            
            msg.putInt("id", TypeIdGenerator.getMessageId(typeof(LChatMessage)) );
            msg.putUTF8String("s", senderUsername);
            msg.putUTF8String("m", message);

            foreach (User u in Runner.users.Where( p => p.userState == User.UserState.LOBBY || p.userState == User.UserState.QUEUE ))
                u.session.client.SendMessage(msg);
        }
    }
}
