using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
using UnityEngine.Video;
using UnityEngine.SceneManagement;
public class highlight_patch : MonoBehaviour {
    private MeshRenderer mesh;
    public bool shovel;
    public bool wateringcan;
    public bool stick;
    public bool tree;
    public int order;
    public bool complete;
    public AudioSource src;
    public AudioClip shovelAdvice;
    public AudioClip treeAdvice;
    public AudioClip stickAdvice;
    public AudioClip selectPatch;
    public AudioClip wateringCanSound;
    public AudioClip shovelSound;
    public AudioClip generalSound;
    public bool spotChosen;

    public VideoPlayer playerToControl;

 
    // Use this for initialization
    void Start () {
        mesh = this.GetComponent<MeshRenderer>();
        //mesh.material.color = new Color(15.0f, 116.0f, 2.0f);
        Debug.Log(mesh.material.color);
         src = this.GetComponent<AudioSource>();
        
        
    }
	
	// Update is called once per frame
	void Update () {
		
	}
    public void GazeAt()
    {
        if (!shovel &&!spotChosen)
        {
            // mesh.material.color = new Color(102.0f, 255.0f, 51.0f);
            mesh.material.color = new Color(1.0f, 1.0f, 0.0f);
        }
    }

    public void LookAway()
    {
        if (!shovel &&!spotChosen)
        {
            mesh.material.color = new Color(0.059f, 0.456f, 0.007f);
        }
    }

    public void shovelChosen()
    {
        src.clip = shovelSound;
        src.Play();
        shovel = true;
        order++;
        if (shovel)
        {
           
            mesh.material.color = new Color(0.0f, 0.0f, 0.0f);
        }

    }
    public void treeChosen()
    {
        src.clip = generalSound;
        src.Play();
        order++;
       tree = true;

        Renderer meshTree = GameObject.Find("tree").GetComponent<Renderer>();
       
       
        Debug.Log(meshTree.isVisible);

        if (shovel && tree)
        {
            meshTree.enabled = true;
            mesh.material.color = new Color(0.0f, 1.0f, 0.0f);
        }
    }
    public void stickChosen()
    {
        src.clip = generalSound;
        src.Play();
        order++;
        stick = true;

        Renderer meshStick = GameObject.Find("stick_in_patch").GetComponent<Renderer>();
        GameObject gTree = GameObject.Find("tree");
        if (shovel && stick && tree)
        {
            meshStick.enabled = true;
            gTree.transform.rotation = Quaternion.Euler(3.0f, -70.0f, -10.0f);
            src.clip = stickAdvice;
            src.Play();
        }
       
    }
    public void wateringCanChosen()
    {
        Debug.Log("wateringcan");
        src.clip = wateringCanSound;
        src.Play();
        order++;
        wateringcan = true;
  
        if (shovel && wateringcan&&stick&&tree)
        {
            complete = true;
           
        }
    }
    public void saySomething()
    {
        if (order > 5)
        {
            if(!shovel)
            {
                src.clip = shovelAdvice;
                src.Play();
                order = 0;
            }
            else if (!tree)
            {
                src.clip = treeAdvice;
                src.Play();
                order = 0;
            }
        }
    }

    public void patchChosen()
    {
        if (!spotChosen)
        {
            src.clip = selectPatch;
            src.Play();
            spotChosen = true;
        }
        Renderer meshStick = GameObject.Find("stick").GetComponent<Renderer>();
        Renderer meshTree = GameObject.Find("tree_on_ground").GetComponent<Renderer>();
        Renderer meshShovel1 = GameObject.Find("Cube").GetComponent<Renderer>();
        Renderer meshShovel2 = GameObject.Find("Cylinder").GetComponent<Renderer>();
        Renderer meshwateringCan = GameObject.Find("Cube.001").GetComponent<Renderer>();
        meshStick.enabled = true;
        meshTree.enabled = true;
        meshShovel1.enabled = true;
        meshShovel2.enabled = true;
        meshwateringCan.enabled = true;
        
    }
    public void moveToFinalScene()
    {
        if (complete)
        {
            SceneManager.LoadScene("niceforest");
        }
        else
        {
            SceneManager.LoadScene("wasteland");
        }

    }
  
//    public void GoNearer()
//    {
//        // this.transform.localScale += new Vector3(1.0f, 0.0f, 1.0f);
//        GameObject cam = GameObject.Find("SetCameraDefault");
//        cam.transform.rotation = Quaternion.Euler(29f, 91f, 2.74f);
//        Vector3 nearPosition = new Vector3(-9.7f, -5f,-16f );
//        cam.transform.localPosition = nearPosition;
//        Debug.Log(cam.transform.localPosition);
//}
}
