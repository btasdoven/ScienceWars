using System;
using NetWorker;
using NetWorker.Utilities;
using Assets.Scripts.Engine.GameUtilities;

namespace Assets.Scripts.Engine.Messages.OutgoingMessages.Lobby
{
	public class LUnlockNodeRequest : OutgoingMessageImp
	{
		public static void sendMessage(Type nodeType) 
		{
			RawMessage msg = new RawMessage();
			msg.putInt("id", TypeIdGenerator.getMessageId( typeof(LUnlockNodeRequest) ));
			msg.putInt("tid",TypeIdGenerator.getScienceNodeIds (nodeType));
			Network.server.SendMessage(msg);
		}
	}
}

