using Assets.Scripts.Engine.Effects.MinionEffects;
using Assets.Scripts.Engine.Minions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts.Engine.Messages.IncomingMessages.Game
{
    class GMinion_Trypanophobia_addEffect : IncomingMessageImp
    {
        public override void processMessage(NetWorker.Utilities.RawMessage message)
        {
            Minion minion = Engine.Game.getMinionById(message.getInt("iid"));
            float runBackTime = message.getFloat("t");

            TrypanophobiaEffect effect = new TrypanophobiaEffect(runBackTime);

            if (minion != null)
            {
                minion.effects.AddLast(effect);
                Runner.Graphics.addMinionEffect(minion, effect);
            }
        }
    }
}
