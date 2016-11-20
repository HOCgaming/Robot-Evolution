using UnityEngine;
using System.Collections;

public class Level4 : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void FourthtLvl(float x) {

		if ((gameObject.transform.position.y <= -2.07f) && (gameObject.transform.position.y >= -6f)) {
			transform.Translate (0f, x, 0f);
		}
	}
}
