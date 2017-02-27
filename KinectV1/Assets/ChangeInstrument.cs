using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeInstrument : MonoBehaviour {

    public GameObject drums, synth, drums2, synth2;


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


    void Update()
    {
        if(drums2.activeInHierarchy || synth2.activeInHierarchy)
        {
            gameObject.SetActive(false);
        }
        else
        {
            gameObject.SetActive(true);
        }
    }


}
