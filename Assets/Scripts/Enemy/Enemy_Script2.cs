using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Script2 : Enemy_Script
{
    public Transform target;
    public int rotateSpeed = 3;
    void Start()
    {
        target = GameObject.Find("Feline").transform;
    }
    void Update()
    {
        charge();
        down();
    }

    public void charge()
    {
        Vector3 direction = target.position - transform.position;
        transform.Rotate(0,0,3);
        transform.position += (direction.normalized) * speed * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        //Kills the enemy when past the box collider or feline
        if (other.gameObject.CompareTag("PastKiller") || other.gameObject.CompareTag("Feline"))
        {
            Destroy(this.gameObject);
        }

        //HeartBurn attack kills enemy
        if(other.gameObject.CompareTag("HeartBurn"))
        {
            Destroy(this.gameObject);
        }
    }
}
