using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using NetworkIt;

/// <summary>
/// This is another template for sending events via game objects or the UI
/// Need not to use another game object for this purpose. This is to illustrate
/// how to use the system with say a UI object like a checkbox to activate some 
/// functionality
/// </summary>
public class SendPokeTemplate : MonoBehaviour {

    public NetworkItClient networkInterface;
    public bool deliverToSelf = false;

    private int messageCount = 0;

    public void SendPokeMessage()
    {
        //TODO your code here
        Message m = new Message("Poke!");
        m.DeliverToSelf = deliverToSelf;
        m.AddField("num1", "" + 3);
        m.AddField("num2", "" + 4);
        m.AddField("count", "" +  messageCount++);
        networkInterface.SendMessage(m);
    }

    public void SetDeliverToSelf(bool b)
    {
        //TODO your code here
        deliverToSelf = b;
    }
}
