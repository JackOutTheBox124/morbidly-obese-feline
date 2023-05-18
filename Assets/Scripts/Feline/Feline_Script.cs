using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Feline_Script : MonoBehaviour
{
    public Rigidbody2D felineRigidBody;

    private int speed = 10;
    // Start is called before the first frame update
    void Start()
    {
        felineRigidBody = GetComponent<Rigidbody2D>();
        // Vector3 Movement = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));

    }

    // Update is called once per frame
    void Update()
    {
        // if (Input.GetKey(KeyCode.W)) { felineRigidBody.AddForce(Vector2.up); }
    Move();
    }

    public void Move()
    {
     
        Vector3 Movement = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0);
        
        felineRigidBody.transform.position += Movement * speed * Time.deltaTime;
    
    }
}
