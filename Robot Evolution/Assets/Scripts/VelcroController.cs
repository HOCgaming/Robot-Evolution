﻿using UnityEngine;
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
                ConnectTo(theirParent, theirComponent, triggeredCollider);
            }
            else
            {
                if(debug) { Debug.Log("Unable to connect to velcro."); }
            }

            
        }
    }

    //for connecting two components together
    void ConnectTo(GameObject connectObject, ComponentClass connectComponent, Collider triggeredCollider)
    {
        //If I am the core of the robot
        if (myComponent.isCentrePart)
        {
            if (connectComponent.isCentrePart) { if (debug) { Debug.LogError("Yeah, you can't connect two robot centres."); } }
            else {
                if (connectComponent.isAttachedToSomething) { if (debug) { Debug.LogWarning("You're already attached!"); } }
                else { VelcroThemToUs(connectObject, connectComponent); }
            }
        }
        //If I am NOT the core of the robot
        else
        {
            if (myComponent.isAttachedToSomething && !connectComponent.isCentrePart) { VelcroThemToUs(connectObject, connectComponent); }
            else {
                if (debug) { Debug.LogWarning("You can't connect two extra parts together."); }
                StartCoroutine(FlashVelcroRed(triggeredCollider, 2));
            }
        }

        
    }

    void VelcroThemToUs(GameObject connectObject, ComponentClass connectComponent)
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

        if (debug) { Debug.Log(myObject.name + " has connected " + connectObject.name + " to itself."); }
    }

    /* void VelcroUsToThem(GameObject connectObject)
    {
        myObject.GetComponent<Rigidbody>().useGravity = false;
        myObject.GetComponent<Rigidbody>().isKinematic = true;
        myObject.transform.parent = connectObject.transform;
    } */

    private IEnumerator FlashVelcroRed(Collider collider, float seconds)
    {
        Material currentMaterial = collider.gameObject.GetComponent<Renderer>().material;
        Material myMaterial = gameObject.GetComponent<Renderer>().material;

        collider.gameObject.GetComponent<Renderer>().material.color = Color.red;
        gameObject.GetComponent<Renderer>().material.color = Color.red;        

        yield return new WaitForSeconds(seconds);

        collider.gameObject.GetComponent<Renderer>().material = currentMaterial;
        gameObject.GetComponent<Renderer>().material = myMaterial;
    }
}