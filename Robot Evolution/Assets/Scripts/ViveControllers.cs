using UnityEngine;
using System.Collections;

public class ViveControllers : MonoBehaviour
{
    private SteamVR_TrackedObject trackedObj;
    private SteamVR_Controller.Device controller { get { return SteamVR_Controller.Input((int)trackedObj.index); } }

    private Valve.VR.EVRButtonId trigger = Valve.VR.EVRButtonId.k_EButton_SteamVR_Trigger;
    private bool triggerDown, triggerUp, triggerPressed;

    private GameObject grabSlot, grabbedObject;

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
            grabbedObject = grabSlot;
            grabbedObject.transform.parent = gameObject.transform;
            grabbedObject.GetComponent<Rigidbody>().useGravity = false;
            grabbedObject.GetComponent<Rigidbody>().isKinematic = true;
        }

        if (triggerUp && grabbedObject != null)
        {
            grabbedObject.transform.parent = null;
            grabbedObject.GetComponent<Rigidbody>().useGravity = true;
            grabbedObject.GetComponent<Rigidbody>().isKinematic = false;
            grabbedObject = null;
        }

        if (triggerPressed && grabbedObject != null)
        {

        }
    }

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