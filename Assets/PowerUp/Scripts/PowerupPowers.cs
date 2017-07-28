using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupPowers : MonoBehaviour {

	public string powerupType;
	public Animator disappear;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown ("space")) {
			if (powerupType == "Double Points") {
				disappear.SetTrigger ("dblFade");
			} else if (powerupType == "Half Points") {
				disappear.SetTrigger ("halfFade");
			} else if (powerupType == "Slow") {
				disappear.SetTrigger ("turtleFade");
			} else if (powerupType == "Shield") {
				disappear.SetTrigger ("shieldFade");
			}
		}
	}

	void OnTriggerEnter(Collider other) {
		if (other.tag == "Chariot") {
			
			if (powerupType == "Double Points") {
				disappear.SetTrigger ("dblFade");

			} else if (powerupType == "Half Points") {
				disappear.SetTrigger ("halfFade");

			} else if (powerupType == "Slow") {
				disappear.SetTrigger ("turtleFade");

			} else if (powerupType == "Shield") {
				disappear.SetTrigger ("shieldFade");

			}
		}
	}
}
