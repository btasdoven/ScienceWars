using Assets.Scripts.Engine.IGUI;
using Assets.Scripts.GUI;
using System.Collections;
using Assets.Scripts.Engine.Messages.IncomingMessages;
using NetWorker.Utilities;

namespace Assets.Scripts.Engine.Messages.IncomingMessages.Lobby
{
    public class GReadyStateRequest : IncomingMessageImp
    {
        public override void processMessage(RawMessage message)
        {
			float seconds = message.getFloat ("s");
			Runner.Graphics.displayGReadyStateRequest(seconds);
        }
    }
}