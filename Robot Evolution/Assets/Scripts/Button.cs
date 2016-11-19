using UnityEngine;
using System.Collections;

public class Button : MonoBehaviour {

	public CraftinPillars pillarscript;  
	public Level1 lvl1script; 
	public bool PillarUp; 
	public bool Lvl1;


	// Use this for initialization
	void Start () {
		Lvl1 = true;
		PillarUp = true; 
	}


	// Update is called once per frame
	void Update () 
	{
		if (PillarUp == true)	
			pillarscript.pillarUp(0.001f);
		if (PillarUp == false)
			pillarscript.pillarUp(-0.01f);
		if (Lvl1 == true)
			lvl1script.FirstLvl(0.01f);
		if (Lvl1 == false)
			lvl1script.FirstLvl(-0.01f);
	}

	void OnCollisionEnter(Collision activate) 
	{
		if (activate.gameObject.tag == "button") {
			transform.Translate (0.1f, 0f, 0f);
			transform.Translate (-0.1f, 0f, 0f);
			PillarUp = true; 
			Lvl1 = true;
		}
	}

}
