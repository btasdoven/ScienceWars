using System;
using NetWorker.Utilities;

namespace Science_Wars_Server.Messages.IncomingMessages.Lobby
{
    /// <summary>
    ///                                     TEST AMACLI CLASS. SILINECEK
    /// </summary>
    class LChatMessage : IncomingMessageImp
    {
        public override void processMessage(RawMessage message, User user)
        {
            if (user.userState == User.UserState.LOBBY || user.userState == User.UserState.QUEUE)
            {                
                OutgoingMessages.Lobby.LChatMessage.sendMessage(user.username, message.getUTF8String("cmd"));
            }
        }
    }
}
    