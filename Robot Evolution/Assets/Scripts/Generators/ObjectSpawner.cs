using UnityEngine;
using System.Collections;

public class ObjectSpawner : MonoBehaviour {

    //CUBE = 0;
    //T_BAR = 1;
    //WHEEL = 2;
    //COPTOR = 3;
    //MOTOR = 4;

    public const int QUANTITY = 5;
    public GameObject[] spawnPositions = new GameObject[QUANTITY];

    public void spawnNewMe(GameObject inputObject, int id)
    {
        GameObject newObject = Instantiate(inputObject);
        newObject.transform.position = spawnPositions[id].transform.position;
    }
}
