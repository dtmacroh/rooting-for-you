using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;
public class VideoUIController : MonoBehaviour {

    public VideoPlayer playerToControl;

    private AudioSource audioSource;
    private float oldVolume = 1.0f;
    private Dictionary<string,string> refer;

    private void Start()
    {
        audioSource= playerToControl.gameObject.GetComponent<AudioSource>();
        oldVolume = audioSource.volume;
        refer = new Dictionary<string, string>();
        refer.Add("fire", "classroom");
        refer.Add("classroom", "onboarding");
        refer.Add("onboarding", "fortmacroad");
        refer.Add("fortmacroad", "plantingsimulator");


    }


    public void TogglePause()
    {
        
       SceneManager.LoadScene("wasteland");
        playerToControl.Pause();

    }

    public void ToggleMute()
    {
        if (audioSource.volume > 0.0f)
        {
            oldVolume = audioSource.volume;
            audioSource.volume = 0.0f;
        }
        else
        {
            audioSource.volume = oldVolume;
        }
    }
}
