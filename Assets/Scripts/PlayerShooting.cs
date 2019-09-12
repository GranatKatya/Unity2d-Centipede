using System.Collections;
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
        if (Input.GetButton("Fire1") && cooldownTimer <=0)//create bullet to shoot 
        {           
            cooldownTimer = fireDelay;  

            Vector3 offset = transform.rotation * bullrtOffset;
        
            GameObject bulletGO = (GameObject)Instantiate(bulletPrefab, transform.position + offset, transform.rotation);
            bulletGO.layer = bulletLayer;
        }
    }
    
}
