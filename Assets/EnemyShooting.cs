using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooting : MonoBehaviour
{

    public Vector3 bullrtOffset = new Vector3(0, 0.5f, 0);
    public GameObject bulletPrefab;

    public float fireDelay = 0.50f;
    float cooldownTimer = 0;
    // Update is called once per frame

    int bulletLayer;

    void Start()
    {
        bulletLayer = gameObject.layer;
    }



    void Update()
    {
        cooldownTimer -= Time.deltaTime;
        if ( cooldownTimer <= 0)
        {
            //SHOOT
           // Debug.Log("Pew!");
            cooldownTimer = fireDelay;

            Vector3 offset = transform.rotation * bullrtOffset;

        GameObject bulletGO = (GameObject)    Instantiate(bulletPrefab, transform.position + offset, transform.rotation);
            //  bulletGO.layer = gameObject.layer; 
            bulletGO.layer = bulletLayer;
        }
    }
}
