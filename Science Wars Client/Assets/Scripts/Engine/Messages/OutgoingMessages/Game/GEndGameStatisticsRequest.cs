using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.Scripts.Engine.GameUtilities;
using NetWorker.Utilities;

namespace Assets.Scripts.Engine.Messages.OutgoingMessages.Game
{
	class GEndGameStatisticsRequest : OutgoingMessageImp
	{
		public static void sendMessage()
		{
			RawMessage msg = new RawMessage();
			msg.putInt("id", TypeIdGenerator.getMessageId(typeof(GEndGameStatisticsRequest)));
			Network.server.SendMessage(msg);
		}
	}
}
