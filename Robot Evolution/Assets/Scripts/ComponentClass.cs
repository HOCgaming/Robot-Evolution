using UnityEngine;
using System.Collections;

public class ComponentClass : MonoBehaviour {

    public bool isCentrePart, isAttachedToCentre;

	// Use this for initialization
	void Start () {

        //set some values
        isAttachedToCentre = false;
	
	}
	
	// Update is called once per frame
	void Update () {

	}

    void DisconnectThisObject()
    {
        gameObject.GetComponent<Rigidbody>().useGravity = true;
        gameObject.GetComponent<Rigidbody>().isKinematic = false;
        gameObject.transform.parent = null;
        isAttachedToCentre = false;
    }
}
