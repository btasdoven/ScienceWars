using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.Scripts.Engine.GameUtilities;
using Assets.Scripts.Engine.Minions;
using Assets.Scripts.Engine.Missiles;
using Assets.Scripts.Engine.Towers;
using NetWorker.Utilities;

namespace Assets.Scripts.Engine.Messages.IncomingMessages.Game
{
    class GCreateMissileInfo : IncomingMessageImp
    {
        public override void processMessage(RawMessage message)
        {
            Board board = Engine.Game.getBoardById(message.getInt("bid"));
            if (board != null)
            {
                Tower ownerTower = board.towers[message.getInt("iob")];
                Minion targetMinion = Engine.Game.getMinionById(message.getInt("mid"));
                if (ownerTower != null && targetMinion != null)
                {
                    Missile missile = (Missile)Activator.CreateInstance(TypeIdGenerator.getMissileType(message.getInt("tid")),
                        message.getInt("iid"), ownerTower, targetMinion);


                    Engine.Game.AddMissile(missile);
                    Runner.Graphics.createMissile(missile);
                }
            }
        }
    }
}
