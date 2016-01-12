using Science_Wars_Server.Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Science_Wars_Server.Database
{
    public interface IDatabaseAccessLayer
    {
        bool credentialCheck(string username, string password, out int userId);

        bool getAccountInfo(int userId, out AccountDataModel accountData);

        bool getUserData(int userId,int scienceNodeCount, out UserDataModel userData);

        bool getUserStats(int userId, out UserStatsModel userStats);

        void openScienceNode(int userId, bool [] unlockedScienceNodes);
    }
}
