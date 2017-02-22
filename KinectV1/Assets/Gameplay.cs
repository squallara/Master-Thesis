using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gameplay : MonoBehaviour {

    public static Gameplay instance;

    [HideInInspector]
    public bool changed;

    void Start()
    {

        if (instance == null)
        {
            instance = this;
        }
        changed = false;
    }
}
