using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagedByCollision : MonoBehaviour
{
  
    public  int health = 1;

    public float invulnPeriod = 0;// can use it to do object Unbreakable
    float invulnTimer = 0;
    int correctLayer;// need to save first obj layer

    void Start()
    {
        correctLayer = gameObject.layer;
    }

    void OnTriggerEnter2D(Collider2D o)
    { 
      Debug.Log("Trigger!");
      
        if (o.gameObject.tag != "mushroom")  // if object collide with another that has tag mushroom
        {
            Debug.Log("!p4!");
            health--;
            invulnTimer = invulnPeriod;// 0.5f;
            gameObject.layer = 10; //  can't die
        }
      
    }

    void Update()
    {
        invulnTimer -= Time.deltaTime;
        if (invulnTimer<=0)
        {
            gameObject.layer = correctLayer; // can die
        }

        if (health <= 0)// object die if it doesn't have ani lifes
        {
            Die();
        }
    }
    void Die() // destroy gameobject
    {
        Destroy(gameObject);
    }
}
