using UnityEngine;
using System.Collections;

public class Part1 : MonoBehaviour {

	public Door getdoor;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (getdoor.Open()){
			while(gameObject.transform.position.z <= 21.5){
				transform.Translate (0f, 0f, 0.1f);
			}
		}
	}
}
