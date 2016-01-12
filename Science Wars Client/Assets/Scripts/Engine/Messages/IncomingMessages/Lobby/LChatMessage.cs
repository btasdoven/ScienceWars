using Assets.Scripts.Engine.IGUI;
using Assets.Scripts.GUI;
using NetWorker;
using NetWorker.Utilities;

namespace Assets.Scripts.Engine.Messages.IncomingMessages.Lobby
{
    class LChatMessage : IncomingMessageImp
    {
        public override void processMessage(RawMessage message)
        {
			string senderUsername = message.getUTF8String("s");
			string msg = message.getUTF8String("m");
            Runner.Graphics.displayChatMessage(senderUsername,msg);
        }
    }
}
