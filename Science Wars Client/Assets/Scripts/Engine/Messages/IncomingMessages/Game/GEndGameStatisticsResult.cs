using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NetWorker.Utilities;
using Assets.Scripts.Engine;
using Assets.Scripts.Engine.Statistics;

namespace Assets.Scripts.Engine.Messages.IncomingMessages.Game
{
	public class GEndGameStatisticsResult : IncomingMessageImp
	{
		public override void processMessage(RawMessage message)
		{
			int countOfPlayers = message.getInt ("c");
			int[] playerIDs = new int[countOfPlayers];
			int [] minionsKilled = new int[countOfPlayers];
			int[] minionsSend = new int[countOfPlayers];
			int[] towersBuilt = new int[countOfPlayers];
			int[] missilesFired = new int[countOfPlayers];
			int[] minionsPassed = new int[countOfPlayers];
			float[] moneyEarned = new float[countOfPlayers];
			float[] moneySpend = new float[countOfPlayers];
			int[] cashs = new int[countOfPlayers];
			int[] incomes = new int[countOfPlayers];

			playerIDs = message.getIntArray ("pids");
			minionsKilled = message.getIntArray ("mk");
			minionsSend = message.getIntArray ("ms");
			towersBuilt = message.getIntArray ("tb");
			missilesFired = message.getIntArray ("mf");
			minionsPassed = message.getIntArray ("mp");
			moneyEarned = message.getFloatArray ("mme");
			moneySpend = message.getFloatArray ("mms");
			cashs = message.getIntArray ("cs");
			incomes = message.getIntArray ("inc");

			Assets.Scripts.Engine.Game.statTracker = new StatTracker ();
			Assets.Scripts.Engine.Game.statTracker.playerStatsList = new List<PlayerStats>();

			for (int i = 0; i < countOfPlayers; i++) 
			{
				Player currentPlayer = null;
				foreach (Player player in Assets.Scripts.Engine.Game.players)
				{
					if(player.id == playerIDs[i])
					{
						currentPlayer = player;
						break;
					}
				}

				PlayerStats newStats = new PlayerStats(currentPlayer);
				newStats.minionsKilled = minionsKilled[i];
				newStats.minionsSend = minionsSend[i];
				newStats.towersBuilt = towersBuilt[i];
				newStats.missilesFired = missilesFired[i];
				newStats.minionsPassed = minionsPassed[i];
				newStats.moneyEarned = moneyEarned[i];
				newStats.moneySpend = moneySpend[i];
				newStats.cash = cashs[i];
				newStats.income = incomes[i];

				Assets.Scripts.Engine.Game.statTracker.playerStatsList.Add(newStats);
			}

			Runner.Graphics.displayEndGameStatistics ();

		}
	}
}

