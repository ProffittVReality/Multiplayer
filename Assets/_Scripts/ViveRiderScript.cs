using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ViveRiderScript : MonoBehaviour {

	GameObject chariot;
	GameObject head;
	GameObject left;
	GameObject right;
	bool isAttached = false;

	// Use this for initialization
	void Start () {
		isAttached = false;
	}

	// Update is called once per frame
	void Update () {
		if (!isAttached && GameObject.Find("Avatar(Clone)") != null)
		{
			chariot = GameObject.Find("Chariot(Clone)");
			head = GameObject.Find("Avatar(Clone)");
			left = GameObject.Find("LHand(Clone)");
			right = GameObject.Find("RHand(Clone)");
			head.transform.SetParent(chariot.transform);
			left.transform.SetParent(chariot.transform);
			right.transform.SetParent(chariot.transform);
			isAttached = true;
		}
	}
}
