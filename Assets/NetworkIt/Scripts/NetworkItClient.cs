using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using NetworkIt;
using System;

public class NetworkItClient : MonoBehaviour {

    [Header("Network Configuration")]
    public string urlAddress = "localhost";
    public int port = 8000;
    public string username = "demo_test_username";

    [Header("Network Event Listeners")]
    [Tooltip("Add game objects here to listen for network events")]
    public GameObject[] eventListeners = new GameObject[0];


    private volatile LinkedList<Message> messageEvents = new LinkedList<Message>();
    private volatile LinkedList<ErrorEventArgs> errorEvents = new LinkedList<ErrorEventArgs>();
    private volatile LinkedList<EventArgs> connectEvents = new LinkedList<EventArgs>();
    private volatile LinkedList<EventArgs> disconnectEvents = new LinkedList<EventArgs>();


    private Client client;

    void Start() {

        if (urlAddress == null || urlAddress.Length <= 0) { 
            Debug.LogError("URL or IP Address required.");
            return;
        }

        if (username == null || username.Length <= 0) { 
            Debug.LogError("Username required.");
            return;
        }

        client = new Client(username, urlAddress, port);            //create and establish connection to server
        client.Connected += Connection_Connected;
        client.Disconnected += Connection_Disconnected;
        client.MessageReceived += Connection_MessageReceived;
        client.Error += Connection_Error;
        client.StartConnection();

    }

    void Update()
    {
        ConsumeNetworkMessages();
    }


    public void SendMessage(Message m)
    {
        client.SendMessage(m);
    }


    //consume messages as they come in
    private void ConsumeNetworkMessages()
    {
        lock (messageEvents)
        {
            while (messageEvents.Count > 0)
            {
                Message m = messageEvents.First.Value;

                foreach (GameObject g in eventListeners)
                {
                    g.SendMessage("NetworkIt_Message", m, SendMessageOptions.DontRequireReceiver);
                }

                messageEvents.RemoveFirst();
            }
        }
       
        lock (errorEvents)
        {
            while (errorEvents.Count > 0)
            {
                System.IO.ErrorEventArgs err = errorEvents.First.Value;

                foreach (GameObject g in eventListeners)
                {
                    g.SendMessage("NetworkIt_Error", err, SendMessageOptions.DontRequireReceiver);
                }

                errorEvents.RemoveFirst();
            }
        }
        
        lock (connectEvents)
        {
            while (connectEvents.Count > 0)
            {
                EventArgs args = connectEvents.First.Value;

                foreach (GameObject g in eventListeners)
                {
                    g.SendMessage("NetworkIt_Connect", args, SendMessageOptions.DontRequireReceiver);
                }

                connectEvents.RemoveFirst();
            }
        }

        lock (disconnectEvents)
        {
            while (disconnectEvents.Count > 0)
            {
                EventArgs args = disconnectEvents.First.Value;

                foreach (GameObject g in eventListeners)
                {
                    g.SendMessage("NetworkIt_Disconnect", args, SendMessageOptions.DontRequireReceiver);
                }

                disconnectEvents.RemoveFirst();
            }
        }
        

    }


    //====================================
    // Network events, consumer-producer pattern required

    private void Connection_MessageReceived(object sender, NetworkItMessageEventArgs e)
    {
        lock (messageEvents)
        {
            messageEvents.AddLast(e.ReceivedMessage);
        }
    }

    private void Connection_Error(object sender, System.IO.ErrorEventArgs err)
    {
        lock (errorEvents)
        {
            errorEvents.AddLast(err);
        }
    }

    private void Connection_Disconnected(object sender, EventArgs e)
    {
        lock (disconnectEvents)
        {
            disconnectEvents.AddLast(new EventArgs());
        }
    }

    private void Connection_Connected(object sender, EventArgs e)
    {
        lock (connectEvents)
        {
            connectEvents.AddLast(new EventArgs());
        }
    }

    



    private void OnApplicationQuit()
    {
        client.CloseConnection();
    }

}
