using Assets.Scripts.Engine.GameUtilities;
using NetWorker;
using NetWorker.Utilities;

namespace Assets.Scripts.Engine.Messages.OutgoingMessages.Lobby
{
    class GReadyStateResult : OutgoingMessageImp
    {
        public static void sendMessage(bool result)
        {
            RawMessage msg = new RawMessage();
            msg.putInt("id", TypeIdGenerator.getMessageId(typeof(GReadyStateResult)));
            msg.putBool("r", result);
            Network.server.SendMessage(msg);
        }
    }
}
