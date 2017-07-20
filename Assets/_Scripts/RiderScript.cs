using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RiderScript : MonoBehaviour {

    GameObject chariot;
    GameObject head;
    GameObject left;
    GameObject right;
    public GameObject cameraRig;
    public GameObject avatar;
    bool isAttached = false;

    public GameObject bike;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (!isAttached && GameObject.Find("Chariot(Clone)") != null)
        {
            chariot = GameObject.Find("Chariot(Clone)");
            head = GameObject.Find("Avatar(Clone)");
            //left = GameObject.Find("LHand(Clone)");
            //right = GameObject.Find("RHand(Clone)");

            ArrowManager.Instance.CreateBow(chariot);
            
            Vector3 cameraPosition = chariot.transform.position;
            cameraPosition.z += 1.3f;
            cameraRig.transform.position = cameraPosition;
            avatar.transform.position = cameraPosition;

            bike.transform.position = chariot.transform.position;
            bike.transform.rotation = chariot.transform.rotation;
            bike.SetActive(true);

            cameraRig.transform.SetParent(chariot.transform);
            avatar.transform.SetParent(chariot.transform);
            bike.transform.SetParent(chariot.transform);
            head.transform.SetParent(chariot.transform);
            //left.transform.SetParent(chariot.transform);
            //right.transform.SetParent(chariot.transform);
            isAttached = true;
        }
    }
}
