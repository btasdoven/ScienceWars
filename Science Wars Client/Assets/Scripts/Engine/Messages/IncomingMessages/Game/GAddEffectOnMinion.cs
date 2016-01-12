using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.Scripts.Engine.Minions;
using Assets.Scripts.Engine.Effects.MinionEffects;
using Assets.Scripts.Engine.GameUtilities;
using UnityEngine;

namespace Assets.Scripts.Engine.Messages.IncomingMessages.Game
{
	class GAddEffectOnMinion : IncomingMessageImp
	{
		public override void processMessage(NetWorker.Utilities.RawMessage message)
		{
			Minion minion = Engine.Game.getMinionById(message.getInt("iid"));
			MinionEffect effect = (MinionEffect) Activator.CreateInstance(TypeIdGenerator.getMinionEffectClass(message.getInt("tid")));

            if (minion != null)
            {
                minion.effects.AddLast(effect);
                Runner.Graphics.addMinionEffect(minion, effect);
            }
		}
	}
}
