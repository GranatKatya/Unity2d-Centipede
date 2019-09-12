using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// it is additional game object, one more enemy
/// i don't use it yet 
/// </summary>
public class FacesPlayer : MonoBehaviour
{
  public   float rotSpeed = 180f;
    Transform player;

    // Update is called once per frame
    void Update()
    {
        if (player == null)
        {
            GameObject go = GameObject.Find("PlayerShip");

            if (go != null)
            {
                player = go.transform;
            }
        }
        if (player == null)
        {
            return;//Try again next frame
        }

        Vector3 dir = player.position - transform.position;
        dir.Normalize();

        float zAngle = Mathf.Atan2(dir.y, dir.x  ) * Mathf.Rad2Deg-90;
        Quaternion desireRotation = Quaternion.Euler(0,0,zAngle);
       transform.rotation =  Quaternion.RotateTowards(transform.rotation , desireRotation , rotSpeed * Time.deltaTime);
    }
}
