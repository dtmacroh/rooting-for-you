using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class horseNeigh : MonoBehaviour {

    public AudioSource src;
    public AudioClip whinny;
    // Use this for initialization
    void Start()
    {
        src = this.GetComponent<AudioSource>();
        // src.clip = whinny;
        //src.Play();
        //StartCoroutine(neigh());
        
    }

    // Update is called once per frame
    void Update()
    {
       
    }
    //IEnumerator neigh()
    //{
        
    //}
}
