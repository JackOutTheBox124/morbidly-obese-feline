using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Feline_Attack : MonoBehaviour
{
    public GameObject heartBurn;

    // between 0 and 160
    private float _bloodSugar = 160;
    // between 0 and 100 - displayed to user? maybe just display by dividing base _bloodSugar lol
    public float bloodSugar = 100;
    Vector3 laserOffset = new Vector3(0f, 6.5f, 0f);

    // Start is called before the first frame update
    void Start()
    {
        heartBurn = GameObject.FindWithTag("HeartBurn");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space) && _bloodSugar > 0)
        {
            Vector2 felinePos = new Vector2(gameObject.transform.position.x, gameObject.transform.position.y);
            Quaternion rotation = Quaternion.Euler(0, 0, 0);

            // Instantiate(heartBurn, leftPos, rotation);

            GameObject megaLaser = Instantiate(heartBurn, transform.position + laserOffset, Quaternion.identity);
            megaLaser.transform.parent = transform;
            Destroy(megaLaser, .05f);
            _bloodSugar--;
            bloodSugar = _bloodSugar / 1.6f;

        }

    }
}
