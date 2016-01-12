using Assets.Scripts.Engine.IGUI;
using Assets.Scripts.GUI;
using NetWorker;
using NetWorker.Utilities;

namespace Assets.Scripts.Engine.Messages.IncomingMessages.Lobby
{
    class GReadyStateResult : IncomingMessageImp
    {
        public override void processMessage(RawMessage message)
        {
            bool result = message.getBool("r");
            Runner.Graphics.displayReadyStates(result);
        }
    }
}
