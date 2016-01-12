using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Science_Wars_Server.Database.Models
{
    public class AccountDataModel
    {
        public int id { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public string email { get; set; }
        public string lastLogin { get; set; }
        public string accountCreateTime { get; set; }
    }
}
