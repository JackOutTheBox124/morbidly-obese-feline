using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Feline_Script : MonoBehaviour
{
    public Rigidbody2D felineRigidBody;

    private int speed = 10;
    void Start()
    {
        felineRigidBody = GetComponent<Rigidbody2D>();
    }

    //Moves the feline when you press it
    void Update()
    {
        Move();
    }

    //Move method, detects when you input a key and then multiplys it with speed at a raw axis from -1 to 1 in the verticle and horizontal direction based on which key you press
    //Keeps you from moving out of bounds
    public void Move()
    {
        Vector3 Movement = new Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"), 0);
        
        felineRigidBody.transform.position += Movement * speed * Time.deltaTime;
        if (transform.position.x > 11)
        {
            transform.position = new Vector3(10.9f, transform.position.y);
        }

        if (transform.position.x < -11)
        {
            transform.position = new Vector3(-10.9f, transform.position.y);
        }

        if (transform.position.y < -4.45)
        {
            transform.position = new Vector3(transform.position.x, -4.4f);
        }
    }
}
