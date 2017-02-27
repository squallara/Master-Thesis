using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gameplay : MonoBehaviour {

    public static Gameplay instance;

    public GameObject drums, synth, drums2, synth2;

    CustomDepthImageViewer depthViewer;
    public GameObject mainCam;

    [HideInInspector]
    public bool changed;
    bool active;

    void Start()
    {

        if (instance == null)
        {
            instance = this;
        }
        changed = false;
        active = false;

        depthViewer = mainCam.GetComponent<CustomDepthImageViewer>();
    }

    void Update()
    {
        if(depthViewer.userId2 > 0 && active == false)
        {
            if (drums.activeInHierarchy)
            {
                synth2.gameObject.SetActive(true);
            }
            else if(synth.activeInHierarchy)
            {
                drums2.gameObject.SetActive(true);
            }
            active = true;
        }
        else if(depthViewer.userId2 <= 0)
        {
            active = false;
            drums2.SetActive(false);
            synth2.SetActive(false);
        }
    }
}
