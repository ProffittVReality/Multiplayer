using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RiderScript : MonoBehaviour {

    GameObject chariot;
    public GameObject cameraRig;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (GameObject.Find("Chariot(Clone)") != null)
        {
            chariot = GameObject.Find("Chariot(Clone)");
            //print(chariot.transform.position);
            cameraRig.transform.position = chariot.transform.position;
        }
    }
}
