using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectJoint : MonoBehaviour {

    public GameObject RedBall;
    public Vector3 ballPos;

    public float multiplier = -5f;

    public GetJointPositionDemo jointPos;

	// Use this for initialization
	void Start () {

        jointPos = this.GetComponent<GetJointPositionDemo>();

	}
	
	// Update is called once per frame
	void Update () {

        RedBall.transform.position = jointPos.outputPosition * multiplier;
        ballPos = jointPos.outputPosition;

	}
}
