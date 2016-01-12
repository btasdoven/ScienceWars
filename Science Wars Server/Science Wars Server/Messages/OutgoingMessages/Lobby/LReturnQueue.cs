using NetWorker.Utilities;
using Science_Wars_Server.GameUtilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Science_Wars_Server.Messages.OutgoingMessages.Game
{
    class LReturnQueue : OutgoingMessageImp
    {
        public static void sendMessage(User user)
        {
            RawMessage msg = new RawMessage();
            msg.putInt("id", TypeIdGenerator.getMessageId(typeof(LReturnQueue)));
            user.userState = User.UserState.LOBBY;
            Runner.queue.addUser(user);
            user.session.client.SendMessage(msg);
        }
    }
}
