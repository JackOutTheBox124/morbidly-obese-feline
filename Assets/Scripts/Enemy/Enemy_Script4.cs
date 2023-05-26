using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Script4 : Enemy_Script3
{
    void Start()
    {
        
    }
    void Update()
    {
        sideToSide();
        if(transform.position.y > 4.2)
        {
            down();
        }
    }
}
