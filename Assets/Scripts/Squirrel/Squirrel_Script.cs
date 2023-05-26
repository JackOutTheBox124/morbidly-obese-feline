using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Squirrel_Script : MonoBehaviour
{

    public Rigidbody2D squirrelRigidbody;
    private int i = 0;
    private float grabTime = 0; 
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
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("PowerUp"))
        {
            i = 0;
            Destroy(other.gameObject);
            other.gameObject.GetComponent<Squirrel_Attack>().setCooldown(.001f);
            grabTime = Time.time;
            while (i != -1)
            {
                if (Time.time >= grabTime + 8f)
                {
                    other.gameObject.GetComponent<Squirrel_Attack>().setCooldown(.15f);
                    i = -1;
                }
            }

        }
    }
}
