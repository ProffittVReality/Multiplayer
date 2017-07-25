using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ViveRiderScript : MonoBehaviour
{

    GameObject chariot;
    GameObject head;
    GameObject bow;
    GameObject arrow;
    bool isAttached = false;

    // Use this for initialization
    void Start()
    {
        isAttached = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isAttached && (GameObject.Find("Avatar(Clone)")) != null && (GameObject.Find("BowVisual(Clone)") != null))
        {
            chariot = GameObject.Find("Chariot(Clone)");
            head = GameObject.Find("Avatar(Clone)");
            bow = GameObject.Find("BowVisual(Clone)");
            head.transform.SetParent(chariot.transform);
            bow.transform.SetParent(chariot.transform);
            isAttached = true;
        }

        if (GameObject.Find("ArrowVisual(Clone)") != null)
        {
            arrow = GameObject.Find("ArrowVisual(Clone)");
            arrow.transform.SetParent(chariot.transform);
        }
    }
}