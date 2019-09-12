using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    float maxSpeed = 18f; 

    float shipBoundaryRadius = 0f;   
 
    void Update() // biarder in a scene
    {//user input
       

        Vector3 pos = transform.position;
     
        pos.x += Input.GetAxis("Horizontal") * maxSpeed * Time.deltaTime;
      

        float screenRatio = (float)Screen.width / (float)Screen.height;
        float widhtOrtho = Camera.main.orthographicSize * screenRatio;
        if (pos.x + shipBoundaryRadius > 97.5f)//150 right
        {
            pos.x = 97.5f - shipBoundaryRadius;
        }
        if (pos.x - shipBoundaryRadius < (80.5f)/*widhtOrtho*/)
        {
            pos.x = (80.5f) + shipBoundaryRadius;
        }
      
        transform.position = pos;

    }
}
