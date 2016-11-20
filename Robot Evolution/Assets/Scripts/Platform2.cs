using UnityEngine;
using System.Collections;

public class Platform2 : MonoBehaviour {

	public Button button;
	public bool MaxHeight;

	// Use this for initialization
	void Start () {
		MaxHeight = false;
	}
	
	// Update is called once per frame
	void Update () {
		
		if (gameObject.transform.position.y >= 0.43f) {
			MaxHeight = true;
		}
		if ((button.Activate () == 2) && (!MaxHeight)) {
			Debug.Log (button.Activate ());
			transform.Translate (0f, 0.005f, 0f);
		}
		if (MaxHeight && gameObject.transform.position.y >= 0.035) {
			transform.Translate (0f, -0.01f, 0f);
		}

	}


		
}
