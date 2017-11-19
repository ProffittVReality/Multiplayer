using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupManager : MonoBehaviour {

	public GameObject doublePrefab;
	public GameObject halfPrefab;
	public GameObject invinciPrefab;
	public GameObject slowPrefab;

	public Vector3 doublePos1;
	public Vector3 doublePos2;
	public Vector3 halfPos1;
	public Vector3 halfPos2;
	public Vector3 invinciPos1;
	public Vector3 invinciPos2;
	public Vector3 slowPos1;
	public Vector3 slowPos2;

	bool setup = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		if (GameObject.Find ("Avatar(Clone)") && !setup) {
			setup = true;
			PhotonNetwork.Instantiate(doublePrefab.name, doublePos1, Quaternion.identity, 0);
			PhotonNetwork.Instantiate(doublePrefab.name, doublePos2, Quaternion.identity, 0);
			PhotonNetwork.Instantiate(halfPrefab.name, halfPos1, Quaternion.identity, 0);
			PhotonNetwork.Instantiate(halfPrefab.name, halfPos2, Quaternion.identity, 0);
			PhotonNetwork.Instantiate(invinciPrefab.name, invinciPos1, Quaternion.identity, 0);
			PhotonNetwork.Instantiate(invinciPrefab.name, invinciPos2, Quaternion.identity, 0);
			PhotonNetwork.Instantiate(slowPrefab.name, slowPos1, Quaternion.identity, 0);
			PhotonNetwork.Instantiate(slowPrefab.name, slowPos2, Quaternion.identity, 0);
		}
		
	}
}
