using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowManager : MonoBehaviour {

    public GameObject arrowPrefab;
    private GameObject currentArrow;

    public GameObject bowPrefab;
    private GameObject bow;

    bool joinedRoom;
    bool bowAttached;
    bool stringFound;

    public static ArrowManager Instance;
    GameObject stringAttachPoint;
    GameObject arrowStartPoint;
    GameObject stringStartPoint;

    private bool isAttached;

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
        joinedRoom = false;
        bowAttached = false;
        isAttached = false;
	}
	
	// Update is called once per frame
	void Update () {
        AttachArrow();
        AttachBow();
        if (!stringFound && joinedRoom)
        {
            stringAttachPoint = GameObject.Find("string");
            arrowStartPoint = GameObject.Find("ArrowStart");
            stringStartPoint = GameObject.Find("StringStart");
            stringFound = true;
        }
        PullString();
	}

    private void PullString()
    {
        if (isAttached)
        {
            float dist = (stringStartPoint.transform.position - OculusManager.Instance.rightHand.transform.position).magnitude;
            stringAttachPoint.transform.localPosition = stringStartPoint.transform.localPosition + new Vector3(5*dist, 0f, 0f);

            if (OVRInput.GetUp(OVRInput.Button.SecondaryIndexTrigger))
                Fire();
        }
    }

    private void Fire()
    {
        currentArrow.transform.parent = null;
        currentArrow.GetComponent<Arrow>().IsFired();
        Rigidbody r = currentArrow.GetComponent<Rigidbody>();
        // set velocity based on distance of pull
        float dist = (stringStartPoint.transform.position - OculusManager.Instance.rightHand.transform.position).magnitude;
        r.velocity = currentArrow.transform.forward * 25f * dist;
        r.useGravity = true;

        currentArrow = null;
        isAttached = false;

        // reset position of string attach point
        stringAttachPoint.transform.position = stringStartPoint.transform.position;
    }

    private void AttachArrow()
    {
        if (joinedRoom && currentArrow == null)
        {
            currentArrow = PhotonNetwork.Instantiate(arrowPrefab.name, OculusManager.Instance.rightHand.transform.position, OculusManager.Instance.rightHand.transform.rotation, 0);
            currentArrow.transform.SetParent(OculusManager.Instance.rightHand.transform);
            currentArrow.transform.localPosition = new Vector3(0f, 0f, 0.34f);
        }
    }

    private void AttachBow()
    {
        if (!bowAttached && joinedRoom)
        {
            bow = PhotonNetwork.Instantiate(bowPrefab.name, OculusManager.Instance.leftHand.transform.position, OculusManager.Instance.leftHand.transform.rotation, 0);
            bow.transform.SetParent(OculusManager.Instance.leftHand.transform);
            bowAttached = true;
        }

    }

    public void JoinedRoom()
    {
        joinedRoom = true;
    }

    public void AttachBowToArrow()
    {
        currentArrow.transform.parent = stringAttachPoint.transform;
        currentArrow.transform.localPosition = arrowStartPoint.transform.localPosition;
        currentArrow.transform.rotation = arrowStartPoint.transform.rotation;
        
        isAttached = true;
    }
}
