using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicInterface : MonoBehaviour {

    public GameObject musicInterface;
    KinectOverlayer kinectOverlay;

    bool setNewPos = true;

    public float threshold;

    float prevX, prevY, currentX, currentY;

    public float time = 3f;

	// Use this for initialization
	void Start () {

        kinectOverlay = this.GetComponent<KinectOverlayer>();

        

	}
	
	// Update is called once per frame
	void Update () {

        currentX = kinectOverlay.OverlayObject.transform.position.x;
        currentY = kinectOverlay.OverlayObject.transform.position.y;

        float musicIntX = musicInterface.transform.position.x;
        float musicIntY = musicInterface.transform.position.y;

        /*Debug.Log("Time"+time);
        Debug.Log("Delta Time"+Time.deltaTime);*/
        time = time - Time.deltaTime;

        if (time <= 0) { time = 0; }

        if(time == 0)
        {

            prevX = kinectOverlay.OverlayObject.transform.position.x;
            prevY = kinectOverlay.OverlayObject.transform.position.y;
           // Debug.Log("Delta Time" + Time.time);
            time = 3f;
        }

       /* Debug.Log("Prev X = "+prevX+" - Current X = "+currentX);
        Debug.Log("Prev Y = " + prevY + " - Current Y = " + currentY);*/

        float diffX = Mathf.Abs(currentX - prevX);
        float diffY = Mathf.Abs(currentY - prevY);

        float mDiffX = Mathf.Abs(currentX - musicIntX);
        float mDiffY = Mathf.Abs(currentY - musicIntY);

        
        /*
        if (diffX > 3f || diffY > 3f)
        {
            Debug.Log("Diff X " + diffX);
            Debug.Log("Diff Y " + diffY);
            musicInterface.transform.position = kinectOverlay.OverlayObject.transform.position;

            currentX = kinectOverlay.OverlayObject.transform.position.x;
            currentY = kinectOverlay.OverlayObject.transform.position.y;
            prevX = kinectOverlay.OverlayObject.transform.position.x;
            prevY = kinectOverlay.OverlayObject.transform.position.y;

        }*/

        if(mDiffX > threshold || mDiffY > threshold)
        {

            //Debug.Log("Diff X " + mDiffX);
           // Debug.Log("Diff Y " + mDiffY);
            musicInterface.transform.position = kinectOverlay.OverlayObject.transform.position;

        }
        
		
	}
}
