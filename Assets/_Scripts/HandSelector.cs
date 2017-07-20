using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandSelector : MonoBehaviour {

    bool rightTriggerDown;
    bool leftTriggerDown;

    bool handsSet = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (OVRInput.GetDown(OVRInput.Button.SecondaryIndexTrigger))
            rightTriggerDown = true;
        if (OVRInput.GetUp(OVRInput.Button.SecondaryIndexTrigger))
            rightTriggerDown = false;

        if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger))
            leftTriggerDown = true;
        if (OVRInput.GetUp(OVRInput.Button.PrimaryIndexTrigger))
            leftTriggerDown = false;
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Right Hand" && rightTriggerDown && !handsSet)
        {
            ArrowManager.Instance.SetGripHandLeft(false);
            handsSet = true;
        }
        if (other.tag == "Left Hand" && leftTriggerDown && !handsSet)
        {
            ArrowManager.Instance.SetGripHandLeft(true);
            handsSet = true;
        }
    }
}
