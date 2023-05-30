using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AccelerateBullet : BasicEnemyBullet
{
    public float acceleration = 0.01f;
    void Start()
    {
        target = GameObject.Find("Feline").transform.position;
        dir = (transform.position - target);
        if (gameObject.name.Contains("(Clone)"))
        {
            Destroy(gameObject, lifetime);
        }
        transform.up = (transform.position - target) * -1;
    }

    void Update()
    {
        transform.position += dir.normalized * -1 * speed / 10;
        speed += acceleration * Time.deltaTime;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        //Bullet dies on cat 
        if (other.gameObject.CompareTag("Feline"))
        {
            Destroy(this.gameObject);
        }
    }
}
