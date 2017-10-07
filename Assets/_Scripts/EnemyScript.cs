using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour {

    // This script controls enemy animation and states

    bool running;
    bool killed;
    bool attack;

    bool cantMove;

    bool setInactive;

    public KeyCode attackKey;
    public KeyCode killKey;

    PhotonView photonView;

    bool hasAttacked = false;
    bool hasDied = false;

	// Use this for initialization
	void Start () {
        running = true;
        photonView = PhotonView.Get(this);
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown(attackKey))
            Attack();
        if (Input.GetKeyDown(killKey))
            Kill();

        if (running)
            GetComponent<Animation>().CrossFade("Walk", 0.01f);
        if (killed)
        {
            GetComponent<Animation>().CrossFade("Dead", 0.01f);
            killed = false;
            running = false;
            hasDied = true;
            PhotonSetInactive();
        }
        if (attack)
        {
            GetComponent<Animation>().CrossFade("Attack", 0.01f);
            StartCoroutine(AttackToRun());
            PhotonSetInactive();
        }

        if (setInactive)
        {
            // after attack or kill, enemy will be de-instantiated
            Destroy(gameObject, 10f);
        }
           
    }

    IEnumerator AttackToRun()
    {
        yield return new WaitForSeconds(0.53f);
        attack = false;
        running = true;
        hasAttacked = true;
    }

    // local method, calls photon method
    public void Attack()
    {
        if (!cantMove)
            photonView.RPC("PhotonAttack", PhotonTargets.All);
        // if enemy has already attacked, can't attack again or be killed
        cantMove = true;
    }

    // local method, calls photon method
    public void Kill()
    {
        if (!cantMove)
        {
            photonView.RPC("PhotonKill", PhotonTargets.All);
        }
        // once killed, cannot take further action
        cantMove = true;
    }

    // methods tagged "PunRPC" change variables of this object on all local servers
    [PunRPC]
    public void PhotonAttack()
    {
        attack = true;
        running = false;
    }

    [PunRPC]
    public void PhotonKill()
    {
        killed = true;
        running = false;
    }

    [PunRPC]
    public void PhotonSetInactive()
    {
        setInactive = true;
    }

    public bool IsDead()
    {
        return hasDied;
    }

    public bool HasAttacked()
    {
        return hasAttacked;
    }

}
