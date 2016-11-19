using UnityEngine;
using System.Collections;

public class ViveControllers : MonoBehaviour
{
    private bool debug = true;

    private SteamVR_TrackedObject trackedObj;
    private SteamVR_Controller.Device controller { get { return SteamVR_Controller.Input((int)trackedObj.index); } }

    private Valve.VR.EVRButtonId trigger = Valve.VR.EVRButtonId.k_EButton_SteamVR_Trigger;
    private bool triggerDown, triggerUp, triggerPressed;

    private GameObject grabSlot;
    public GameObject grabbedObject;
    private ComponentClass component;

    void Start()
    {

        trackedObj = GetComponent<SteamVR_TrackedObject>();

    }

    void Update()
    {

        triggerDown = controller.GetPressDown(trigger);
        triggerUp = controller.GetPressUp(trigger);
        triggerPressed = controller.GetPress(trigger);

        if (triggerDown && grabSlot != null && grabbedObject == null)
        {
            //we're grabbing this object
            grabbedObject = grabSlot;

            //access its component
            component = grabbedObject.GetComponent<ComponentClass>();
            //add yourself to its list
            component.handsOnThis.Add(gameObject.GetComponent<ViveControllers>());

            //do all the grabbing stuff
            grabbedObject.transform.parent = gameObject.transform;
            grabbedObject.GetComponent<Rigidbody>().useGravity = false;
            grabbedObject.GetComponent<Rigidbody>().isKinematic = true;
        }

        if (triggerUp && grabbedObject != null)
        {
            if (grabbedObject.GetComponent<ComponentClass>() != null) {
                component.handsOnThis.Remove(gameObject.GetComponent<ViveControllers>());
                //only make the object drop, if no other hand is holding it anymore
                if (component.handsOnThis.Count < 1)
                {
                    grabbedObject.transform.parent = null;
                    grabbedObject.GetComponent<Rigidbody>().useGravity = true;
                    grabbedObject.GetComponent<Rigidbody>().isKinematic = false;
                }

                //forget about it, man.
                grabbedObject = null;
            }
            else { if (debug) { Debug.LogError("You somehow dropped an object that you couldn't grab in the first place. Well done."); } }
           
        }

    }

    void OnTriggerEnter(Collider objectCollider)
    {
        if (objectCollider.gameObject.tag == "grabbableTag")
        {
            grabSlot = objectCollider.transform.root.gameObject;
        }
    }
    void OnTriggerExit(Collider objectCollider)
    {
        grabSlot = null;
    }
}