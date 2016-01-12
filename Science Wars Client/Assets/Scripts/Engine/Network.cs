using System.Collections.Generic;
using Assets.Scripts.Engine.GameUtilities;
using NetWorker.Guest;
using UnityEngine;
using NetWorker.Utilities;
using NetWorker.EventArgs;
using System.Threading;
using System.Collections;
using System;

namespace Assets.Scripts.Engine
{
    public class Network : MonoBehaviour
    {
        public static Server server;
        public static SslStreamObject sslStream;

        public static Queue<RawMessage> messages = new Queue<RawMessage>();

        // Use this for initialization
        void Start () {
            
            DontDestroyOnLoad(this);
            
            server = new Server();

            server.messageArrivedEvent += server_messageArrivedEvent; 
            server.connectionLostEvent += server_connectionLostEvent;

			connect();			
		}

		public static void connect() 
		{
			Runner.Graphics.tryingToConnect();
            thread_connect();
			//Thread t = new Thread(new ThreadStart(thread_connect));
			//t.Start ();            
		}

		private static void thread_connect()
		{
			try {
				//server.Connect("127.0.0.1",12122);		// Seni
                //server.Connect("192.168.1.6", 12122);		// Seni
				server.Connect("54.194.70.151",12122);			// amazon supersonikserver                				
                Runner.Graphics.connectionSuccessful();
				Debug.Log ("Successfully connected");
				sslStream = server.createSslStreamObject(true);
				sslStream.AuthenticateAsClient("essoperagma");
			}
			catch(Exception exc) {
                Debug.Log("errrrr:" + exc.Message);

				Runner.Graphics.connectionFailed();
				return;
			}
			Debug.Log ("Ssl Connection is ready.");
		}

        void server_connectionLostEvent(object sender, System.EventArgs e)
        {
			//TODO
        }

        void server_messageArrivedEvent(object sender, MessageArrivedEventArgs e)
        {
			lock (messages)
                messages.Enqueue(e.message);
        }

        void OnApplicationQuit()
        {
			if (server != null)
            	server.Disconnect();
        }

		void Update() 
		{
            lock (messages)
            {
                RawMessage msg;
                while (messages.Count != 0)
                {
                    msg = messages.Dequeue();
                    TypeIdGenerator.getMessageClass(msg.getInt("id")).processMessage(msg);
                }
            }
		}
    }



}
