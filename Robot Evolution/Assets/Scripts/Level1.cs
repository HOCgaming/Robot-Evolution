﻿using UnityEngine;
using System.Collections;

public class Level1 : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	public void FirstLvl(float x) {

		if ((gameObject.transform.position.y <= -8.147f) && (gameObject.transform.position.y >= -10f)) {
			transform.Translate (0f, x, 0f);
		}
	}
}


