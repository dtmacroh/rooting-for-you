using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flyBird : MonoBehaviour {
    public Transform target;
    public float speed;
	// Use this for initialization
	void Start () {
       
	}
	
	// Update is called once per frame
	void Update () {
        Invoke("gotoFinalPos", 10);
	}
    void gotoFinalPos()
    {
       
        float step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, target.position, step);
    }
}
