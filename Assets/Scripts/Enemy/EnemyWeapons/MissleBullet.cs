using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissleBullet : BasicEnemyBullet
{
    public float rotationSpeed = 1;
    void Start()
    {
        target = GameObject.Find("Feline").transform.position;
        transform.right = (target - transform.position);
        if (gameObject.name.Contains("(Clone)"))
        {
            Destroy(gameObject, lifetime);
        }
    }
    void Update()
    {
        target = GameObject.Find("Feline").transform.position;
        dir = (target - transform.position);

        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, rotationSpeed * Time.deltaTime);

        transform.position += transform.right * speed / 10;
    }
}
