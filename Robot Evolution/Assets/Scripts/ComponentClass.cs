using UnityEngine;
using System.Collections;

public class ComponentClass : MonoBehaviour {

    public bool isCentrePart, isAttached = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void setAttached(bool input)
    {
        isAttached = input;
    }
}
