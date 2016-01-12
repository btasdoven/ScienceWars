using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Science_Wars_Server.Database.Models
{
    public class UserDataModel
    {
        public int userId { get; set; }
        public int physPoints { get; set; }
        public int chemPoints { get; set; }
        public int bioPoints { get; set; }
        public bool[] unlockedScienceNodes { get; set; }
    }
}
