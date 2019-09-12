using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
   
    void OnTriggerEnter2D(Collider2D o) // increase score
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
