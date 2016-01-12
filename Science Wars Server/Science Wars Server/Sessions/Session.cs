using NetWorker.Host;

namespace Science_Wars_Server.Sessions
{
    public class Session
    {
        public Client client { get; set; }

        public Session(Client client)
        {
            this.client = client;
        }
    }
}
