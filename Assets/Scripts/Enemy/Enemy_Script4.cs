using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Script4 : Enemy_Script3
{
    public GameObject curveBullet;
    public GameObject bulletNoTarget;

    private float bossLastAttack = 0;
    public int numbullet = 10;
    public float currRot = -90;
    private float rotAmount;
    private bool once = false;
    void Start()
    {
        rotAmount = 180 / numbullet;
        Debug.Log(rotAmount);
    }
    void Update()
    {
        //Attacks
        //Shotgun Attack
        if(!once)
        {
            for (int i = 0; i < numbullet+1; i++)
            {
                Debug.Log(currRot);
                fire(Quaternion.Euler(0, 0, currRot));
                currRot += rotAmount;
            }
            once = true;
        }

        //Sin attack
        if (bossLastAttack + cooldown < Time.time)
        {
            fire(curveBullet);
            bossLastAttack = Time.time;
        }


        //Basic stuff
        death();
        if(transform.position.y > 4.2)
        {
            down();
        }
        else
        {
            sideToSide();
        }
    }

    //Allows you to choose what bullet is being fired
    public void fire(GameObject bullet)
    {
        bossLastAttack = Time.time;
        Instantiate(bullet, gameObject.transform.position, new Quaternion(0, 0, 0, 0));
    }

    //Only works with non-targetting bullets, is able to set the bullets direction
    public void fire(Quaternion rot)
    {
        bossLastAttack = Time.time;
        Instantiate(bulletNoTarget, this.gameObject.transform.position, rot);
    }
}
