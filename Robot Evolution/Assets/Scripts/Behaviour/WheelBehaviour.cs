using UnityEngine;
using System.Collections;

public class WheelBehaviour : MonoBehaviour {

    private ComponentClass myComponent;
    private Vector3 rotateAxis;
    private int rotateSpeed;
    
	void Start () {
        rotateAxis = gameObject.transform.forward;
        rotateSpeed = 50;

        myComponent = gameObject.GetComponent<ComponentClass>();
	}
	
	void FixedUpdate () {

        if (myComponent.isAttachedToSomething && Input.GetKey(KeyCode.W))
        {
            gameObject.transform.Rotate(rotateAxis, Time.deltaTime * rotateSpeed);
			GlobalReferences.RobotCentre.GetComponent<Rigidbody>().AddForce(GlobalReferences.RobotCentre.transform.up * rotateSpeed);
        }	    
	}
}
