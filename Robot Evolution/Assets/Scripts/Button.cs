using UnityEngine;
using System.Collections;

public class Button : MonoBehaviour {
	
	public EndofLvl currentLvl;
	public int x;

	// Use this for initialization
	void Start () {
		x = 0;
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter(Collision activate){
		if (currentLvl.Next () == "Lvl2")
			x = 2;
	}

	public int Activate(){
		return x;
	}

			
}
