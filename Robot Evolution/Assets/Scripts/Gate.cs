using UnityEngine;
using System.Collections;

public class Gate : MonoBehaviour {

	public Button button;
	private bool reachedMaxHeight;
	private bool enabled;

	// Use this for initialization
	void Start () {
		reachedMaxHeight = false;
		enabled = false;

		Debug.Log (button.Activate ());
	}

	// Update is called once per frame
	void Update () {
		/*
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
		*/
		if (enabled == false) {
			if (button.Activate () == 3) {
				enabled = true;
			}
		}

		if (enabled == true) {
			if (reachedMaxHeight == false) 
			{
				// going up
				transform.Translate (0f, 0.5f, 0f);
			} 
			else 
			{
				// going down
				transform.Translate (0f, -0.1f, 0f);
			}
		}

		if (gameObject.transform.position.y >= 2.6f) {
			reachedMaxHeight = true;
		}

		if (gameObject.transform.position.y <= 1.6f) {
			reachedMaxHeight = false;
			enabled = false;

			Debug.Log (button.Activate ());
		}

	}



}