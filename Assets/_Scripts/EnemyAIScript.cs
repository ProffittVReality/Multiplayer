using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAIScript : MonoBehaviour {

    // This script controls enemy movement (transform)

    Transform player;
    Transform chariot;
    public float playerDistance;
    public float lookDistance;
    public float rotationDamping;
    public float moveSpeed;

    bool turnedAway;
    Quaternion newRotation;

	// Use this for initialization
	void Start () {
        newRotation = Quaternion.identity;
    }
	
	// Update is called once per frame
	void Update () {
        if (OculusManager.Instance.chariotFound)
        {
            chariot = OculusManager.Instance.chariot.transform;
            player = OculusManager.Instance.avatar.transform;

            playerDistance = (player.position - transform.position).magnitude;

            EnemyScript e = GetComponent<EnemyScript>();

            // enemy movement toward player (before attack) is nested in this if statement
            if (playerDistance < lookDistance && !e.IsDead() && !e.HasAttacked())
            {
                LookAtPlayer();
                if (playerDistance > 1f)
                    Chase();
            }

            // enemy movement away from player (after attack) is nested in this if statement
            if (e.HasAttacked())
            {
                transform.SetParent(null);
                MoveAwayFromPlayer();
            }
        }
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Chariot")
        {
            // attack the chariot
            transform.SetParent(chariot);
            GetComponent<EnemyScript>().Attack();
            PointSystem.Instance.SubtractPoints(3);
        }
    }

    void LookAtPlayer()
    {
        Quaternion rotation = Quaternion.LookRotation(player.position - transform.position);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * rotationDamping);
    }

    void Chase()
    {
        transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
    }

    void MoveAwayFromPlayer()
    {
        print("Moving away from player");
        if (!turnedAway)
        {
            newRotation = transform.rotation * Quaternion.Euler(Vector3.up * 180);
            turnedAway = true;
        }
        // rotate away from player
        GetComponent<Rigidbody>().freezeRotation = true;
        if (transform.rotation != newRotation)
            transform.rotation = Quaternion.Slerp(transform.rotation, newRotation, Time.deltaTime * 30);
        // move forward
        transform.Translate(Vector3.forward * moveSpeed * 3f * Time.deltaTime);
    }
}
