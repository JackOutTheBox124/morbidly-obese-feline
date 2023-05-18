using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Squirrel_Attack : MonoBehaviour
{
    public GameObject moltenAcorn;
    private float _attackCooldown = .15f;
    private float lastAttack = 0;

    // private int attackSpeed;
    // Start is called before the first frame update
    void Start()
    {
        moltenAcorn = GameObject.FindWithTag("MoltenAcorn");
    }

    // Update is called once per frame
    void Update()
    {
        if(lastAttack + _attackCooldown < Time.time)
        {
            if (Input.GetKey(KeyCode.Mouse0))
            {
                lastAttack = Time.time;

                Vector2 myPos = new Vector2(gameObject.transform.position.x, gameObject.transform.position.y);

                Quaternion rotation = Quaternion.Euler(0, 0, 0);

                Instantiate(moltenAcorn, myPos, rotation);
            }

        }
    }


}
