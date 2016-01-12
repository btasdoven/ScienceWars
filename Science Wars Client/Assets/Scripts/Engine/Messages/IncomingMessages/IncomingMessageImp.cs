using NetWorker;
using NetWorker.Utilities;

namespace Assets.Scripts.Engine.Messages.IncomingMessages
{
    public abstract class IncomingMessageImp : IIncomingMessage
    {
        int id=-1;

        abstract public void processMessage(RawMessage message);
        
        public void setID(int id)
        {
            this.id = id;
        }

        public int getID()
        {
            return id;
        }

    }
}
