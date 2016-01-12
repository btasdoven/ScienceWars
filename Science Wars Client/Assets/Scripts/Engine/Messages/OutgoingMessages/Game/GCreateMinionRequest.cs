using UnityEngine;
using System.Collections;
using Assets.Scripts.Engine.Messages.OutgoingMessages;
using NetWorker.Utilities;
using Assets.Scripts.Engine.GameUtilities;

namespace Assets.Scripts.Engine.Messages.OutgoingMessages.Game
{
	public class GCreateMinionRequest : OutgoingMessageImp {

		static public void sendMessage( int minionTypeId)
		{
			RawMessage msg = new RawMessage();
			msg.putInt("id", TypeIdGenerator.getMessageId(typeof(GCreateMinionRequest)));
			msg.putInt("tid", minionTypeId);
			Network.server.SendMessage(msg);
		}
	}
}