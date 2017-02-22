using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicInterface : MonoBehaviour {

    public GameObject musicInterface, LeftHandCol, RightHandCol;
    KinectOverlayer kinectOverlay;

    bool setNewPos = true;

    public float threshold, depthThreshold;

    float prevX, prevY, currentX, currentY;

    public float time = 3f;

    public bool useDepth;

    Rigidbody left, right;

    float zPos;

    // Use this for initialization
    void Start () {

        kinectOverlay = this.GetComponent<KinectOverlayer>();
        

    }
	
	// Update is called once per frame
	void Update () {

        if((LeftHandCol == null || RightHandCol == null) && useDepth == true)
        {
            LeftHandCol = GameObject.Find("HandLeftCollider");
            RightHandCol = GameObject.Find("HandRightCollider");

            left = LeftHandCol.gameObject.AddComponent<Rigidbody>();
            right = RightHandCol.gameObject.AddComponent<Rigidbody>();

            left.useGravity = false;
            right.useGravity = false;

            left.isKinematic = true;
            right.isKinematic = true;
        }

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

        if((mDiffX > threshold || mDiffY > threshold) && useDepth == false)
        {

            //Debug.Log("Diff X " + mDiffX);
           // Debug.Log("Diff Y " + mDiffY);
            musicInterface.transform.position = kinectOverlay.OverlayObject.transform.position;

        }

        if(useDepth == true)
        {


            DepthPlacement();

            if (mDiffX > threshold || mDiffY > threshold)
            {
                Vector3 depthPos = new Vector3(kinectOverlay.OverlayObject.transform.position.x, kinectOverlay.OverlayObject.transform.position.y, zPos);
                musicInterface.transform.position = depthPos;
            }
                

        }
        
		
	}

    void DepthPlacement()
    {

        KinectManager manager = KinectManager.Instance;

        if (musicInterface && manager && manager.IsInitialized() && manager.IsUserDetected())
        {
            uint userId = manager.GetPlayer1ID();
            Vector3 posUser = manager.GetUserPosition(userId);

            
            zPos = posUser.z;


            
        }

    }

}
