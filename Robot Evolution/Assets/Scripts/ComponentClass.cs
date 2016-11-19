using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ComponentClass : MonoBehaviour {

    public bool isCentrePart, isAttachedToSomething;
    public List<ViveControllers> handsOnThis = new List<ViveControllers>();
    //public int handsOnThis = 0;

	// Use this for initialization
	void Start () {

        //set some values
        isAttachedToSomething = false;
	
	}
	
	// Update is called once per frame
	void Update () {

	}

    void DisconnectThisObject()
    {
        gameObject.GetComponent<Rigidbody>().useGravity = true;
        gameObject.GetComponent<Rigidbody>().isKinematic = false;
        gameObject.transform.parent = null;
        isAttachedToSomething = false;
    }
}
