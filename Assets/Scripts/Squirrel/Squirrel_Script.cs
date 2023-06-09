using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Squirrel_Script : MonoBehaviour
{

    public Rigidbody2D squirrelRigidbody;
    private float grabTime = 0;
    public int powerTime = 5;
    public float powerUpSpeed = 0.1f;
    // Start is called before the first frame update
    void Start()
    {
        //Keeps the squirrel from being jittery and makes it look nicer
        QualitySettings.vSyncCount = 1;
        Application.targetFrameRate = 60;
        Cursor.visible = false;
        squirrelRigidbody = GetComponent<Rigidbody2D>();
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z += Camera.main.nearClipPlane;
    }
    // Update is called once per frame
    //places the squrriel at the mouses location
    void Update()
    {
        squirrelRigidbody.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        if(grabTime + powerTime < Time.time)
        {
            this.gameObject.GetComponent<Squirrel_Attack>()._attackCooldown = 0.15f;
        }
    }

    //if you touch a powerup, it increases the firerate
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("PowerUp"))
        {
            this.gameObject.GetComponent<Squirrel_Attack>()._attackCooldown = powerUpSpeed;
            Destroy(other.gameObject);
            grabTime = Time.time;
        }
    }
}
