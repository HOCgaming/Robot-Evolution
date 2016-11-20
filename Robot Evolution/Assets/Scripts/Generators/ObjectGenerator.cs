using UnityEngine;
using System.Collections;

public class ObjectGenerator : MonoBehaviour {

	public GameObject generatorObject; 
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerExit(Collider activate){
		if (activate.gameObject == generatorObject)
			GenerateNewObject();
	}

	void GenerateNewObject(){
		GameObject newObject = Instantiate (generatorObject);
	}

}
