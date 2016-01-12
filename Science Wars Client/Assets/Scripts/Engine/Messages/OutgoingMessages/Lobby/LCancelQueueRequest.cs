using System;
using NetWorker;
using NetWorker.Utilities;
using Assets.Scripts.Engine.GameUtilities;

namespace Assets.Scripts.Engine.Messages.OutgoingMessages.Lobby
{
	public class LCancelQueueRequest : OutgoingMessageImp
	{
		public static void sendMessage() 
		{
			RawMessage msg = new RawMessage();
			msg.putInt("id", TypeIdGenerator.getMessageId( typeof(LCancelQueueRequest) ));
			Network.server.SendMessage(msg);
		}
	}
}

