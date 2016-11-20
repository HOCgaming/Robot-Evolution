using UnityEngine;
using System.Collections;

public class Level2 : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void SecondLvl(float x) {

		if ((gameObject.transform.position.y <= 0f) && (gameObject.transform.position.y >= -4f)) {
			transform.Translate (0f, x, 0f);
		}
	}
}
