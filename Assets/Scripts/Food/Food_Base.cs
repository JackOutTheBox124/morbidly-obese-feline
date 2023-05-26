using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food_Base : MonoBehaviour
{
    public Rigidbody2D foodRigidbody;
    //private int speed = 1;
    void Start()
    {
        foodRigidbody = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        foodRigidbody.transform.position += Vector3.down * .05f;
        // gameObject.transform.position += 
    }
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.CompareTag("Feline"))
        {
            other.gameObject.GetComponent<Feline_Attack>().addBloodSugar(10);
            Destroy(this.gameObject);
        }
    }
}
