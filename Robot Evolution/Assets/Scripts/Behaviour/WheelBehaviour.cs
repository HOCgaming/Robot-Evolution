using UnityEngine;
using System.Collections;

public class WheelBehaviour : MonoBehaviour {

    private ComponentClass myComponent;
    private Vector3 rotateAxis;
	private int forceFactor;
	private int torqueFactor;
	private int wheelFactor;
    
	void Start () {
        rotateAxis = gameObject.transform.forward;
        forceFactor = 50;
		torqueFactor = 20;
		wheelFactor = 20;
        myComponent = gameObject.GetComponent<ComponentClass>();
	}
	
	void FixedUpdate () {

		if (myComponent.isAttachedToSomething && Input.GetKey(KeyCode.W))
		{
			gameObject.transform.Rotate(rotateAxis, Time.deltaTime * wheelFactor);
			GlobalReferences.RobotCentre.GetComponent<Rigidbody>().AddForce(GlobalReferences.RobotCentre.transform.up * forceFactor);
		}	
		if (myComponent.isAttachedToSomething && Input.GetKey(KeyCode.A))
		{
			gameObject.transform.Rotate(rotateAxis, Time.deltaTime * wheelFactor);
			GlobalReferences.RobotCentre.GetComponent<Rigidbody>().AddForce(GlobalReferences.RobotCentre.transform.up * -forceFactor);
		}	
		if (myComponent.isAttachedToSomething && Input.GetKey(KeyCode.S))
		{
			gameObject.transform.Rotate(rotateAxis, Time.deltaTime * wheelFactor);
			GlobalReferences.RobotCentre.GetComponent<Rigidbody>().AddTorque(GlobalReferences.RobotCentre.transform.up * torqueFactor);
		}	
		if (myComponent.isAttachedToSomething && Input.GetKey(KeyCode.D))
		{
			gameObject.transform.Rotate(rotateAxis, Time.deltaTime * wheelFactor);
			GlobalReferences.RobotCentre.GetComponent<Rigidbody>().AddTorque(GlobalReferences.RobotCentre.transform.up * -torqueFactor);
		}	
		if (myComponent.isAttachedToSomething && Input.GetKey(KeyCode.D))
		{
			gameObject.transform.Rotate(rotateAxis, Time.deltaTime * wheelFactor);
			GlobalReferences.RobotCentre.GetComponent<Rigidbody>().AddTorque(GlobalReferences.RobotCentre.transform.up * -torqueFactor);
		}	
		if (Input.GetMouseButton (0))  // left click
		{

		}
		if (Input.GetMouseButton (1))  // right click
		{

		}
		if (Input.GetMouseButton (2))  // middle click
		{

		}




	}
}
