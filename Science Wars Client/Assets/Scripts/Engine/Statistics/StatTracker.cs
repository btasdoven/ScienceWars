using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.Scripts.Engine;
using Assets.Scripts.Engine.Statistics;

namespace Assets.Scripts.Engine.Statistics
{
		public class StatTracker : IStatTracker
		{
			public List<PlayerStats> playerStatsList;
			
			public StatTracker()
			{
				this.playerStatsList = new List<PlayerStats>();
			}
			
			public PlayerStats getPlayerStatsOfPlayer(Player player)
			{
				foreach (PlayerStats pStats in this.playerStatsList)
				{
					if (pStats.ownerPlayer == player)
						return pStats;
				}
				return null;
			}
			
			public float getMoneyEarnedByPlayer(Player player)
			{
				foreach(PlayerStats pStats in this.playerStatsList)
				{
					if (pStats.ownerPlayer == player)
						return pStats.moneyEarned;
				}
				
				return 0.0f;
			}
			
			public float getMoneySpendByPlayer(Player player)
			{
				foreach (PlayerStats pStats in this.playerStatsList)
				{
					if (pStats.ownerPlayer == player)
						return pStats.moneySpend;
				}
				
				return 0.0f;
			}
			
			public float getTotalMoneySpendInGame()
			{
				float total = 0.0f;
				
				foreach (PlayerStats pStats in this.playerStatsList)
				{
					total += pStats.moneySpend;
				}
				
				return total;
				
			}
			
			public float getTotalMoneyEarnedInGame()
			{
				float total = 0.0f;
				
				foreach (PlayerStats pStats in this.playerStatsList)
				{
					total += pStats.moneyEarned;
				}
				
				return total;
			}
			
			public int getMinionsSendByPlayer(Player player)
			{
				foreach (PlayerStats pStats in this.playerStatsList)
				{
					if (pStats.ownerPlayer == player)
						return pStats.minionsSend;
				}
				
				return 0;
			}
			
			public int getMinionsKilledByPlayer(Player player)
			{
				foreach (PlayerStats pStats in this.playerStatsList)
				{
					if (pStats.ownerPlayer == player)
						return pStats.minionsKilled;
				}
				
				return 0;
			}
			
			public int getMinionsSendInGame()
			{
				int total = 0;
				
				foreach (PlayerStats pStats in this.playerStatsList)
				{
					total += pStats.minionsSend;
				}
				
				return total;
			}
			
			public int getMinionsKilledInGame()
			{
				int total = 0;
				
				foreach (PlayerStats pStats in this.playerStatsList)
				{
					total += pStats.minionsKilled;
				}
				
				return total;
			}
			
			public int getTowersBuiltByPlayer(Player player)
			{
				foreach (PlayerStats pStats in this.playerStatsList)
				{
					if (pStats.ownerPlayer == player)
						return pStats.towersBuilt;
				}
				
				return 0;
			}
			
			public int getTowersBuiltInGame()
			{
				int total = 0;
				
				foreach (PlayerStats pStats in this.playerStatsList)
				{
					total += pStats.towersBuilt;
				}
				
				return total;
			}
			
			public int getMinionsPassedOfPlayer(Player player)
			{
				foreach (PlayerStats pStats in this.playerStatsList)
				{
					if (pStats.ownerPlayer == player)
						return pStats.minionsPassed;
				}
				
				return 0;
			}
			
			public int getMinionsPassedInGame()
			{
				int total = 0;
				
				foreach (PlayerStats pStats in this.playerStatsList)
				{
					total += pStats.minionsPassed;
				}
				
				return total;
			}
			
			public int getMissilesFiredByPlayer(Player player)
			{
				foreach (PlayerStats pStats in this.playerStatsList)
				{
					if (pStats.ownerPlayer == player)
						return pStats.missilesFired;
				}
				
				return 0;
			}
			
			public int getMissilesFiredInGame()
			{
				int total = 0;
				
				foreach (PlayerStats pStats in this.playerStatsList)
				{
					total += pStats.missilesFired;
				}
				
				return total;
			}
			
			public int getIncomeOfPlayer(Player player)
			{
				foreach (PlayerStats pStats in this.playerStatsList)
				{
					if (pStats.ownerPlayer == player)
						return pStats.income;
				}
				
				return 0;
			}
			
			public int getCashOfPlayer(Player player)
			{
				foreach (PlayerStats pStats in this.playerStatsList)
				{
					if (pStats.ownerPlayer == player)
						return pStats.cash;
				}
				
				return 0;
			}

		}
}

