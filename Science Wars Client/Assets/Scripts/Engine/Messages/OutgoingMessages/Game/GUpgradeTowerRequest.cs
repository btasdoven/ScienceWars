using Assets.Scripts.Engine.GameUtilities;
using NetWorker.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts.Engine.Messages.OutgoingMessages.Game
{
    class GUpgradeTowerRequest : OutgoingMessageImp
    {
        static public void sendMessage(Engine.Towers.Tower tower, int upgradedTowerTypeId)
        {
            RawMessage msg = new RawMessage();
            msg.putInt("id", TypeIdGenerator.getMessageId(typeof(GUpgradeTowerRequest)));
            msg.putInt("tid", upgradedTowerTypeId);
            msg.putInt("iob", tower.indexOnBoard);
            Network.server.SendMessage(msg);
        }
    }
}
