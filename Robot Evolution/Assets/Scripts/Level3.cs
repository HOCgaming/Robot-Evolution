using UnityEngine;
using System.Collections;

public class Level3 : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void ThirdLvl(float x) {

		if ((gameObject.transform.position.y <= -0.598f) && (gameObject.transform.position.y >= -3f)) {
			transform.Translate (0f, x, 0f);
		}
	}
}
