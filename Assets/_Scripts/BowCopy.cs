using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BowCopy : MonoBehaviour {

    private GameObject parent;
    bool parentSet = false;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
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
}
