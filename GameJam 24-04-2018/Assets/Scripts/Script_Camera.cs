using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script_Camera : MonoBehaviour {

    public GameObject ObjectToFollow;
    public float FollowDistanceZ;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        transform.position = new Vector3(ObjectToFollow.transform.position.x, ObjectToFollow.transform.position.y, ObjectToFollow.transform.position.z + FollowDistanceZ);
	}
}
