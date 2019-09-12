using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mushroom : MonoBehaviour
{
    public int health = 4;

    //   int correctLayer;// need to save first obj layer
    //void Start()
    //{
    //    correctLayer = gameObject.layer;
    //}

    void OnTriggerEnter2D(Collider2D o)
    {
        Debug.Log("Trigger!");
        if (o.gameObject.tag == "bullet")
        {
            Debug.Log("p4!");
            health--;
            Destroy(o.gameObject);
        }
        //  gameObject.layer = 10; //  can't die

    }

    void Update()
    {
        if (health <= 0)
        {
            Die();
        }
    }
    void Die()
    {
        Destroy(gameObject);
    }

}
