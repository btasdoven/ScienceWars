using NetWorker.Utilities;

namespace Science_Wars_Server.Messages.IncomingMessages
{
    public interface IIncomingMessage : IMessage
    {
        void processMessage(RawMessage message, User user);
    }
}
