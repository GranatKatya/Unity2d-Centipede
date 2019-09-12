﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public Vector3 bullrtOffset = new Vector3(0, 0.6f, 0);

    public GameObject bulletPrefab;
    int bulletLayer;

    public float fireDelay = 0.25f; 
    float cooldownTimer = 0;

    void Start()
    {
        bulletLayer = gameObject.layer;
    }

    // Update is called once per frame
    void Update()
    {
        cooldownTimer -= Time.deltaTime;
        if (Input.GetButton("Fire1") && cooldownTimer <=0)
        {
            //SHOOT
         //   Debug.Log("Pew!");
            cooldownTimer = fireDelay;  

            Vector3 offset = transform.rotation * bullrtOffset;

         //   Instantiate(bulletPrefab, transform.position + offset, transform.rotation);
            GameObject bulletGO = (GameObject)Instantiate(bulletPrefab, transform.position + offset, transform.rotation);
            bulletGO.layer = bulletLayer;
        }
    }
    
}