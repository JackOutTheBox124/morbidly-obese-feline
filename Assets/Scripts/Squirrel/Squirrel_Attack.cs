using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Squirrel_Attack : MonoBehaviour
{
    public GameObject moltenAcorn;
    private float _attackCooldown = .15f;
    private float lastAttack = 0;
    private bool attackSideIsLeft = false;

    public void setCooldown(float cool)
    {
        _attackCooldown = cool;
    }
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
                
                Vector2 leftPos = new Vector2(gameObject.transform.position.x - 0.25f, gameObject.transform.position.y);
                Vector2 rightPos = new Vector2(gameObject.transform.position.x + 0.25f, gameObject.transform.position.y);

                Quaternion rotation = Quaternion.Euler(0, 0, 0);
                if(attackSideIsLeft) {
                    Instantiate(moltenAcorn, leftPos, rotation);
                    attackSideIsLeft = false;
                }
                else {
                    Instantiate(moltenAcorn, rightPos, rotation);
                    attackSideIsLeft = true;
                }
                
            }

        }
    }


}
