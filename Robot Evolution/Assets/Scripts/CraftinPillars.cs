﻿using UnityEngine;
using System.Collections;

public class CraftinPillars : MonoBehaviour {


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void pillarUp(float x){
		
		if ((gameObject.transform.position.y < 0.05f) && (gameObject.transform.position.y >= -0.13f)){
			transform.Translate (0f, x, 0f);
		}
	}

}