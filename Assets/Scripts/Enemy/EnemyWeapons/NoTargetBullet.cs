using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoTargetBullet : BasicEnemyBullet
{
    void Start()
    {
        if (gameObject.name.Contains("(Clone)"))
        {
            Destroy(gameObject, lifetime);
        }
    }

    void Update()
    {
        transform.position += transform.up * -1 * speed / 100;
    }
}
