using System;

using UnityEngine;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Quobject.SocketIoClientDotNet.Client;
using System.IO;

namespace NetworkIt
{

    public class NetworkItMessageEventArgs : EventArgs
    {
        public Message ReceivedMessage { get; set; }

        public NetworkItMessageEventArgs(Message receivedMessage)
        {
            this.ReceivedMessage = receivedMessage;
        }
    }

    public class Client
    {
        private string username = "demo_test_username";
        private string url = "localhost";
        private int port = 8000;
        private Socket client;

        public string IPAddress
        {
            get
            {
                return this.url;
            }
        }

        public int Port
        {
            get
            {
                return this.port;
            }
        }

        public string Username
        {
            get
            {
                return this.username;
            }
        }

        public void StartConnection()
        {
            //ensure only one client is open at a time
            if (this.client != null)
            {
                client.Close();
            }

            //connect
            this.client = IO.Socket(url + ":" + port);

            this.client.On(Socket.EVENT_CONNECT, (fn) =>
            {
                Debug.Log("Connection Successful");

                JObject connectJson = new JObject();
                connectJson.Add("username", username);
                connectJson.Add("platform", "Unity");
                this.client.Emit("client_connect", connectJson);

                RaiseConnected(new EventArgs());

            });

            this.client.On(Socket.EVENT_DISCONNECT, (data) =>
            {
                Debug.Log("Client Disconnected");
                RaiseDisconnected();
            });

            this.client.On(Socket.EVENT_ERROR, (e) =>
            {
                Exception ex = (Exception) e;
                Debug.LogError("Error!" + ex.Message);
                RaiseError(ex);
            });

            this.client.On(Socket.EVENT_MESSAGE, (data) =>
            {
                Message recv = ((JObject)data).ToObject<Message>();
                Debug.Log("Message Recieved: " + data.ToString());
                RaiseMessageReceived(new NetworkItMessageEventArgs(recv));
            });

            

        }

        public void CloseConnection()
        {
            this.client.Close();
        }

        public void SendMessage(Message message)
        {
            this.client.Emit("message", JObject.FromObject(new
            {
                username = this.username,
                deliverToSelf = message.DeliverToSelf,
                subject = message.Subject,
                fields = message.Fields
            }));
        }


        #region Custom Events

        public event EventHandler<EventArgs> Connected;

        private void RaiseConnected(EventArgs e)
        {
            //event args e is usually empty
            if (Connected != null)
            {
                Connected(this, new EventArgs());
            }
        }

        public event EventHandler<ErrorEventArgs> Error;

        private void RaiseError(Exception e)
        {
            if (Error != null)
            {
                Error(this, new ErrorEventArgs(e));
            }
        }

        public event EventHandler<NetworkItMessageEventArgs> MessageReceived;

        private void RaiseMessageReceived(NetworkItMessageEventArgs e)
        {
            if (MessageReceived != null)
            {
                MessageReceived(this, e);
            }
        }

        public event EventHandler<EventArgs> Disconnected;

        private void RaiseDisconnected()
        {            
            //event args e is usually empty
            if (Disconnected != null)
            {
                Disconnected(this, new EventArgs());
            }
        }


        #endregion


        /// <summary>
        /// Use the default client settings
        /// </summary>
        public Client()
        {
            this.Initialize(this.username, this.url, this.port);
        }


        /// <summary>
        /// Connect client to the server using specified settings
        /// </summary>
        /// <param name="username"></param>
        /// <param name="ipAddress">Must include the http protocol "http://"</param>
        /// <param name="port"></param>
        public Client(string username, string url, int port)
        {
            this.Initialize(username, url, port);
        }

        private void Initialize(string username, string url, int port)
        {
            this.username = username;
            this.port = port;

            if (url.IndexOf("http://") != 0)
            {
                this.url = "http://" + url;
            }
            else
            {
                this.url = url;
            }

        }



    }
}
