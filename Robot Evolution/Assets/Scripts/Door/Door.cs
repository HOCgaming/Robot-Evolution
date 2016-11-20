using UnityEngine;
using System.Collections;

public class Door : MonoBehaviour {

	public bool x;
	// Use this for initialization
	void Start () {
		x = true;
	}
	
	// Update is called once per frame
	void Update () {
			
		// Check of laser shine on the door.
	
	}

	public bool Open(){
		if (x)
			return true;
		else
			return false;
	}

}
