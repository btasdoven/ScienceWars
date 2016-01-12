using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NetWorker;
using NetWorker.Utilities;
using Science_Wars_Server.GameUtilities;

namespace Science_Wars_Server.Messages.OutgoingMessages.Login
{
    class LoginResult : OutgoingMessageImp
    {
        public static void sendMessage(User receiver, bool result)
        {
            RawMessage msg = new RawMessage();

            msg.putInt("id", TypeIdGenerator.getMessageId(typeof(LoginResult)));
            msg.putBool("r", result);

            msg.putUTF8String("un", receiver.username);
            msg.putInt("ui", receiver.id);
            msg.putInt("psp", receiver.physicsSciencePoint);
            msg.putInt("csp", receiver.chemistrySciencePoint);
            msg.putInt("bsp", receiver.biologySciencePoint);
            msg.putBoolArray("usn", receiver.unlockedScienceNodes);

            receiver.session.client.SendMessage(msg);
        }
    }
}
