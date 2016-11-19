using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class VelcroController : MonoBehaviour
{
    private bool debug = true;

    public bool canToggleTrigger = true;
    private GameObject myObject;
    private ComponentClass myComponent;

    void Start()
    {
        //set some states
        canToggleTrigger = true;

        //assign stuff
        myObject = gameObject.transform.parent.gameObject;
        myComponent = myObject.GetComponent<ComponentClass>();
    }
    

    void OnTriggerEnter (Collider triggeredCollider)
    {
        if (triggeredCollider.gameObject.tag == "velcroTag")
        {
            GameObject theirParent = triggeredCollider.transform.parent.gameObject;
            ComponentClass theirComponent = theirParent.GetComponent<ComponentClass>();

            if (debug) { Debug.Log("Trying to connect to: " + theirParent.name); }
            
            //if we can connect, try to!
            if (canToggleTrigger)
            {
                ConnectTo(theirParent, theirComponent, triggeredCollider.gameObject);
            }
            else
            {
                if(debug) { Debug.Log("Unable to connect to velcro."); }
            }

            
        }
    }

    //for connecting two components together
    void ConnectTo(GameObject connectObject, ComponentClass connectComponent, GameObject theirVelcro)
    {
        //If I am the core of the robot
        if (myComponent.isCentrePart)
        {
            if (connectComponent.isCentrePart) { if (debug) { Debug.LogError("Yeah, you can't connect two robot centres."); } }
            else {
                if (connectComponent.isAttachedToSomething) { if (debug) { Debug.LogWarning("You're already attached!"); } }
                else { VelcroThemToUs(connectObject, connectComponent, theirVelcro); }
            }
        }
        //If I am NOT the core of the robot
        else
        {
            if (myComponent.isAttachedToSomething && !connectComponent.isCentrePart) { VelcroThemToUs(connectObject, connectComponent, theirVelcro); }
            else { if (debug) { Debug.LogWarning("You can't connect two extra parts together."); } }
        }

        
    }

    void VelcroThemToUs(GameObject connectObject, ComponentClass connectComponent, GameObject velcro)
    {        
        connectObject.GetComponent<Rigidbody>().useGravity = false;
        connectObject.GetComponent<Rigidbody>().isKinematic = true;
        connectObject.transform.parent = myObject.transform;
        connectComponent.isAttachedToSomething = true;
        
        //for each hand grabbing it, make them stop and forget about it.
        for (int i = 0; i < connectComponent.handsOnThis.Count; i++)
        {
            ViveControllers controller = connectComponent.handsOnThis[i];
            controller.grabbedObject = null;
        }
        //when done, clear the hands List
        connectComponent.handsOnThis = new List<ViveControllers>();

        SnapToCORRECTPosition(connectObject, velcro);

        if (debug) { Debug.Log(myObject.name + " has connected " + connectObject.name + " to itself."); }
    }

    void SnapToCORRECTPosition(GameObject theirObject, GameObject theirVelcro)
    {
        theirVelcro.transform.parent = null;
        theirObject.transform.parent = theirVelcro.transform;
        if (debug) { Debug.LogWarning(theirVelcro.name + " " + theirObject.transform.parent.name); }

        theirVelcro.transform.position = gameObject.transform.position;
        theirVelcro.transform.up = -gameObject.transform.up;

        theirObject.transform.parent = myObject.transform;
        theirVelcro.transform.parent = theirObject.transform;

        /* Vector3 theirLocalDiff = theirVelcro.transform.localPosition;
        theirObject.transform.localPosition = gameObject.transform.localPosition - theirLocalDiff; */
    }

    /* void VelcroUsToThem(GameObject connectObject)
    {
        myObject.GetComponent<Rigidbody>().useGravity = false;
        myObject.GetComponent<Rigidbody>().isKinematic = true;
        myObject.transform.parent = connectObject.transform;
    } */

    
}