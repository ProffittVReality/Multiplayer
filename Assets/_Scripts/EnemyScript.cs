using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour {

    bool running;
    bool killed;
    bool attack;

    bool setInactive;

    public KeyCode attackKey;
    public KeyCode killKey;

    PhotonView photonView;

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
            PhotonSetInactive();
        }
        if (attack)
        {
            GetComponent<Animation>().CrossFade("Attack", 0.01f);
            StartCoroutine(AttackToRun());
        }

        if (setInactive)
        {
            Destroy(gameObject, 5f);
        }
           
    }

    IEnumerator AttackToRun()
    {
        yield return new WaitForSeconds(0.53f);
        attack = false;
        running = true;
    }

    // local method, calls photon method
    public void Attack()
    {
        photonView.RPC("PhotonAttack", PhotonTargets.All);
        
    }

    // local method, calls photon method
    public void Kill()
    {
        photonView.RPC("PhotonKill", PhotonTargets.All);
    }

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

}
