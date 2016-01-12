using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NetWorker.Utilities;
using Science_Wars_Server.GameUtilities;

namespace Science_Wars_Server.Messages.OutgoingMessages.Game
{
    class GLoadingStateRequest : OutgoingMessageImp
    {
        public static void sendMessage(ICollection<Player> recievers)
        {   
            RawMessage bigMsg = new RawMessage();

            bigMsg.putInt("id", TypeIdGenerator.getMessageId(typeof(GLoadingStateRequest)));

            List<RawMessage> userMsgs = new List<RawMessage>();
            foreach (Player player in recievers) {
                RawMessage msg = new RawMessage();
                msg.putInt("btid", TypeIdGenerator.getBoardId(player.board.GetType()));
                msg.putInt("biid", player.board.instanceId);
                msg.putUTF8String("st", player.user.selectedScienceTypeInQueue.ToString());
                msg.putInt("hps", player.healthPoints);
                msg.putInt("cash", player.cash);
                msg.putInt("inc", player.income);
                msg.putUTF8String("un", player.user.username);
                msg.putInt("uid", player.user.id);
                userMsgs.Add(msg);
            }

            bigMsg.putRawMessageArray("users", userMsgs.ToArray());
                
            foreach (Player p in recievers)
            {
                p.user.session.client.SendMessage(bigMsg);
                
            }   
        }
    }
}
