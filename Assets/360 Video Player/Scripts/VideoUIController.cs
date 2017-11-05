using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class VideoUIController : MonoBehaviour {

    public VideoPlayer playerToControl;

    private AudioSource audioSource;
    private float oldVolume = 1.0f;

    private void Start()
    {
        audioSource= playerToControl.gameObject.GetComponent<AudioSource>();
        oldVolume = audioSource.volume;
    }


    public void TogglePause()
    {
        if (playerToControl.isPlaying)
        {
            playerToControl.Pause();
        }
        else
        {
            playerToControl.Play();
        }
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
