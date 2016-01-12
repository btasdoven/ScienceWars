using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NetWorker;
using NetWorker.Utilities;
using Science_Wars_Server.GameUtilities;

namespace Science_Wars_Server.Messages.OutgoingMessages
{
    class EnterLobby : OutgoingMessageImp
    {
        public static void sendMessage(User receiver)
        {
            RawMessage msg = new RawMessage();
            
            msg.putInt("id", TypeIdGenerator.getMessageId( typeof(EnterLobby)) );
           
            receiver.session.client.SendMessage(msg);
        }
    }
}
