using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    GameObject[] сentipedeObjects;// array for objects with tag  "snakehead"
    private bool IsCentipadeDie() // neeed to ckeck if there are parts of centipade or on
    {  GameObject[] сentipedeObjects;// array for objects with tag  "snakehead"
        Debug.Log("IsCentipadeDie");
        //GameObject [] сentipede = null;
        // сentipedeObjects = null;
        сentipedeObjects = GameObject.FindGameObjectsWithTag("snakehead");

        if (сentipedeObjects.Length - 1 > 0)
        {
            // Debug.Log("сentipedeObjects.Length > 0 сentipedeObjects.Length " + сentipedeObjects.Length);
            return false;
        }
        else
        {
            // Debug.Log("сentipedeObjects.Length !> 0 сentipedeObjects.Length " + сentipedeObjects.Length);
            return true;//die
        }
    }

    void OnTriggerEnter2D(Collider2D o)
    {
        if (o.gameObject.tag == "mushroom")
        {
            GameHandler.AddScore(100);
        }
        if (o.gameObject.tag == "snakehead")
        {
                     
            GameHandler.AddScore(300);
        }   
    }
}
