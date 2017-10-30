using UnityEngine;
using System.Collections;

public class LaserDoor : MonoBehaviour {

	public bool shineLazer;
	// Use this for initialization
	void Start () {
		shineLazer = false;
	}
	
	// Update is called once per frame
	void Update () {
		
		if (shineLazer && gameObject.transform.position.x <=8f)
			transform.Translate (0.01f, 0f, 0f);
	}
}
