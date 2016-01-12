using System;
using NetWorker.Utilities;

namespace Science_Wars_Server.Messages.IncomingMessages.Game
{

    class GChatMessage : IncomingMessageImp
    {
        public override void processMessage(RawMessage message, User user)
        {
            if (user.userState == User.UserState.GAME )
            {
                OutgoingMessages.Game.GChatMessage.sendMessage(user, message.getUTF8String("cmd"));
            }
        }
    }
}
