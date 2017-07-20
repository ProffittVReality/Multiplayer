using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour {

    bool triggerDown;

    private bool isFired = false;

	// Use this for initialization
	void Start () {
        triggerDown = false;
	}
	
	// Update is called once per frame
	void Update () {
        if (OVRInput.GetDown(OVRInput.Button.SecondaryIndexTrigger))
            triggerDown = true;
        if (OVRInput.GetUp(OVRInput.Button.SecondaryIndexTrigger))
            triggerDown = false;

        if (isFired)
        {
            transform.LookAt(transform.position + transform.GetComponent<Rigidbody>().velocity);
        }
    }

    public void IsFired()
    {
        isFired = true;
    }


    private void OnTriggerEnter(Collider collider)
    {
        //print("Tag: " + (collider.tag == "Bow") + ", Button: " + OVRInput.GetDown(OVRInput.Button.SecondaryIndexTrigger));
        if (collider.tag == "Bow" && triggerDown)
            AttachArrow();
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Bow" && triggerDown)
            AttachArrow();
    }

    private void AttachArrow()
    {
        ArrowManager.Instance.AttachBowToArrow();
    }
}
