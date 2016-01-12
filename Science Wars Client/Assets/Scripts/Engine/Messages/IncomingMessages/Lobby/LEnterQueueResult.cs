using Assets.Scripts.Engine.IGUI;
using Assets.Scripts.GUI;
using NetWorker;
using System;
using NetWorker.Utilities;

namespace Assets.Scripts.Engine.Messages.IncomingMessages.Lobby
{
	class LEnterQueueResult : IncomingMessageImp
	{
		public override void processMessage(RawMessage message)
		{
			bool r = message.getBool("r");
			if(r)
				UserMe.self.setState(User.UserState.QUEUE);

			Runner.Graphics.displayQueueResult(r);
		}	
	}
}

