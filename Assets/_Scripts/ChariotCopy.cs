using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChariotCopy : Photon.MonoBehaviour {
	
	// Update is called once per frame
	void Update () {
		if (photonView.isMine) {
			transform.position = ChariotScript.Instance.bike.transform.position;
			transform.rotation = ChariotScript.Instance.bike.transform.rotation;
		}
	}
}
