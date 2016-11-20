using UnityEngine;
using System.Collections;

public class LeftDScript : MonoBehaviour {

	public Door getdoor;
	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
		//if (true){
		if(gameObject.transform.position.z <= 8.2)
		{
			transform.Translate (0f, 0f, 0.1f);
		}
		//}
	}
}