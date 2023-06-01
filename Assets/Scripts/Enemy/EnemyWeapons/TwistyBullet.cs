using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TwistyBullet : BasicEnemyBullet
{
    private float creationTime;
    private float timeSinceCreation;
    private Vector3 sinDir;
    void Start()
    {
        //Marks the time this object was created
        creationTime = Time.time;

        target = GameObject.Find("Feline").transform.position;
        dir = (transform.position - target);
        if (gameObject.name.Contains("(Clone)"))
        {
            Destroy(gameObject, lifetime);
        }
    }

    //Gives the bullet a wavy pattern
    void Update()
    {
        //Swaps the sinDir x and y with normal dir x and Y
        sinDir.x = dir.y;
        sinDir.y = dir.x * -1;

        //Moves the bullet
        timeSinceCreation = Time.time - creationTime;
        gameObject.transform.position += (dir.normalized * -1 * speed / 10);
        gameObject.transform.position += sinDir.normalized * Mathf.Sin(timeSinceCreation * 10) / 10;
    }
}
