using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagedByCollision : MonoBehaviour
{
    //void OnCollisionEnter2D()
    //{
    //    Debug.Log("Collision!");
    //}
    

    public  int health = 1;

    public float invulnPeriod = 0;
    float invulnTimer = 0;
    int correctLayer;// need to save first obj layer

    void Start()
    {
        correctLayer = gameObject.layer;
    }

    void OnTriggerEnter2D(Collider2D o)
    { 
      Debug.Log("Trigger!");
        //    if (invuln<=0)
        // {
        if (o.gameObject.tag != "mushroom")
        {
            Debug.Log("!p4!");
            health--;
            invulnTimer = invulnPeriod;// 0.5f;
            gameObject.layer = 10; //  can't die
        }
        //}   
    }

    void Update()
    {
        invulnTimer -= Time.deltaTime;
        if (invulnTimer<=0)
        {
            gameObject.layer = correctLayer; // can die
        }

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
