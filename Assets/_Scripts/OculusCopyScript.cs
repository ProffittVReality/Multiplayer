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
			/*case 2: //left
				transform.position = OculusManager.Instance.leftHand.transform.position;
				transform.rotation = OculusManager.Instance.leftHand.transform.rotation;
				break;
			case 3: //right
				transform.position = OculusManager.Instance.rightHand.transform.position;
				transform.rotation = OculusManager.Instance.rightHand.transform.rotation;
				break;*/
			}
        }
	}
}
