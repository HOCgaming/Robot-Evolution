using UnityEngine;
using System.Collections;

public class CraftinPillars : MonoBehaviour {


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void pillarUp(){

		if (gameObject.transform.position.y < 0.20f) {
			transform.Translate (0f, 0.01f, 0f);
		}
	}

}
