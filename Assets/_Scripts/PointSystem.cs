using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointSystem : MonoBehaviour {

	int points;
	int timeRemaining;

	// Use this for initialization
	void Start () {
		points = 0;		
	}

	void Update() {
		print (points);
		if (Input.GetKeyDown ("space")) {
			PhotonView photonView = PhotonView.Get (this);
			photonView.RPC ("AddPoints", PhotonTargets.All, 1);
		}
	}

	[PunRPC]
	void AddPoints(int amnt) {
		points += amnt;
	}

	[PunRPC]
	public void SubtractPoints(int amnt) {
		points -= amnt;
		// cannot have negative points
		if (points < 0)
			points = 0;
	}

	public int GetPoints() {
		return points;
	}

	public int GetSecondsRemaining() {
		return timeRemaining;
	}
}
