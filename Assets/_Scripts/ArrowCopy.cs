using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowCopy : MonoBehaviour {

    private GameObject parent;
    bool parentSet = false;

    PhotonView photonView;

    // Use this for initialization
    void Start() {
        photonView = GetComponent<PhotonView>();
    }

    // Update is called once per frame
    void Update() {
        if (parentSet)
        {
            this.transform.position = parent.transform.position;
            this.transform.rotation = parent.transform.rotation;
        }
    }

    public void SetParent(GameObject newParent)
    {
        parent = newParent;
        parentSet = true;
    }

    void ChangeName()
    {
        photonView.RPC("PhotonChangeName", PhotonTargets.All);
    }

    [PunRPC]
    public void PhotonChangeName()
    {
        name = "old";
    }
}
