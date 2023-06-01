using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Script3 : Enemy_Script
{
    public GameObject badBullet;
    public GameObject feline;
    public float cooldown = 1;
    private float lastAttack = 0;

    //Finds the food and the feline object
    void Start()
    {
        feline = GameObject.Find("Feline");
        food = GameObject.Find("Food");
    }

    //Moves the enemy down and side to side, and fires a bullet whenever it can
    void Update()
    {
        sideToSide();
        down();
        if(lastAttack + cooldown < Time.time)
        {
            fire(badBullet);
            lastAttack = Time.time;
        }
        death();
    }

    //Creates the fire method, you pass in a gameobject and it creates it at this position and with rotation 0,0,0
    public void fire(GameObject bullet)
    {
        Instantiate(bullet, gameObject.transform.position, new Quaternion(0, 0, 0, 0));
    }
}
