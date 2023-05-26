using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack_Base : MonoBehaviour
{
    public Rigidbody2D attackRigidBody;
    private float _lifeInSeconds = 2.5f;
    private int _speed = 10;

    // Start is called before the first frame update
    void Start()
    {
        attackRigidBody = GetComponent<Rigidbody2D>();
        
        if (gameObject.name.Contains("(Clone)"))
        {
            Destroy(gameObject, _lifeInSeconds);
        }
    }

    // Update is called once per frame
    void Update()
    {
        attackRigidBody.velocity = Vector2.up * _speed;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Enemy"))
        {
            Destroy(this.gameObject);
        }
        if(other.gameObject.CompareTag("Kevlar"))
        {
            Destroy(this.gameObject);
        }
    }
}
