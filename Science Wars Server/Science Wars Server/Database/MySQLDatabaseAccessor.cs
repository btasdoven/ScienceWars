using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using Science_Wars_Server.ScienceTrees.ScienceNodes;
using Science_Wars_Server.GameUtilities;

namespace Science_Wars_Server.Database
{
    class MySQLDatabaseAccessor : IDatabaseAccessLayer
    {
        private MySql.Data.MySqlClient.MySqlConnection client;
         
        public MySQLDatabaseAccessor(string ip, int port, string schemaName, string username, string password)
        {
            client = new MySql.Data.MySqlClient.MySqlConnection(
                "Server= '" + ip + "' ; Port=" + port + "; Database= '" + schemaName + "' ;Uid= '" + username +"' ;Pwd= '" + password + "' ");
            client.Open();
        }

        public bool credentialCheck(string username, string password, out int userId)
        {
            userId = 0;

            
            /*Byte[] hash;    // we will use this in the query
            var salt = "LesKoding";     // Our app spesific key. To prevent our app from direct attacks
            var pass_data = Encoding.UTF8.GetBytes(salt + password);   // Convert password to Byte[]
            using (SHA512 shaM = new SHA512Managed())
            {
                hash = shaM.ComputeHash(pass_data);             
            }*/
            

            MySqlCommand com = client.CreateCommand();
            com.CommandText = "SELECT * FROM accountdata WHERE username='" + username + "' AND password ='" + password + "'";
            com.Connection = client;

            MySqlDataReader reader = null;
            try
            {
                reader = com.ExecuteReader(new System.Data.CommandBehavior());

                if (reader.Read())  // tek column okusak yeter, o yuzden while yapmadim.
                {
                    userId = reader.GetInt32("id");
                    return true;
                }
                else
                    return false;
            }
            catch
            {
                return false;
            }
            finally
            {
                try
                {
                    reader.Close();
                }
                catch { }
            }
        }

        public bool getAccountInfo(int userId, out Models.AccountDataModel accountData)
        {
            throw new NotImplementedException();
        }

        public bool getUserData(int userId, int scienceNodeCount, out Models.UserDataModel userData)
        {
            userData = new Models.UserDataModel();
            MySqlCommand com = client.CreateCommand();
            com.CommandText = "SELECT * FROM userdata WHERE userid=" + userId;
            com.Connection = client;

            MySqlDataReader reader=null;
            try
            {
                reader = com.ExecuteReader(new System.Data.CommandBehavior());

                if (reader.Read())  // tek column okusak yeter, o yuzden while yapmadim.
                {
                    userData.userId = userId;
                    userData.physPoints = (int)reader["physpoints"];
                    userData.chemPoints = (int)reader["chempoints"];
                    userData.bioPoints  = (int)reader["biopoints"];

                    byte[] scienceNodesByte = (byte[])reader["unlockedsciencenodes"];

                    bool[] unlockedScienceNodeDbIds = new bool[scienceNodeCount];
                    
                    for (int i = 0; i < scienceNodeCount && i < scienceNodesByte.Length * 8; i++)
                    {
                        unlockedScienceNodeDbIds[i] = ( scienceNodesByte[i/8] & (1 << (i%8 ) )) != 0;

                    }

                    userData.unlockedScienceNodes = new bool[scienceNodeCount];

                    foreach (var nodeDbIdPair in ScienceNode.scienceNodeDbIds)  // dbId'leri, typeId ye donusturuyoruz. Cunku db disinda bize lazim degil dbId. indexlerde hep typeId lazim.
                    {
                        userData.unlockedScienceNodes[TypeIdGenerator.getScienceNodeIds(nodeDbIdPair.Key.GetType())] = unlockedScienceNodeDbIds[nodeDbIdPair.Value];
                    }

                    return true;
                }
                else
                    return false;
            }
            catch
            {
                return false;
            }
            finally
            {
                try
                {
                    reader.Close();
                }
                catch { }
            }
        }

        public void openScienceNode(int userId,bool [] unlockedScienceNodes)
        {

           
            string blobString = "b'";

            for(int i = 0; i < unlockedScienceNodes.Length; i++)
            {
                if (unlockedScienceNodes[unlockedScienceNodes.Length-i-1])
                    blobString += "1";
                else
                    blobString += "0";
            }
            blobString += "'";

            MySqlCommand com = client.CreateCommand();
            com.CommandText = "UPDATE userdata SET unlockedsciencenodes = " + blobString + "  WHERE userid='" + userId + "'";
            com.Connection = client;
            com.ExecuteNonQuery();

        }


        public bool getUserStats(int userId, out Models.UserStatsModel userStats)
        {
            throw new NotImplementedException();
        }
    }
}
