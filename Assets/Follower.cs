using UnityEngine;
using System.Collections;

public class Follower : MonoBehaviour {

    GameObject target;
    public string tagName;

    Vector3 offset;
	// Use this for initialization
	void Start () {
        target = GameObject.FindWithTag(tagName);
        offset = transform.position - target.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
        transform.position = target.transform.position + offset;
	}
}
