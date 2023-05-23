using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Script3 : Enemy_Script
{
    public GameObject badBullet;
    public int numBullet = 1;
    public float cooldown = 1;
    private float lastAttack = 0;
    void Start()
    {

    }
    void Update()
    {
        sideToSide();
        fire();
    }

    public void fire()
    {
        if (lastAttack + cooldown < Time.time)
        {
            lastAttack = Time.time;
            Instantiate(badBullet);
        }
    }
}
