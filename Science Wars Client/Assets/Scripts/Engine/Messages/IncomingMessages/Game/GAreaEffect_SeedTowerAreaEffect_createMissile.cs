using Assets.Scripts.Engine.GameUtilities;
using Assets.Scripts.Engine.Minions;
using Assets.Scripts.Engine.Missiles;
using Assets.Scripts.Engine.Towers;
using NetWorker.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts.Engine.Messages.IncomingMessages.Game
{
    public class GAreaEffect_SeedTowerAreaEffect_createMissile : IncomingMessageImp
    {
        public override void processMessage(RawMessage message)
        {
            Vector3 position = new Vector3(message.getFloat("x"), message.getFloat("y"), message.getFloat("z"));
 
            Minion targetMinion = Engine.Game.getMinionById(message.getInt("mid"));
            if (position != null && targetMinion != null)
            {
                Missile missile = (Missile)Activator.CreateInstance(TypeIdGenerator.getMissileType(message.getInt("tid")),
                    message.getInt("iid"), position, targetMinion);


                Engine.Game.AddMissile(missile);
                Runner.Graphics.createMissile(missile);
            }
        }
    }
}
