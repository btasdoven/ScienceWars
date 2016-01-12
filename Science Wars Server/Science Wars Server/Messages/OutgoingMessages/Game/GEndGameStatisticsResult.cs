using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NetWorker.Utilities;
using Science_Wars_Server.Statistics;
using Science_Wars_Server.GameUtilities;

namespace Science_Wars_Server.Messages.OutgoingMessages.Game
{
    class GEndGameStatisticsResult : OutgoingMessageImp
    {
        public static void sendMessage(ICollection<Player> recievers , StatTracker statTracker)
        {
            RawMessage bigMsg = new RawMessage();

            bigMsg.putInt("id", TypeIdGenerator.getMessageId(typeof(GEndGameStatisticsResult)));
            bigMsg.putInt("c",statTracker.playerStatsList.Count);

            int[] playerIDs = new int[statTracker.playerStatsList.Count];
            int [] minionsKilled = new int[statTracker.playerStatsList.Count];
            int[] minionsSend = new int[statTracker.playerStatsList.Count];
            int[] towersBuilt = new int[statTracker.playerStatsList.Count];
            int[] missilesFired = new int[statTracker.playerStatsList.Count];
            int[] minionsPassed = new int[statTracker.playerStatsList.Count];
            float[] moneyEarned = new float[statTracker.playerStatsList.Count];
            float[] moneySpend = new float[statTracker.playerStatsList.Count];
            int[] cashs = new int[statTracker.playerStatsList.Count];
            int[] incomes = new int[statTracker.playerStatsList.Count];

            for(int i = 0; i < statTracker.playerStatsList.Count; i++)
            {
                playerIDs[i] = statTracker.playerStatsList[i].ownerPlayer.id;
                minionsKilled[i] = statTracker.playerStatsList[i].minionsKilled;
                minionsSend[i] = statTracker.playerStatsList[i].minionsSend;
                towersBuilt[i] = statTracker.playerStatsList[i].towersBuilt;
                missilesFired[i] = statTracker.playerStatsList[i].missilesFired;
                minionsPassed[i] = statTracker.playerStatsList[i].minionsPassed;
                moneyEarned[i] = statTracker.playerStatsList[i].moneyEarned;
                moneySpend[i] = statTracker.playerStatsList[i].moneySpend;
                cashs[i] = statTracker.playerStatsList[i].cash;
                incomes[i] = statTracker.playerStatsList[i].income;
            }

            bigMsg.putIntArray("pids", playerIDs);
            bigMsg.putIntArray("mk",minionsKilled);
            bigMsg.putIntArray("ms", minionsSend);
            bigMsg.putIntArray("tb", towersBuilt);
            bigMsg.putIntArray("mf", missilesFired);
            bigMsg.putIntArray("mp", minionsPassed);
            bigMsg.putFloatArray("mme", moneyEarned);
            bigMsg.putFloatArray("mms", moneySpend);
            bigMsg.putIntArray("cs", cashs);
            bigMsg.putIntArray("inc",incomes);

            foreach (Player p in recievers)
            {
                p.user.session.client.SendMessage(bigMsg);
            }  

            
        }
    }
}
