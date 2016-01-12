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
    class GMinion_QuantumSoldier_teleport : IncomingMessageImp
	{
        public override void processMessage(NetWorker.Utilities.RawMessage message)
        {
            Minion minion = Engine.Game.getMinionById(message.getInt("iid"));

            if (minion != null && minion is QuantumSoldierMinion)
            {
                ((QuantumSoldierMinion)minion).teleport();
                Runner.Graphics.minion_quantumSoldier_teleport(minion);
            }

            int[] minionInstanceIDs = message.getIntArray("mids");
            float dist = message.getFloat("ds");

            for(int i = 0; i < minionInstanceIDs.Length; i++)
            {
                Minion minionToTp = Engine.Game.getMinionById(minionInstanceIDs[i]);
                minionToTp.moveCustomDistance(dist);
            }
        }
	}
}
