using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Feline_Health : MonoBehaviour
{
    private int health = 3;
    private float damageCooldownSeconds = 1.5f;
    private float lastTimeDamaged;
    // Start is called before the first frame update
    void Start()
    {
        lastTimeDamaged = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if(health < 1)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.CompareTag("Enemy") && (lastTimeDamaged + damageCooldownSeconds < Time.time))
        {
            health--;
            lastTimeDamaged = Time.time;
        }
        
    }


}
