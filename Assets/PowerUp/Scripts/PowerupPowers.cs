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

	}

	void OnTriggerEnter(Collider other) {
		if (other.tag == "Chariot") {
			if (powerupType == "Double Points") {
				disappear.SetTrigger ("dblFade");
				PointSystem.Instance.DoublePointMode (true);

			} else if (powerupType == "Half Points") {
				disappear.SetTrigger ("halfFade");
				PointSystem.Instance.NoPointMode (true);

			} else if (powerupType == "Slow") {
				disappear.SetTrigger ("turtleFade");
				VZPlayer.Instance.HalfSpeed (PointSystem.Instance.disabilityTime);
				PointSystem.Instance.SlowMode (true);

			} else if (powerupType == "Shield") {
				disappear.SetTrigger ("shieldFade");
				PointSystem.Instance.ShieldMode (true);
			}
		}
	}
}
