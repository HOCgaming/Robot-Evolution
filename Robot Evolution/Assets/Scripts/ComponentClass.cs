using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ComponentClass : MonoBehaviour {
    private bool debug = true;
    public ObjectSpawner monoGenerator;
    public int id;

    public bool isCentrePart, isAttachedToSomething, beenPickedUp;
    public List<ViveControllers> handsOnThis = new List<ViveControllers>();
    //public int handsOnThis = 0;

	// Use this for initialization
	void Start () {

        //set some values
        isAttachedToSomething = false;
        beenPickedUp = false;

        if (isCentrePart)
        {
            GlobalReferences.RobotCentre = gameObject;
            if (debug) { Debug.Log("References now contains the RobotCentre"); }
        }
	
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Space)) { ReplaceMe(); }
	}

    public void ReplaceMe() {
        if(debug)
        {
            Debug.LogWarning("TRYING TO SPAWN NEW " + gameObject.name);
        }
        if (!beenPickedUp && !isCentrePart)
        {
            monoGenerator.spawnNewMe(gameObject, id);
            beenPickedUp = true;
            
        }
        
    }

    /*
    void DisconnectThisObject()
    {
        gameObject.GetComponent<Rigidbody>().useGravity = true;
        gameObject.GetComponent<Rigidbody>().isKinematic = false;
        gameObject.transform.parent = null;
        isAttachedToSomething = false;
    } */
}
