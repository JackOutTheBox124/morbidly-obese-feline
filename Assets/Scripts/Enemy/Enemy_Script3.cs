using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Script3 : Enemy_Script
{
    public GameObject badBullet;
    public GameObject feline;
    public float cooldown = 1;
    private float lastAttack = 0;
    void Start()
    {
        badBullet = GameObject.FindWithTag("EnemyBullet");
        feline = GameObject.Find("Feline");
        food = GameObject.Find("Food");
    }
    void Update()
    {
        sideToSide();
        down();
        fire();
        death();
    }

    public void fire()
    {
        if (lastAttack + cooldown < Time.time)
        { 
            lastAttack = Time.time;
            Instantiate(badBullet, gameObject.transform.position, new Quaternion(0,0,0,0));
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        //Kills the enemy when past the box collider or feline
        if (other.gameObject.CompareTag("PastKiller") || other.gameObject.CompareTag("Feline"))
        {
            Destroy(this.gameObject);
        }

        //DEATH BY ATTACKS
        //Normal attack damages enemy
        if (other.gameObject.CompareTag("MoltenAcorn"))
        {
            health--;
        }

        //HeartBurn attack kills enemy
        if (other.gameObject.CompareTag("HeartBurn"))
        {
            health = 0;
            death();
        }
    }
}
