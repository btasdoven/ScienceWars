using Assets.Scripts.Engine.IGUI;
using Assets.Scripts.GUI;
using NetWorker;
using System;
using NetWorker.Utilities;

namespace Assets.Scripts.Engine.Messages.IncomingMessages.Lobby
{
	class LReturnQueue : IncomingMessageImp
	{
		public override void processMessage(RawMessage message)
		{
			Runner.Graphics.displayQueueResult(true);
		}
	}
}
