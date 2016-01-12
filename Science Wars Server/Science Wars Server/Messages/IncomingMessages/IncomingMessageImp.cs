using NetWorker.Utilities;

namespace Science_Wars_Server.Messages.IncomingMessages
{
    abstract class IncomingMessageImp : IIncomingMessage
    {
        abstract public void processMessage(RawMessage message, User user);
    }
}
