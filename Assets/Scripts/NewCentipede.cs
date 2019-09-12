using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// class for new level 
/// i don't yse it yet
/// </summary>
public class NewCentipede : MonoBehaviour
{
    public GameObject headPrefab;
    public GameObject bodyPrefab;
    public static GameObject headPrefab1;
    public static GameObject bodyPrefab1;

    public static GameObject[] сentipedeObjects;// array for objects with tag  "snakehead"


     public static  List<Vector3> coordiates = new List<Vector3> { new Vector3(90, -40, 0), new Vector3(89, -40, 0), new Vector3(88, -40, 0), new Vector3(87 - 40, 0), new Vector3(86, -40, 0), };


    void Awake()
    {
        headPrefab1 = headPrefab;
        bodyPrefab1 = bodyPrefab;
    }

    public static void CreateCentipade() { // create new centipade for new level
        for (int i = 0; i < coordiates.Count; i++)
        {
            if (i == 0)
            {
                Instantiate(headPrefab1, coordiates[0] , new Quaternion(0, 0, 0, 1));
             
            }
            else
            {
               Instantiate(bodyPrefab1, coordiates[i], new Quaternion(0,0,0, 0));
                
            }                  
        }
       
    }



    public static  void DeleteCentipade()// delete centipade for new level 
    {
        сentipedeObjects = GameObject.FindGameObjectsWithTag("snakehead");
        Debug.Log("DeleteCentipade сentipedeObjects " + сentipedeObjects.Length);

        for (int i = 0; i < сentipedeObjects.Length; i++)
        {
            Debug.Log("DeleteCentipade entipedeObjects[i] " + сentipedeObjects[i]);
            Destroy(сentipedeObjects[i]);
            i--;
        }

    }
}
