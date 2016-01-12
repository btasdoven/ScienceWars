using NetWorker;
using NetWorker.Utilities;

namespace Assets.Scripts.Engine.Messages.IncomingMessages
{
    public interface IIncomingMessage : IMessage
    {
        void processMessage(RawMessage message);

        void setID(int id);
    }
}
