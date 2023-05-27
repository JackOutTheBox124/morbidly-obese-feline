using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TwistyBullet : BasicEnemyBullet
{
    private float creationTime;
    private float timeSinceCreation;
    private Vector3 perpDir;
    void Start()
    {
        creationTime = Time.time;

        target = GameObject.Find("Feline").transform.position;
        dir = (transform.position - target);
        if (gameObject.name.Contains("(Clone)"))
        {
            Destroy(gameObject, lifetime);
        }
    }
    void Update()
    {
        perpDir.x = dir.y;
        perpDir.y = dir.x * -1;

        timeSinceCreation = Time.time - creationTime;
        gameObject.transform.position += (dir.normalized * -1 * speed / 10);
        gameObject.transform.position += perpDir.normalized * Mathf.Sin(timeSinceCreation * 10) / 10;
    }
}
