using UnityEngine;
using System.Collections;

public class VelcroController : MonoBehaviour {
    private bool debug = true;

    private bool toggleCanTrigger = true, inUse = false;
    public ComponentClass myComponent;
    private GameObject myGameObject;

	// Use this for initialization
	void Start () {

        myGameObject = myComponent.gameObject;
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    //when velcros collide...
    void OnTriggerEnter (Collider triggered)
    {
        if (triggered.gameObject.transform.parent != null)
        {
            if (triggered.gameObject.transform.parent.gameObject.tag == "componentTag" && triggered.transform.parent.gameObject.GetComponent<ComponentClass>() != null)
            {
                GameObject theirGameObject = triggered.transform.parent.gameObject;
                ComponentClass theirComponent = theirGameObject.GetComponent<ComponentClass>();
                if (debug) { Debug.Log("Their gameObject is " + theirGameObject.name); }

                //if it's velcro, and we can attempt to attach, we're not already inUse, and we're not on the same object (just in case)...
                if (triggered.gameObject.tag == "velcroTag" && toggleCanTrigger && !inUse && myGameObject != theirGameObject)
                {
                    if (debug)
                    {
                        Debug.LogWarning("Velcros have collided!");
                        toggleCanTrigger = false;

                        //Now we decide "who to connect to who"
                        if (myComponent.isCentrePart) //If my part is the centre of the entire robot...
                        {
                            if (theirComponent.isCentrePart && debug) { Debug.LogError("BOTH VELCROS ARE ATTACHED TO MAIN PIECES, CAN'T CONNECT"); }
                            else
                            {
                                theirGameObject.GetComponent<Rigidbody>().useGravity = false;
                                theirGameObject.GetComponent<Rigidbody>().isKinematic = true;

                                theirGameObject.transform.parent = myGameObject.transform;
                                theirComponent.setAttached(true);
                            }
                        }

                    }
                }
            }
        }
        
        //if colliding trigger has no parent
        else { if(debug) { Debug.LogWarning("They don't have a parent."); } }       
        
        
    }

    void OnTriggerExit (Collider triggered)
    {
        toggleCanTrigger = true;
    }
}
