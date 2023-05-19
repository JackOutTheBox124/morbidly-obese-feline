using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Script : MonoBehaviour
{
    public float speed = 1;
    public float downSpeed = 1;
    void Start()
    {
        
    }

    void Update()
    {
        if (transform.position.x < -9 || transform.position.x > 9)
        {
            speed *= -1;
        }
        gameObject.transform.position += Vector3.left * (speed/10);
        gameObject.transform.position += Vector3.down * (downSpeed / 100);
    }
}
