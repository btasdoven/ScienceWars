using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NetWorker.Utilities;
using Science_Wars_Server.GameUtilities;
using Science_Wars_Server.Missiles;
using Science_Wars_Server.Towers;
using Science_Wars_Server.Statistics;

namespace Science_Wars_Server.Messages.OutgoingMessages.Game
{
    class GCreateMissileInfo : OutgoingMessageImp
    {
        public static void sendMessage(ICollection<Player> receiverPlayers, Missile missile )
        {
            RawMessage msg = new RawMessage();
            msg.putInt("id", TypeIdGenerator.getMessageId(typeof(GCreateMissileInfo)));

            // STATCODE
            PlayerStats pStats = missile.ownerTower.board.player.game.statTracker.getPlayerStatsOfPlayer(missile.ownerTower.board.player);
            pStats.missilesFired += 1;

            if (receiverPlayers != null && receiverPlayers.Count != 0)
            {
                msg.putInt("iid", missile.instanceId);
                msg.putInt("bid", missile.ownerTower.board.instanceId);
                msg.putInt("iob", missile.ownerTower.indexOnBoard);
                msg.putInt("tid", TypeIdGenerator.getMissileId(missile.GetType()));
                msg.putInt("mid", missile.targetMinion.instanceId);
                
                foreach (var receiverPlayer in receiverPlayers)
                    receiverPlayer.user.session.client.SendMessage(msg);
            }
        }
    }
}
