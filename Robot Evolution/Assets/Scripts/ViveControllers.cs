using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ViveControllers : MonoBehaviour
{
	private bool debug = true;

	private SteamVR_TrackedObject trackedObj;
	private SteamVR_Controller.Device controller { get { return SteamVR_Controller.Input((int)trackedObj.index); } }

	private Valve.VR.EVRButtonId trigger = Valve.VR.EVRButtonId.k_EButton_SteamVR_Trigger;
	private Valve.VR.EVRButtonId grip = Valve.VR.EVRButtonId.k_EButton_Grip;
	private bool triggerDown, triggerUp, triggerPressed;
	private bool gripDown, gripUp;

	private GameObject grabSlot;
	public GameObject grabbedObject;
	private ComponentClass component;

	private Vector3 v3Velocity;

	private const int sampleSize = 5;
	private float[,] positions = new float[sampleSize,3];
	private float[] times = new float[sampleSize];
	private byte counter;



	void Start()
	{

		trackedObj = GetComponent<SteamVR_TrackedObject>();

	}

	void Update()
	{

		SetViveInputStates();

		CheckDisconnectComponents();
		CheckGrabThings();
		CheckDropThings();       


	}



	private void SetViveInputStates()
	{
		triggerDown = controller.GetPressDown(trigger);
		triggerUp = controller.GetPressUp(trigger);
		//triggerPressed = controller.GetPress(trigger);

		gripDown = controller.GetPressDown(grip);
		gripUp = controller.GetPressUp(grip);
	}

	//FOR DISCONNECTING THINGS
	private void CheckDisconnectComponents()
	{        
		if (gripDown && grabSlot != null && grabbedObject == null)
		{
			grabbedObject = grabSlot;
			ComponentClass[] componentChildren = grabbedObject.GetComponentsInChildren<ComponentClass>();

			//lets check all the children that we want to disconnect
			if (debug)
			{
				Debug.Log("Children of grabbed objects:");
				for (int i = 0; i < componentChildren.Length; i++) { Debug.Log(i + ": " + componentChildren[i].gameObject.name); }
			}

			//DETACH ALL THE THINGS!
			for (int i = 0; i < componentChildren.Length; i++)
			{
				componentChildren[i].isAttachedToSomething = false;
				componentChildren[i].transform.parent = null;
				if (componentChildren[i].gameObject.GetComponent<Rigidbody> () != null) {
					componentChildren[i].gameObject.GetComponent<Rigidbody>().useGravity = true;
					componentChildren[i].gameObject.GetComponent<Rigidbody>().isKinematic = false;
				} else {
					if (debug) {
						Debug.LogWarning (componentChildren[i].gameObject.name + " does not have a rigidbody!");
						Debug.LogWarning ("Giving " + componentChildren[i].gameObject.name + " a rigidbody!");
					}
					componentChildren[i].gameObject.AddComponent<Rigidbody>();
					componentChildren[i].gameObject.GetComponent<Rigidbody>().useGravity = true;
					componentChildren[i].gameObject.GetComponent<Rigidbody>().isKinematic = false;
				}
			}
			grabbedObject.GetComponent<ComponentClass>().isAttachedToSomething = false;
			grabbedObject.GetComponent<Rigidbody>().useGravity = true;
			grabbedObject.GetComponent<Rigidbody>().isKinematic = false;
			if (debug) { Debug.Log("Should've detached all the children, and the grabbed object..."); }

			//forget the object
			grabbedObject = null;

		}
	}

	//FOR GRABBING THINGS
	private void CheckGrabThings()
	{
		if (triggerDown && grabSlot != null && grabbedObject == null)
		{
			//we're grabbing this object
			grabbedObject = getObjectToGrab(grabSlot);
			if (debug) { Debug.Log("Grabbed: " + grabbedObject.name); }

			//access its component
			component = grabbedObject.GetComponent<ComponentClass>();
			//add yourself to its list
			component.handsOnThis.Add(gameObject.GetComponent<ViveControllers>());

			//do all the grabbing stuff
			grabbedObject.transform.parent = gameObject.transform;

			if (grabbedObject.GetComponent<Rigidbody> () != null) {
				grabbedObject.GetComponent<Rigidbody>().useGravity = false;
				grabbedObject.GetComponent<Rigidbody>().isKinematic = true;
			} else {
				if (debug) {
					Debug.LogWarning (grabbedObject.name + " does not have a rigidbody!");
					Debug.LogWarning ("Giving " + grabbedObject.name + " a rigidbody!");
				}
				grabbedObject.AddComponent<Rigidbody>();
				grabbedObject.GetComponent<Rigidbody>().useGravity = false;
				grabbedObject.GetComponent<Rigidbody>().isKinematic = true;
			}

		}
	}
	/*
	private void jamieGetVelocityShizzle(GameObject inputObject)
	{
		v3Velocity = inputObject.GetComponent<Rigidbody>().velocity; 
	}

	private void jamieSetVelocityShizzle(GameObject inputObject)
	{
		inputObject.GetComponent<Rigidbody>().velocity = v3Velocity; // = inputObject.GetComponent<Rigidbody>().velocity; 
	}
*/
	void jamiegetPositions(GameObject inputObject)
	{
		positions [counter,0] = transform.position.x;
		positions[counter,1] = transform.position.y;
		positions[counter,2] = transform.position.z;
		times [counter] = Time.deltaTime;
		counter++;
		if (counter == sampleSize) {
			counter = 0;
		}
	}

	void jamiecalculateAndSetVelocity(GameObject inputObject)
	{
		float[,] axialVelocity = new float[sampleSize,3];
		float[] aveAxialVelocity = new float[3];
		for (int y = 0; y < 3; y++) {
			for (int x = 0; x < (sampleSize-1); x++) {
				float deltaX = positions [x,y] - positions [x+1,y];
				axialVelocity[x,y] = deltaX / times [x]; 
			}
			aveAxialVelocity[y] = axialVelocity [0,y] + axialVelocity [1,y] + axialVelocity [2,y] + axialVelocity [3,y];
		}
		Vector3 outSpeed = new Vector3 (aveAxialVelocity[0], aveAxialVelocity[1],aveAxialVelocity[2]);
		inputObject.GetComponent<Rigidbody> ().velocity = outSpeed;
	}


	private void CheckDropThings()
	{
		jamiegetPositions (gameObject);
		if (triggerUp && grabbedObject != null)
		{
			if (grabbedObject.GetComponent<ComponentClass>() != null)
			{
				component.handsOnThis.Remove(gameObject.GetComponent<ViveControllers>());
				//only make the object drop, if no other hand is holding it anymore
				if (component.handsOnThis.Count < 1)
				{
					//jamieGetVelocityShizzle (gameObject);
					grabbedObject.transform.parent = null;
					grabbedObject.GetComponent<Rigidbody>().useGravity = true;
					grabbedObject.GetComponent<Rigidbody>().isKinematic = false;
					jamiecalculateAndSetVelocity (grabbedObject);
				}

				//forget about it, man.
				grabbedObject = null;
			}
			else { if (debug) { Debug.LogError("You somehow dropped an object that you couldn't grab in the first place. Well done."); } }

		}
	}

	/*
     * FOR GRABBING THE ROBOT ITSELF
     * REMEMBER 
     * THAT THING THAT TOOK HOURS
     */

	GameObject getObjectToGrab(GameObject grabSlot)
	{
		if (grabSlot.GetComponent<ComponentClass>().isAttachedToSomething)
		{
			if (debug) { Debug.Log("Returned Robot Centre"); }
			return GlobalReferences.RobotCentre;

		}
		else
		{
			if (debug) { Debug.Log("Returned Grab Slot"); }
			return grabSlot;
		}

	}


	/*
     * DO THE THINGS WITH THE GRAB SLOTS
     * AND WHATNOT
     * ALL THOSE THINGS THAT YOU SHOULDN'T MESS WITH
     * 
     */

	void OnTriggerEnter(Collider objectCollider)
	{
		if (objectCollider.gameObject.tag == "grabbableTag")
		{
			grabSlot = objectCollider.gameObject;
		}
	}
	void OnTriggerExit(Collider objectCollider)
	{
		grabSlot = null;
	}

}