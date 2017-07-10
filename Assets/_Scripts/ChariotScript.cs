using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChariotScript : MonoBehaviour {

	public GameObject bike;

	public static ChariotScript Instance;

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
		
	}
}
