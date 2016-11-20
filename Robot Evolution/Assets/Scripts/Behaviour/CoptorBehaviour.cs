using UnityEngine;
using System.Collections;

public class CoptorBehaviour : MonoBehaviour {

	private ComponentClass myComponent;
	private int forceFactor, spinFactor;

	void Start () {
		forceFactor = 10;
		spinFactor = 10;
		myComponent = gameObject.GetComponent<ComponentClass>();
	}

	void FixedUpdate () {

		if (myComponent.isAttachedToSomething && Input.GetKey(KeyCode.Space))
		{
			//gameObject.transform.Rotate(rotateAxis, Time.deltaTime * wheelFactor);
			GlobalReferences.RobotCentre.GetComponent<Rigidbody>().AddForce(Vector3.up * forceFactor);
			gameObject.transform.RotateAround (gameObject.transform.up, Time.deltaTime * spinFactor);
		}


	}
}
