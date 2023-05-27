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
        //badBullet = GameObject.FindWithTag("EnemyBullet");
        feline = GameObject.Find("Feline");
        food = GameObject.Find("Food");
    }
    void Update()
    {
        sideToSide();
        down();
        if(lastAttack + cooldown < Time.time)
        {
            fire();
            lastAttack = Time.time;
        }
        death();
    }

    public void fire()
    {
        Instantiate(badBullet, gameObject.transform.position, new Quaternion(0,0,0,0));
    }
}
