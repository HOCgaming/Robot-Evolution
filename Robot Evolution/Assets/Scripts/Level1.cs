using UnityEngine;
using System.Collections;

public class Level1 : MonoBehaviour {

    int thisInt = 1;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        if(thisInt == 1) { FirstLvl(0.05f); }
	
	}
	public void FirstLvl(float x) {

		if ((gameObject.transform.position.y <= -8.147f) && (gameObject.transform.position.y >= -9f)) {
			transform.Translate (0f, x, 0f);
		}
	}
}


