using UnityEngine;
using System.Collections;

public class Button : MonoBehaviour {

	public EndofLvl currentLvl;
	public int x;
	private int counter;
	private bool counterTime = false;
	// Use this for initialization
	void Start () {
		x = 0;

	}

	// Update is called once per frame
	void Update () 
	{
		if (counterTime == true) {
			counter++;
			if (counter == 10) {
				x = 0;
				counter = 0;
				counterTime = false;
			}
		}
	}

	void OnCollisionEnter(Collision activate){

		Debug.Log ("booom");
		counterTime = true;
		if (currentLvl.Next () == "Lvl2")
			x = 2;
		if (currentLvl.Next () == "Lvl3")
			x = 3;
	}

	void OnTriggerEnter(Collider triggerBOOM) {
		Debug.Log ("BOOM MUTHAFUCKA");
		counterTime = true;
		if (currentLvl.Next () == "Lvl2")
			x = 2;
		if (currentLvl.Next () == "Lvl3")
			x = 3;
	}

	public int Activate(){
		return x;
	}


}
