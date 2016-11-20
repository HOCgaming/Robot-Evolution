using UnityEngine;
using System.Collections;

public class RightDScript : MonoBehaviour {

	public Door getdoor;
	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () 
	{
		//if (true){//
		//{
		if(gameObject.transform.position.z > 5.2)
		{
			Debug.Log (gameObject.transform.position.z);
			transform.Translate (0f, 0f, -0.1f);
		}
		//}
	}
}