using UnityEngine;
using System.Collections;

public class FloorFollower : MonoBehaviour {

    public Transform gunBarrelEnd;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void LateUpdate () {
        transform.position = new Vector3 (0.0f, gunBarrelEnd.position.y, 0.0f);
	}
}
