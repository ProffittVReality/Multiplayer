using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointSystem : MonoBehaviour {

	int points;
	int timeRemaining;

	public float disabilityTime;

	bool slowMode;
	bool shieldMode;
	bool noPointMode;
	bool doublePointMode;

	public GameObject yellowSphere;
	public GameObject blueSphere;
	public GameObject redSphere;
	public GameObject greenSphere;

	public UnityEngine.UI.Text scoreText;

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
		yellowSphere.SetActive (slowMode);
		blueSphere.SetActive (shieldMode);
		redSphere.SetActive (noPointMode);
		greenSphere.SetActive (doublePointMode);
		scoreText.text = "score: " + points.ToString();
	}

	// local method
	public void AddPoints(int amnt) {
		photonView.RPC ("PunAddPoints", PhotonTargets.All, amnt);
	}

	// local method
	public void SubtractPoints(int amnt) {
		photonView.RPC ("PunSubtractPoints", PhotonTargets.All, amnt);
	}

	public void SlowMode(bool mode) {
		photonView.RPC ("PunSlowMode", PhotonTargets.All, mode);
		if (mode)
			StartCoroutine (StopSlowMode());
	}

	IEnumerator StopSlowMode() {
		yield return new WaitForSeconds (disabilityTime);
		SlowMode (false);
	}

	public void ShieldMode(bool mode) {
		photonView.RPC ("PunShieldMode", PhotonTargets.All, mode);
		if (mode)
			StartCoroutine (StopShieldMode ());
	}

	IEnumerator StopShieldMode() {
		yield return new WaitForSeconds (disabilityTime);
		ShieldMode (false);
	}

	public void NoPointMode(bool mode) {
		photonView.RPC ("PunNoPointMode", PhotonTargets.All, mode);
		if (mode)
			StartCoroutine (StopNoPointMode ());
	}

	IEnumerator StopNoPointMode() {
		yield return new WaitForSeconds (disabilityTime);
		NoPointMode (false);
	}

	public void DoublePointMode(bool mode) {
		photonView.RPC ("PunDoublePointMode", PhotonTargets.All, mode);
		if (mode)
			StartCoroutine (StopDoublePointMode ());
	}

	IEnumerator StopDoublePointMode() {
		yield return new WaitForSeconds (disabilityTime);
		DoublePointMode (false);
	}

	[PunRPC]
	void PunSlowMode(bool mode) {
		slowMode = mode;
	}

	[PunRPC]
	void PunShieldMode(bool mode) {
		shieldMode = mode;
	}

	[PunRPC]
	void PunNoPointMode(bool mode) {
		noPointMode = mode;
	}

	[PunRPC]
	void PunDoublePointMode(bool mode) {
		doublePointMode = mode;
	}

	// method to update all point managers
	[PunRPC]
	void PunAddPoints(int amnt) {
		if (doublePointMode)
			amnt *= 2;
		if (noPointMode)
			amnt = 0;
		points += amnt;
        print("points: " + points);
	}

	// method to update all point managers
	[PunRPC]
	public void PunSubtractPoints(int amnt) {
		if (!shieldMode)
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
