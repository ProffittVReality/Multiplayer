using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ViveRiderScript : MonoBehaviour {

	GameObject chariot;
	GameObject head;
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
			head.transform.SetParent(chariot.transform);
			isAttached = true;
		}
	}
}
