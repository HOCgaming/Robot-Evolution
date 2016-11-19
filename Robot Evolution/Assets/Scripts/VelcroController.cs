using UnityEngine;
using System.Collections;

public class VelcroController : MonoBehaviour
{
    private bool debug = true;

    public bool canToggleTrigger = true, isBeingUsed = false;
    private GameObject myObject;
    private ComponentClass myComponent;

    void Start()
    {
        //set some states
        canToggleTrigger = true;
        isBeingUsed = false;

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
            if (canToggleTrigger && !isBeingUsed)
            {
                ConnectTo(theirParent, theirComponent);
            }
            else
            {
                if(debug) { Debug.Log("Unable to connect to velcro."); }
            }

            
        }
    }

    //for connecting two components together
    void ConnectTo(GameObject connectObject, ComponentClass connectComponent)
    {
        //If I am the core of the robot
        if (myComponent.isCentrePart)
        {
            if (connectComponent.isCentrePart) { if (debug) { Debug.LogError("Yeah, you can't connect two robot centres."); } }
            else { VelcroThemToUs(connectObject, connectComponent); }
        }
        //If I am NOT the core of the robot
        else
        {
            if (myComponent.isAttachedToCentre && !connectComponent.isCentrePart) { VelcroThemToUs(connectObject, connectComponent); }
            else { if (debug) { Debug.LogWarning("You can't connect two extra parts together."); } }
        }

        
    }

    void VelcroThemToUs(GameObject connectObject, ComponentClass connectComponent)
    {        
        connectObject.GetComponent<Rigidbody>().useGravity = false;
        connectObject.GetComponent<Rigidbody>().isKinematic = true;
        connectObject.transform.parent = myObject.transform;
        connectComponent.isAttachedToCentre = true;
        if (debug) { Debug.Log(myObject.name + " has connected " + connectObject.name + " to itself."); }
    }

    /* void VelcroUsToThem(GameObject connectObject)
    {
        myObject.GetComponent<Rigidbody>().useGravity = false;
        myObject.GetComponent<Rigidbody>().isKinematic = true;
        myObject.transform.parent = connectObject.transform;
    } */
}