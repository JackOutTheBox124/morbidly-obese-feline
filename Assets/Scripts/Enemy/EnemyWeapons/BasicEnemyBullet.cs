using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicEnemyBullet : MonoBehaviour
{
    public int lifetime = 10;
    public float speed = 2;
    public Vector3 target;
    public Vector3 dir;

    void Start()
    {
        //transform.rotation = Quaternion.Euler(transform.position - target.transform.position);
        target = GameObject.Find("Feline").transform.position;
        dir = (transform.position - target);
        if (gameObject.name.Contains("(Clone)"))
        {
            Destroy(gameObject, lifetime);
        }
    }
    void Update()
    {
        transform.position += dir.normalized * -1 * speed/10;
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
