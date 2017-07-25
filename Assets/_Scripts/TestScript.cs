using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestScript : MonoBehaviour {

    public KeyCode makeEnemy;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(makeEnemy))
            EnemyController.Instance.InstantiateEnemy(new Vector3(0f, 0f, 0f));    
        }
}
