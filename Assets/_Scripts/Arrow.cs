using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour {

    bool triggerDown;

    private bool isFired = false;

    bool onePoint = false;
    bool twoPoint = false;
    bool threePoint = false;
    bool fourPoint = false;
    bool fivePoint = false;

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
        if (collider.tag == "Bow" && triggerDown)
            AttachArrow();
        if (collider.tag == "One Point")
            onePoint = true;
        if (collider.tag == "Two Point")
            twoPoint = true;
        if (collider.tag == "Three Point")
            threePoint = true;
        if (collider.tag == "Four Point")
            fourPoint = true;
        if (collider.tag == "Five Point")
            fivePoint = true;
        if (collider.tag == "Target")
        {
            Rigidbody r = GetComponent<Rigidbody>();
            // set velocity to 0
            r.velocity = new Vector3(0f, 0f, 0f);
            // turn off gravity
            r.useGravity = false;
            CollectPoints();
        }
    }

    private void OnTriggerStay(Collider collider)
    {
        if (collider.tag == "Bow" && triggerDown)
            AttachArrow();

        if (collider.tag == "One Point")
            onePoint = true;
        if (collider.tag == "Two Point")
            twoPoint = true;
        if (collider.tag == "Three Point")
            threePoint = true;
        if (collider.tag == "Four Point")
            fourPoint = true;
        if (collider.tag == "Five Point")
            fivePoint = true;
    }

    private void AttachArrow()
    {
        ArrowManager.Instance.AttachBowToArrow();
    }

    private void CollectPoints()
    {
        if (fivePoint)
            PointSystem.Instance.AddPoints(5);
        else if (fourPoint)
            PointSystem.Instance.AddPoints(4);
        else if (threePoint)
            PointSystem.Instance.AddPoints(3);
        else if (twoPoint)
            PointSystem.Instance.AddPoints(2);
        else if (onePoint)
            PointSystem.Instance.AddPoints(1);
    }


}
