using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OculusCopyScript : Photon.MonoBehaviour {

	public int index = 1;
	
	// Update is called once per frame
	void Update () {
		if (photonView.isMine) {
            switch (index) {
			case 1: //head
                transform.position = OculusManager.Instance.head.transform.position;
                transform.rotation = OculusManager.Instance.head.transform.rotation;
				break;
			}
        }
	}
}
