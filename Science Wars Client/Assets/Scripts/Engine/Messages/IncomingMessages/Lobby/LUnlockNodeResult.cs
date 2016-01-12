using Assets.Scripts.Engine.IGUI;
using Assets.Scripts.GUI;
using NetWorker;
using System;
using NetWorker.Utilities;

namespace Assets.Scripts.Engine.Messages.IncomingMessages.Lobby
{
	class LUnlockNodeResult : IncomingMessageImp
	{
		public override void processMessage(RawMessage message)
		{
			bool r = message.getBool("r");
			// TODO ayar cek pic
		}	
	}
}

