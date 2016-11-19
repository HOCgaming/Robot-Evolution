using UnityEngine;
using System.Collections;

public class EndofLvl : MonoBehaviour {
	public int previousLvl;

	// Use this for initialization
	void Start () {
		previousLvl = 1;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter(Collision activate) 
	{
		previousLvl++;
	}



	public string Next()
	{
		return "Lvl" + previousLvl;
	}
		
		
}
