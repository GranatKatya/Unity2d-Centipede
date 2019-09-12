using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// class to delete elements if it's create a long time and take a lot of size in memorry
/// </summary>
public class SelfDestract : MonoBehaviour
{
    public float timer = 1f;

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if (timer<=0)
        {
            Destroy(gameObject);
        }
    }
}
