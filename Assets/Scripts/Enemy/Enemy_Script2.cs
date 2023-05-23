using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Script2 : Enemy_Script
{
    public Transform target;
    void Start()
    {
        
    }
    void Update()
    {
        charge();
        down();
    }

    public void charge()
    {
        Vector2 direction = target.position - transform.position;
        transform.rotation = Quaternion.FromToRotation(Vector3.up, direction);
        transform.position += transform.up * speed * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        //Kills the enemy when past the box collider
        if (other.gameObject.CompareTag("PastKiller"))
        {
            Destroy(this.gameObject);
        }
    }
}
