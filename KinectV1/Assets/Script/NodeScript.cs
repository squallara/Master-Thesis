using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeScript : MonoBehaviour {

    public Color trigColor, objColor;

    public AudioClip instrument;

    AudioSource audio;

    Material myMat;

    public float countDown = 2.0f;

    bool activeTimer;

    float timer;

	// Use this for initialization
	void Start () {
        myMat = this.GetComponent<Renderer>().material;
        objColor = myMat.color;

        this.gameObject.AddComponent<AudioSource>();

        audio = GetComponent<AudioSource>();

        timer = countDown;

        activeTimer = false;
	}

    void Update()
    {

        if(activeTimer == true)
        {
            timer = timer - Time.deltaTime;
        }
        
        if( timer <= 0)
        {
            timer = 0;
        }
        

    }
	

    void OnTriggerEnter()
    {
        //Debug.Log("Triggered");
        myMat.color = trigColor;
        audio.PlayOneShot(instrument,0.2f);
        activeTimer = true;
        timer = countDown;
    }


    void OnTriggerStay()
    {
        activeTimer = true;
        Debug.Log("On Trigger Stay");
        myMat.color = trigColor;
        if (timer == 0)
        {
            Debug.Log("Audio Not Playing");
            audio.PlayOneShot(instrument, 0.2f);
            timer = countDown;
        }
        

    }


    void OnTriggerExit(Collider other)
    {
        activeTimer = false;
        //timer = countDown;
        //Debug.Log("Exited");
        myMat.color = objColor;
    }
}
