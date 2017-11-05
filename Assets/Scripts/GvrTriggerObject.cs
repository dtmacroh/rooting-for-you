using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GvrTriggerObject : MonoBehaviour {


    void Start()
    {
        Event_GazedAt(false);
    }

    public void Event_GazedAt(bool gazedAt)
    {
        //Object is being looked at by reticle
        GetComponent<Renderer>().material.color = gazedAt ? Color.green : Color.red;
    }

    public void Event_ReticleClicked()
    {
        //Object was clicked by reticle
        Debug.Log(this.gameObject.name + " was clicked");
        
    }


    public void Recenter()
    {
#if !UNITY_EDITOR
        GvrCardboardHelpers.Recenter();
#else
    GvrEditorEmulator emulator = FindObjectOfType<GvrEditorEmulator>();
    if (emulator == null) {
      return;
    }
    emulator.Recenter();
#endif  // !UNITY_EDITOR
    }


}
