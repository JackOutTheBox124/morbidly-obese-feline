using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoTargetBullet : BasicEnemyBullet
{
    //Destroys this object after a certain amount of time
    void Start()
    {
        if (gameObject.name.Contains("(Clone)"))
        {
            Destroy(gameObject, lifetime);
        }
    }

    //Just goes forward based on its rotation
    void Update()
    {
        transform.position += transform.up * -1 * speed / 100;
    }
}
