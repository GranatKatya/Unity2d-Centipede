using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    float maxSpeed = 18f;
    //float rotSpeed = 180f;

    float shipBoundaryRadius = 0f;
   
    // Update is called once per frame
    void Update()
    {//user input
        //Rotation
        //Quaternion rot = transform.rotation;
        //float z = rot.eulerAngles.z;
        //z -= Input.GetAxis("Horizontal") * rotSpeed * Time.deltaTime;
        //rot = Quaternion.Euler(0,0,z);
        //transform.rotation = rot;

        Vector3 pos = transform.position;
       // Debug.Log( "POS" + pos);
        pos.x += Input.GetAxis("Horizontal") * maxSpeed * Time.deltaTime;
        //Debug.Log("POS" + pos);
        //// pos.y += Input.GetAxis("Vertical") * maxSpeed * Time.deltaTime;

        //up/down
        //Vector3 pos = transform.position;
        //Vector3 vvelocity = new Vector3(0, Input.GetAxis("Vertical") * maxSpeed * Time.deltaTime , 0 );
        //  pos += rot * vvelocity;
        //  transform.position = pos;


        //baundaries
        //if (pos.y + shipBoundaryRadius > Camera.main.orthographicSize)
        //{
        //    pos.y = Camera.main.orthographicSize - shipBoundaryRadius;
        //}
        //if (pos.y - shipBoundaryRadius < -Camera.main.orthographicSize)
        //{
        //    pos.y = -Camera.main.orthographicSize + shipBoundaryRadius;
        //}
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
        //  Debug.Log("widhtOrtho "+ widhtOrtho);
        //  Debug.Log("screenRatio " + screenRatio);
        transform.position = pos;

    }
}
