using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.Scripts.Engine.Minions;
using Assets.Scripts.Engine.Effects.MinionEffects;
using Assets.Scripts.Engine.GameUtilities;

namespace Assets.Scripts.Engine.Messages.IncomingMessages.Game
{
	class GAddEffectOnMinionNailTrapSlow : IncomingMessageImp
	{
		public override void processMessage(NetWorker.Utilities.RawMessage message)
		{
			Minion minion = Engine.Game.getMinionById(message.getInt("iid"));
			float slowAmount = message.getFloat ("sa");
			NailTrapSlowEffect effect = new NailTrapSlowEffect (slowAmount);
			
			if (minion != null)
			{
				minion.effects.AddLast(effect);
				Runner.Graphics.addMinionEffect(minion, effect);
			}
		}
	}
}
