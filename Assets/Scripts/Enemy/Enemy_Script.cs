using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Script : MonoBehaviour
{
    public float speed = 1;
    public float downSpeed = 1;
    public int health = 1;
    void Start()
    {
        
    }

    void Update()
    {
        sideToSide();
        down();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        //Kills the enemy when past the box collider
        if (other.gameObject.CompareTag("PastKiller"))
        {
            Destroy(this.gameObject);
        }
    }

    public void sideToSide()
    {
        //Changes the direction of the enemy when it reaches a certain x world point
        if (transform.position.x < -9 || transform.position.x > 9)
        {
            speed *= -1;
        }
        //Makes the enemy go to the left or right, and down
        gameObject.transform.position += Vector3.left * (speed / 10);
    }

    public void down()
    {
        gameObject.transform.position += Vector3.down * (downSpeed / 100);
    }
}
