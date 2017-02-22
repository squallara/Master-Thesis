using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeInstrument : MonoBehaviour {

    public GameObject drums, synth;


    void OnTriggerEnter()
    {
        if (Gameplay.instance.changed == false)
        {
            Gameplay.instance.changed = true;
            if (gameObject.transform.IsChildOf(drums.transform))
            {
                drums.SetActive(false);
                synth.SetActive(true);
            }
            else
            {
                drums.SetActive(true);
                synth.SetActive(false);
            }
        }
    }

    void OnTriggerExit()
    {
        Gameplay.instance.changed = false;
    }
}
