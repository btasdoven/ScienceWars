using UnityEngine;
using System.Collections;
using Assets.Scripts.Engine.Messages.OutgoingMessages;
using NetWorker.Utilities;
using Assets.Scripts.Engine.GameUtilities;

namespace Assets.Scripts.Engine.Messages.OutgoingMessages.Game
{
	public class GUpgradeMinionRequest : OutgoingMessageImp {

		static public void sendMessage( int currentMinionTypeId, int upgradedMinionTypeId)
		{
			RawMessage msg = new RawMessage();
			msg.putInt("id", TypeIdGenerator.getMessageId(typeof(GUpgradeMinionRequest)));
            msg.putInt("tid", currentMinionTypeId);
            msg.putInt("utid", upgradedMinionTypeId);

			Network.server.SendMessage(msg);
		}
	}
}