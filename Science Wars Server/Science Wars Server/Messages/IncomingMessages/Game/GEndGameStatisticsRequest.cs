using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Science_Wars_Server.Statistics;

namespace Science_Wars_Server.Messages.IncomingMessages.Game
{
    class GEndGameStatisticsRequest: IncomingMessageImp
    {
        public override void processMessage(NetWorker.Utilities.RawMessage message, User user)
        {
            if(user.userState == User.UserState.GAME)
            {
                StatTracker statTracker = user.player.game.statTracker;
                List<Player> recievers = new List<Player>();
                recievers.Add(user.player);
                for (int i = 0; i < user.player.game.statPlayers.Count; i++ )
                {
                    if(user.player.game.statPlayers[i] != null)
                    {
                        for (int j = 0; j < statTracker.playerStatsList.Count; j++ )
                        {
                            if(user.player == statTracker.playerStatsList[j].ownerPlayer)
                            {
                                statTracker.playerStatsList[j].income = user.player.income;
                                statTracker.playerStatsList[j].cash = user.player.cash;
                                break;
                            }
                        }
                            
                    }
                }
                OutgoingMessages.Game.GEndGameStatisticsResult.sendMessage(recievers, statTracker);
            }
            
        }
    }
}
