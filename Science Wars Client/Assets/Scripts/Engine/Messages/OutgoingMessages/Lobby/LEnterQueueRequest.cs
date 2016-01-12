using System;
using NetWorker;
using NetWorker.Utilities;
using Assets.Scripts.Engine.GameUtilities;

namespace Assets.Scripts.Engine.Messages.OutgoingMessages.Lobby
{
	public class LEnterQueueRequest : OutgoingMessageImp
	{
		public static void sendMessage(string scienceType) 
		{
			RawMessage msg = new RawMessage();
			msg.putInt("id", TypeIdGenerator.getMessageId( typeof(LEnterQueueRequest) ));
			msg.putUTF8String("st",scienceType);
			Network.server.SendMessage(msg);
		}
	}
}

