using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Science_Wars_Server.Database.Models
{
    public class UserStatsModel
    {
        int userId { get; set; }

        int physGamesPlayed { get; set; }
        int chemGamesPlayed { get; set; }
        int bioGamesPlayed { get; set; }

        int physGoldMedals{ get; set; }
        int chemGoldMedals { get; set; }
        int bioGoldMedals { get; set; }

        int physSilverMedals{ get; set; }
        int chemSilverMedals { get; set; }
        int bioSilverMedals { get; set; }

        int physBronzeMedals { get; set; }
        int chemBronzeMedals { get; set; }
        int bioBronzeMedals { get; set; }
    }
}
