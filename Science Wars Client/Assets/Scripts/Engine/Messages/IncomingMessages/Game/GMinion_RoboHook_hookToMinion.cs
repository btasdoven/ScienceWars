using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.Scripts.Engine.Minions;
using Assets.Scripts.Engine.Effects.MinionEffects;
using Assets.Scripts.Engine.GameUtilities;
using Assets.Scripts.Engine.Minions.Physics;

namespace Assets.Scripts.Engine.Messages.IncomingMessages.Game
{
    class GMinion_RoboHook_hookToMinion : IncomingMessageImp
	{
		public override void processMessage(NetWorker.Utilities.RawMessage message)
		{
			Minion minion = Engine.Game.getMinionById(message.getInt("iid"));
            Minion minionToHookTo = Engine.Game.getMinionById(message.getInt("tiid"));

            if (minion != null && minionToHookTo != null && minion is RoboHookMinion)
                ((RoboHookMinion)minion).hook(minionToHookTo);
		}
	}
}
