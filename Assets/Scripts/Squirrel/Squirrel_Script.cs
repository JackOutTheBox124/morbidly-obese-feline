using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Squirrel_Script : MonoBehaviour
{

    public Rigidbody2D squirrelRigidbody;
    private float grabTime = 0;
    public int powerTime = 5;
    // Start is called before the first frame update
    void Start()
    {
        QualitySettings.vSyncCount = 1;
        Application.targetFrameRate = 60;
        Cursor.visible = false;
        squirrelRigidbody = GetComponent<Rigidbody2D>();
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z += Camera.main.nearClipPlane;
    }
    // Update is called once per frame
    void Update()
    {
        squirrelRigidbody.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        if(grabTime + powerTime < Time.time)
        {
            this.gameObject.GetComponent<Squirrel_Attack>()._attackCooldown = 0.15f;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("PowerUp"))
        {
            this.gameObject.GetComponent<Squirrel_Attack>()._attackCooldown = 0.001f;
            Destroy(other.gameObject);
            grabTime = Time.time;
        }
    }
}
