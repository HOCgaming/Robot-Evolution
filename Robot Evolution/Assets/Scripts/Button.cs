using UnityEngine;
using System.Collections;

public class Button : MonoBehaviour {

	public CraftinPillars pillarscript;  
	public bool PillarUp; 

	// Use this for initialization
	void Start () 

	}

	// Update is called once per frame
	void Update () 
	{
		if (PillarUp == true)	
			pillarscript.pillarUp();
			
	}

	void OnCollisionEnter(Collision activate) 
	{
		if (activate.gameObject.tag == "buttonpillar") {
			transform.Translate (0.1f, 0f, 0f);
			transform.Translate (-0.1f, 0f, 0f);
			PillarUp = true; 
		}
	}

}
