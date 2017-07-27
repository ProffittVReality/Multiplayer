using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OculusManager : MonoBehaviour {

	public GameObject head;
	public GameObject leftHand;
	public GameObject rightHand;
    public GameObject avatar;
    [HideInInspector]
    public GameObject chariot;

	public static OculusManager Instance;

    [HideInInspector]
    public bool chariotFound = false;

	void Awake() {
		if (Instance == null)
			Instance = this;
	}

	void OnDestroy() {
		if (Instance == this)
			Instance = null;
	}

	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
        if ((GameObject.Find("Chariot(Clone)") != null) && (!chariotFound))
        {
            chariot = GameObject.Find("Chariot(Clone)");
            chariotFound = true;
        }
    }
}
