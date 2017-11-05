using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeScene : MonoBehaviour {

	// Use this for initialization
	void Start () {
        // Will attach a VideoPlayer to the main camera.
        GameObject camera = GameObject.Find("Main Camera");

        // VideoPlayer automatically targets the camera backplane when it is added
        // to a camera object, no need to change videoPlayer.targetCamera.
        var videoPlayer = camera.AddComponent<UnityEngine.Video.VideoPlayer>();

        videoPlayer.url = "C:\\Users\\Debbie\\Documents\\Project2Test\\Assets\\360 Video Player\\Videos\\Explore Drumheller’s Badlands in 360-1.mp4";
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
