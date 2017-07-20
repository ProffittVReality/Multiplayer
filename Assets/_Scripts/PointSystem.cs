using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointSystem : MonoBehaviour {

	int points;
	int timeRemaining;

	PhotonView photonView;

    public static PointSystem Instance;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
    }

    private void OnDestroy()
    {
        if (Instance == this)
            Instance = null;
    }

    // Use this for initialization
    void Start () {
		points = 0;		
		photonView = PhotonView.Get (this);
	}

	void Update() {

	}

	// local method
	public void AddPoints(int amnt) {
		photonView.RPC ("PunAddPoints", PhotonTargets.All, amnt);
	}

	// local method
	public void SubtractPoints(int amnt) {
		photonView.RPC ("PunSubtractPoints", PhotonTargets.All, amnt);
	}

	// method to update all point managers
	[PunRPC]
	void PunAddPoints(int amnt) {
		points += amnt;
        print("points: " + points);
	}

	// method to update all point managers
	[PunRPC]
	public void PunSubtractPoints(int amnt) {
		points -= amnt;
		// cannot have negative points
		if (points < 0)
			points = 0;
	}

	// local getter
	public int GetPoints() {
		return points;
	}

	// local getter
	public int GetSecondsRemaining() {
		return timeRemaining;
	}
}
