using Assets.Scripts.Engine.GameUtilities;
using NetWorker;
using NetWorker.Utilities;

namespace Assets.Scripts.Engine.Messages.OutgoingMessages.Game
{
	public class GChatMessage : OutgoingMessageImp
	{
		
		public static void sendMessage(string text)
		{
			// TODO User state check
			RawMessage msg = new RawMessage();
			msg.putInt("id", TypeIdGenerator.getMessageId( typeof(GChatMessage) ));
			msg.putUTF8String("cmd", text);
			Network.server.SendMessage(msg);
		}
		
		
	}
}
