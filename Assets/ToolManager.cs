using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NetworkIt;

public class ToolManager : MonoBehaviour {
   // public NetworkItClient networkInterface;
    public bool deliverToSelf = false;

    private int messageCount = 0;
    public string tool = "";
	
    // Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
   

    //public void SendToolMessage(string tool)
    //{
    //    //TODO your code here
    //    Message m = new Message("message");
    //    m.DeliverToSelf = deliverToSelf;
    //    m.AddField("tool", tool);
    //    networkInterface.SendMessage(m);
    //}

    //public void SetDeliverToSelf(bool b)
    //{
    //    //TODO your code here
    //    deliverToSelf = b;
    //}
    public void shovel()
    {
        tool = "shovel";
        //SendToolMessage(tool);

    }
    public void wateringcan()
    {
        tool = "wateringcan";
       // SendToolMessage(tool);
    }
}
