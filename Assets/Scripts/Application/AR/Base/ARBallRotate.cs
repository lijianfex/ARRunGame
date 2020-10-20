using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ARBallRotate : MonoBehaviour {
    Transform parent;
	
	void Start () {
        parent = transform.parent;
	}
	
	// Update is called once per frame
	void Update () {
        transform.RotateAround(parent.position, parent.up, 100f * Time.deltaTime);
	}
}
