using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using Science_Wars_Server.Database;
using Science_Wars_Server.Sessions;
using Science_Wars_Server.GameUtilities;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using NetWorker.Utilities;

namespace Science_Wars_Server
{
    class LoginManager
    {
        //private static X509Certificate certificate;

        public Runner runner { get; private set; }
        public Session session {get; private set;}
        public IDatabaseAccessLayer dal { get; private set; }

        static LoginManager()
        {
            //if( certificate == null)
                //certificate = new X509Certificate2("ScienceWars_SSL_certificate.pfx", "1234asdf");
        }

        public LoginManager(Runner runner, Session session, IDatabaseAccessLayer dal)
        {
            this.runner = runner;
            this.session = session;
            this.dal = dal;
        }

        public void launch()
        {
            Thread thread = new Thread(new ThreadStart(loginProcess));  // TODO bunu thread pool a koymak lazim hizli olsun diye. ancak thread pool singleton, networker da kullaniyor. dikkat.
            thread.IsBackground = true;
            thread.Start();
        }

        private void loginProcess()
        {
            string username;
            string password;
			
			string certPassword = "********";
			X509Certificate certificate = new X509Certificate2("ScienceWars_SSL_certificate.pfx", certPassword);
            
            SslStreamObject sslStream = session.client.createSslStreamObject(true);
            try
            {
                sslStream.AuthenticateAsServer(certificate);
            }
            catch (Exception e)
            {
                return;
            }

            while (true)
            {
                RawMessage message = sslStream.ReadSingleMessage();

                if (message == null)
                    return;

                username = message.getUTF8String("username"); // TODO exception check
                password = message.getUTF8String("password");
                
                int userId = 0;
                if (dal.credentialCheck(username,password,out userId)) //username, password, out userId))
                {
                    Database.Models.UserDataModel userData = new Database.Models.UserDataModel();

                    if (dal.getUserData(userId, TypeIdGenerator.getScienceNodeCount(), out userData))
                    {
                        //TODO unlocked Science Nodes bize dbId olarak geliyor ancak biz o id yi sanki isimden uretilen typeId si gibi kullaniyoruz. burada bir convert yapmak lazim
                        // aldigin unlockedScienceNodes arrayindeki her bir indexi dbId olarak tutan scienceNode u bul, o nodun typeId sini al, o typeId yi index olarak kullanarak yeni bir bool[] doldur.
                        // yeni olusturdugun bool array i User konstraktirina gonder.

                        sendLoginResponse(sslStream, true, "successful");                        
                        //sslStream.Close();        // DUE TO A BUG -kardeslerim- WE CANNOT CLOSE THE STREAM.
                                                    // Cunku close yaparsak, nereden geldigi belirsiz 37 byte, client'a ait messageListenera dusuyor. 
                                                    // sadece unity'de oluyor, .net'te duzgun calisiyor. Muhtemelen Mono kaynakli bir sorun.
                        
                        session.client.ListenForMessages();
                        User user = new User(session, username , userData.physPoints, userData.chemPoints, userData.chemPoints, userData.unlockedScienceNodes);
                        runner.userLoggedIn(user);
                        return;
                    }
                    else
                        sendLoginResponse(sslStream, false, "cannot retrieve user data");
                }
                else
                    sendLoginResponse(sslStream, false, "wrong username or password");
            }
        }

        private void sendLoginResponse(SslStreamObject sslStreamObject, bool response, string reason)
        {
            RawMessage message = new RawMessage();
            message.putBool("response", response);
            message.putUTF8String("reason", reason);

            sslStreamObject.WriteSingleMessage(message);
        }
    }
}
