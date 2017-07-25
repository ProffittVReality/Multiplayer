using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {

    public static EnemyController Instance;

    public GameObject enemyPrefab;

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
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void InstantiateEnemy(Vector3 startPosition)
    {
        PhotonNetwork.Instantiate(enemyPrefab.name, startPosition, Quaternion.identity, 0);
    }
}
