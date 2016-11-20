using UnityEngine;
using System.Collections;

public class Platform2 : MonoBehaviour {

	public Button button;
	public bool MaxHeight;
	public bool deactivate;

	// Use this for initialization
	void Start () {
		MaxHeight = false;
		deactivate = false;
	}
	
	// Update is called once per frame
	void Update () {
		Debug.Log (button.Activate ());

		if (gameObject.transform.position.y >= 0.43f) {
			MaxHeight = true;
		} 
		if ((button.Activate() == 2) && (!MaxHeight)) {
			transform.Translate (0f, 0.001f, 0f);
		}
		if (MaxHeight && gameObject.transform.position.y >= 0.01) {
			transform.Translate (0f, -0.01f, 0f);
			if (gameObject.transform.position.y <= 0.01)
				deactivate = true;
				
				
		}

	}

	public bool Deactivate() {
		if (deactivate) {
			return true;
		}
		else {
			return false;
		}
	}


}
