using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicEnemyBullet : MonoBehaviour
{
    public int lifetime = 10;
    public int speed = 2;
    public Vector3 target;
    Vector3 dir;

    void Start()
    {
        //transform.rotation = Quaternion.Euler(transform.position - target.transform.position);
        target = GameObject.Find("Feline").transform.position;
        dir = (transform.position - target);
    }
    void Update()
    {
        Destroy(gameObject, 5);
        transform.position += dir.normalized * -1 * speed/10;
    }
}
