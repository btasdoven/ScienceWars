using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.Scripts.Engine;
using Assets.Scripts.Engine.Statistics;

namespace Assets.Scripts.Engine.Statistics
{
	public interface IStatTracker
	{
		
		#region Money Related
		
		float getMoneyEarnedByPlayer(Player player);
		
		float getMoneySpendByPlayer(Player player);
		
		float getTotalMoneySpendInGame();
		
		float getTotalMoneyEarnedInGame();
		
		#endregion
		
		#region Minion Related
		
		int getMinionsSendByPlayer(Player player);
		
		int getMinionsKilledByPlayer(Player player);
		
		int getMinionsSendInGame();
		
		int getMinionsKilledInGame();
		
		#endregion
		
		#region Tower Related
		
		int getTowersBuiltByPlayer(Player player);
		
		int getTowersBuiltInGame();
		
		#endregion
		
		#region Minion Pass
		
		int getMinionsPassedOfPlayer(Player player);
		
		int getMinionsPassedInGame();
		
		#endregion
		
		#region Missiles Related
		
		int getMissilesFiredByPlayer(Player player);
		
		int getMissilesFiredInGame();
		
		#endregion
		
		#region Getter/Setter
		PlayerStats getPlayerStatsOfPlayer(Player player);
		
		#endregion

		#region income/cash
		
		int getIncomeOfPlayer(Player player);
		
		int getCashOfPlayer(Player player);
		
		#endregion
		
		
		
	}
}

