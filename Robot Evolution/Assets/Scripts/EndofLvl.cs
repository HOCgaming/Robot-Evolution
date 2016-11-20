using UnityEngine;
using System.Collections;

	public class EndofLvl : MonoBehaviour {
	public int currentLvl;
	public Level1 lvl1script; 
	public Level2 lvl2script; 
	public Level3 lvl3script;
	public Level4 lvl4script;
	public bool PillarUp; 
	public CraftinPillars pillarscript;


	// Use this for initialization
	void Start () {
		PillarUp = true;
		currentLvl = 1;
	}


	// Update is called once per frame
	void Update ()
	{
		//Debug.Log (currentLvl);
		if (PillarUp) {
			pillarscript.pillarUp (0.008f);
		} else {//if (!PillarUp) 
			pillarscript.pillarUp (-0.01f);
		}

		switch (currentLvl) {
		case 1:
			lvl1script.FirstLvl (0.03f);
			break;
		case 2:
			//lvl1script.FirstLvl (-0.1f);
			lvl1script.gameObject.SetActive(false);
			lvl2script.SecondLvl (0.03f);
			break;
		case 3: 
			//lvl2script.SecondLvl (-0.1f);
			lvl2script.gameObject.SetActive(false);
			lvl3script.ThirdLvl (0.03f);
			break;
		case 4:
			//lvl3script.ThirdLvl (-0.1f);
			lvl3script.gameObject.SetActive(false);
			lvl4script.FourthtLvl (0.03f);
			break;
		case 5:
			//lvl4script.FourthtLvl (-0.1f);
			lvl4script.gameObject.SetActive(false);
			break;
		}
	}

			
	/*
		if (currentLvl == 1) {
			lvl1script.FirstLvl (0.03f);
		}
		if (currentLvl != 1) {
			lvl1script.FirstLvl (-0.1f);
		}
		if (currentLvl == 2) {
			lvl2script.SecondLvl (0.03f);
		}
		if (currentLvl != 2) {
			lvl2script.SecondLvl (-0.1f);
		}
		if (currentLvl == 3) {
			lvl3script.ThirdLvl (0.03f);
		}
		if (currentLvl != 3) {
			lvl3script.ThirdLvl (-0.1f);
		}
		if (currentLvl == 4) {
			lvl4script.FourthtLvl (0.03f);
		} 
		if (currentLvl != 4) {
			lvl4script.FourthtLvl (-0.1f);
		}  */
		

	void OnCollisionEnter(Collision activate) 
	{
		currentLvl++;
	}

	public int Next()
	{
		return currentLvl;
	}
		
}
