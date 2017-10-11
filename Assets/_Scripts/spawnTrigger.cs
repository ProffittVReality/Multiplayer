using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnTrigger : MonoBehaviour {

	public Vector3 position1;
	public Vector3 position2;
	public Vector3 position3;
	public Vector3 position4;
	public Vector3 position5;

	bool done = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider collider) {
		if (collider.gameObject.tag == "Chariot" && !done) {
			// instantiate new enemies
			EnemyController.Instance.InstantiateEnemy(position1);
			EnemyController.Instance.InstantiateEnemy(position2);
			EnemyController.Instance.InstantiateEnemy(position3);
			EnemyController.Instance.InstantiateEnemy(position4);
			EnemyController.Instance.InstantiateEnemy(position5);
			done = true;
		}
	}
}
