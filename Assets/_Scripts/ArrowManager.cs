using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowManager : MonoBehaviour {

    public GameObject arrowPrefab;
    public GameObject arrowVisualPrefab;
    private GameObject currentArrow;
    private GameObject currentArrowVisual;

    public GameObject bowPrefab;
    public GameObject bowVisualPrefab;
    private GameObject bow;
    private GameObject bowVisual;

    bool joinedRoom;
    bool bowAttached;

    public static ArrowManager Instance;
    GameObject stringAttachPoint;
    GameObject arrowStartPoint;
    GameObject stringStartPoint;

    private bool isAttached;

    private OVRInput.Button handButton;
    private GameObject gripHand;
    private GameObject arrowHand;

    GameObject chariot;

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

    public void SetGripHandLeft(bool leftHand)
    {
        if (leftHand)
        {
            handButton = OVRInput.Button.SecondaryIndexTrigger;
            gripHand = OculusManager.Instance.leftHand;
            arrowHand = OculusManager.Instance.rightHand;
            AttachBow();
        }
        else
        {
            handButton = OVRInput.Button.PrimaryIndexTrigger;
            gripHand = OculusManager.Instance.rightHand;
            arrowHand = OculusManager.Instance.leftHand;
            // rotate to have arrow notch on correct side
            bow.transform.Rotate(new Vector3(0f, 0f, 180f));
            AttachBow();
        }
    }

    public OVRInput.Button GetButton()
    {
        return handButton;
    }

    // Use this for initialization
    void Start () {
        joinedRoom = false;
        bowAttached = false;
        isAttached = false;
	}
	
	// Update is called once per frame
	void Update () {

        if (bowAttached)
        {
            chariot = GameObject.Find("Chariot(Clone)");
            AttachArrow(chariot);
        }
        
        if (joinedRoom)
        {
            stringAttachPoint = GameObject.Find("string");
            arrowStartPoint = GameObject.Find("ArrowStart");
            stringStartPoint = GameObject.Find("StringStart");
        }
        PullString();
	}

    private void PullString()
    {
        if (isAttached)
        {
            float dist = (stringStartPoint.transform.position - arrowHand.transform.position).magnitude;
            stringAttachPoint.transform.localPosition = stringStartPoint.transform.localPosition + new Vector3(5*dist, 0f, 0f);

            if (OVRInput.GetUp(handButton))
                Fire();
        }
    }

    private void Fire()
    {
        currentArrow.transform.parent = null;
        currentArrowVisual.transform.parent = null;
        currentArrow.GetComponent<Arrow>().IsFired();
        Rigidbody r = currentArrow.GetComponent<Rigidbody>();
        // set velocity based on distance of pull
        float dist = (stringStartPoint.transform.position - arrowHand.transform.position).magnitude;
        r.velocity = currentArrow.transform.forward * 25f * dist;
        r.useGravity = true;

        currentArrow = null;
        isAttached = false;

        // reset position of string attach point
        stringAttachPoint.transform.position = stringStartPoint.transform.position;

        // change name of arrow to attach next arrow on vive (called from oculus)
        currentArrowVisual.GetComponent<ArrowCopy>().ChangeName();
    }

    private void AttachArrow(GameObject chariot)
    {
        if (joinedRoom && currentArrow == null)
        {
            // the arrow that the driver and archer will see
            currentArrowVisual = PhotonNetwork.Instantiate(arrowVisualPrefab.name, arrowHand.transform.position, arrowHand.transform.rotation, 0);
            // the physics of the arrow (must keep separate because copy script does not work with colliders)
            currentArrow = Instantiate(arrowPrefab);
            // attach to hand
            currentArrow.transform.SetParent(arrowHand.transform);
            currentArrow.transform.localPosition = new Vector3(0f, 0f, 0.34f);
            currentArrow.transform.localRotation = Quaternion.identity;

            // set currentArrow as currentArrowVisual's parent in copy script
            currentArrowVisual.GetComponent<ArrowCopy>().SetParent(currentArrow);
            currentArrowVisual.transform.SetParent(chariot.transform);
        }
    }

    public void CreateBow(GameObject chariot)
    {
        // the bow that the driver and archer will see
        bowVisual = PhotonNetwork.Instantiate(bowVisualPrefab.name, chariot.transform.position, chariot.transform.rotation, 0);
        bowVisual.transform.position += new Vector3(0f, 1f, 2f);
        // the collider of the bow (must keep separate because copy script does not work with colliders)
        bow = Instantiate(bowPrefab);
        bow.transform.position = bowVisual.transform.position;
        bow.transform.rotation = bowVisual.transform.rotation;
        
        // rotate for starting position and attach to chariot
        bow.transform.SetParent(chariot.transform);
        bowVisual.transform.SetParent(chariot.transform);

        // set bow as bowVisual's parent in copy script
        bowVisual.GetComponent<BowCopy>().SetParent(bow);
    }

    private void AttachBow()
    {
        if (!bowAttached && joinedRoom)
        {
            bow.transform.position = gripHand.transform.position;
            bow.transform.rotation = gripHand.transform.rotation;
            if (gripHand == OculusManager.Instance.rightHand)
                bow.transform.Rotate(new Vector3(0f, 0f, 180f));
            bow.transform.SetParent(gripHand.transform);
            bowAttached = true;
        }
    }

    public bool BowAttached()
    {
        return bowAttached;
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
