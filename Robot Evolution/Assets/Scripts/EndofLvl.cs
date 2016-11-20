using UnityEngine;
using System.Collections;

	public class EndofLvl : MonoBehaviour {
	public int previousLvl;
    private Vector3 startPos = new Vector3(-6.3f, 2f, -2.9f);

	// Use this for initialization
	void Start () {
		previousLvl = 2;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter(Collision activate) 
	{
        if (activate.gameObject.tag == "grabbableTag")
        {
            previousLvl++;
            BackToStart();
        }
		
	}

    public void BackToStart()
    {
        GlobalReferences.RobotCentre.transform.position = startPos;
    }


	public string Next()
	{
		return "Lvl" + previousLvl;
	}
		
		
}
