using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.Scripts.Engine.Minions;
using Assets.Scripts.Engine.AreaEffects;
using Assets.Scripts.Engine.GameUtilities;
using UnityEngine;

namespace Assets.Scripts.Engine.Messages.IncomingMessages.Game
{
    class GTower_BlackHole_teleport : IncomingMessageImp
	{
		public override void processMessage(NetWorker.Utilities.RawMessage message)
		{
            int instanceId = message.getInt("iid");                        
            int[] minionIds = message.getIntArray("miid");            
            for (int i = 0; i < minionIds.Length; i++)
            {
                Minion m = Engine.Game.getMinionById(minionIds[i]);
                if (m != null)
                {
                    Runner.Graphics.tower_blackHoleTower_teleportStart(m);
                    m.moveCustomDistance(-2.0f);
                    Runner.Graphics.tower_blackHoleTower_teleportEnd(m);
                }
            }
		}
	}
}
