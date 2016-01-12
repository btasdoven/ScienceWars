using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.Scripts.Engine.Minions;
using Assets.Scripts.Engine.Minions.Biology;

namespace Assets.Scripts.Engine.Messages.IncomingMessages.Game
{
    class GMinion_Zombie_Raise : IncomingMessageImp
    {
        public override void processMessage(NetWorker.Utilities.RawMessage message)
        {
            Minion minion = Engine.Game.getMinionById(message.getInt("iid"));

            if (minion != null)
            {
                minion.minionState = Minion.MinionState.ALIVE;
                minion.stats.health = 264;
                minion.stats.baseMovementSpeed = 1.1f;
                Runner.Graphics.minion_zombie_raise((ZombieMinion)minion);
            }
        }
    }
}
