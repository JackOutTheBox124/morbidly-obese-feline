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
    }
    void Update()
    {
        sideToSide();
        down();
        fire();
    }

    public void fire()
    {
        if (lastAttack + cooldown < Time.time)
        { 
            lastAttack = Time.time;
            Instantiate(badBullet, gameObject.transform.position, new Quaternion(0,0,0,0));
        }
    }
}
