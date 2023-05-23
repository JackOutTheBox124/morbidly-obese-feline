using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicEnemyBullet : MonoBehaviour
{
    public int lifetime = 10;
    public int speed = 2;
    void Start()
    {
        
    }
    void Update()
    {
        transform.position += transform.up * speed * Time.deltaTime;
    }
}
