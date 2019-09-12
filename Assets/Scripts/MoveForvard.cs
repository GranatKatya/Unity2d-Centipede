using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveForvard : MonoBehaviour
{
  public float maxSpeed = 1f;


    void Update() // move forvard
    {
        Vector3 pos = transform.position;
        Vector3 velocity = new Vector3(0,  maxSpeed * Time.deltaTime , 0 );
        pos += (transform.rotation) *  velocity;
        transform.position = pos;
    }
}
