using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Script4 : Enemy_Script3
{
    [Header("Weapons")]
    public GameObject curveBullet;
    public GameObject bulletNoTarget;
    public GameObject fastTriangle;

    [Header("Constant Attack")]
    public int numbullet = 10;
    public float currRot = -90;
    public int currRotChange = 10;
    private int currRotSet = -90;
    private float rotAmount;
    private float bossLastAttack = 0;

    [Header("Sin Attack")]
    public int sinCoolDown = 1;
    private float lastSinAttack = 0f;

    [Header("Fast Triangles")]
    public int numTriBullets = 5;
    public float triangleCoolDown = 2;
    public float circleRad = 2;
    private float lastTriAttack = 0f;
    public float currRotTri = -90;
    private float currTriChange;

    void Start()
    {
        rotAmount = 360 / numbullet;
        currTriChange = 360 / numTriBullets;
    }
    void Update()
    {
        //ATTACKS
        //Constant Bullet Hell
        if(bossLastAttack + cooldown < Time.time)
        {
            for (int i = 0; i < numbullet; i++)
            {
                fire(Quaternion.Euler(0, 0, currRot), bulletNoTarget);
                currRot += rotAmount;
            }
            bossLastAttack = Time.time;
            currRotSet += currRotChange;
            currRot = currRotSet;
        }

        /*
        //Sin attack
        if (lastSinAttack + sinCoolDown < Time.time)
        {
            fire(curveBullet);
            lastSinAttack = Time.time;
        }
        */

        //Triangle Circle
        if(lastTriAttack + triangleCoolDown < Time.time)
        {
            for(int i=0; i<numTriBullets; i++)
            {
                fire(new Vector3(circleRad * Mathf.Cos(currRotTri), circleRad * Mathf.Sin(currRotTri), 0) + transform.position, fastTriangle);
                currRotTri += currTriChange;
                Debug.Log(currRotTri);
                lastTriAttack = Time.time;
            }
        }


        //Basic stuff
        death();
        if (transform.position.y > 4.2)
        {
            down();
        }
        else
        {
            sideToSideBoss();
        }
    }

    public void sideToSideBoss()
    {
        //Changes the direction of the enemy when it reaches a certain x world point
        if (transform.position.x < -4 || transform.position.x > 4)
        {
            speed *= -1;
        }
        //Makes the enemy go to the left or right, and down
        gameObject.transform.position += Vector3.left * (speed / 10);
    }




    //Only works with non-targetting bullets, is able to set the bullets direction
    public void fire(Quaternion rot, GameObject bullet)
    {
        Instantiate(bullet, this.gameObject.transform.position, rot);
    }

    public void fire(Vector3 pos, GameObject bullet)
    {
        Instantiate(bullet, pos, Quaternion.identity);
    }
}
