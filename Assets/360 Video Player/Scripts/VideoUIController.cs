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
       


    }
   
    public void goToPlanting()
    {
        Debug.Log("the end is near");
        SceneManager.LoadScene("plantingsimulation");
        playerToControl.Pause();
    }

    public void goToClassroom()
    {
        SceneManager.LoadScene("classroom");
        playerToControl.Pause();

    }
    public void goToFire()
    {
        SceneManager.LoadScene("fire");
        playerToControl.Pause();

    }

    public void goToOnboarding()
    {
        SceneManager.LoadScene("fortmacroad");
        playerToControl.Pause();

    }

    public void goToForest()
    {
        SceneManager.LoadScene("forest");
        playerToControl.Pause();

    }
    public void goToWasteland()
    {
        SceneManager.LoadScene("wasteland");
        playerToControl.Pause();

    }
    public void TogglePause()
    {
        
      // SceneManager.LoadScene("wasteland");
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
