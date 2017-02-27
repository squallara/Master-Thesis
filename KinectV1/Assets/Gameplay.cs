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
            synth2.gameObject.SetActive(true);
            active = true;
        }
    }
}
