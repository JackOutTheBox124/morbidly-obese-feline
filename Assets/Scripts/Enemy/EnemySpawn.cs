using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    public ParticleSystem stars;

    [Header("Enemies")]
    public GameObject basicEnemy;
    public GameObject charger;
    public GameObject shooter;

    [Header("Spawner Settings")]
    public int basicSpawnRate = 5;
    private float basicLastSpawn= 0;

    [Header("")]
    public bool chargerSwarms = false;
    public int chargeSwamNum = 3;
    public int chargerSpawnRate = 5;
    private float chargeLastSpawn = 0;

    [Header("")]
    public int shooterSpawnRate = 5;
    private float shooterLastSpawn = 0;

    [Header("")]
    public bool canSpawn = false;

    [Header("Game Start Settings")]
    public float timerToStart = 5;


    void Start()
    {
        
    }
    void Update()
    {
        var main = stars.main;
        //Game Start
        if(timerToStart>1)
        {
            timerToStart -= Time.deltaTime * 2;
            main.simulationSpeed = timerToStart;
        }
        else
        {
            canSpawn = true;
        }


        if(canSpawn)
        {
            //Basic spawning
            if (basicLastSpawn + basicSpawnRate < Time.time)
            {
                basicLastSpawn = Time.time;
                Instantiate(basicEnemy, new Vector3(Random.Range(-8, 8), transform.position.y, 0), new Quaternion(0, 0, 0, 0));
            }

            //Charger Spawning
            if (chargeLastSpawn + chargerSpawnRate < Time.time)
            {
                chargeLastSpawn = Time.time;
                //Spawns a small swarm of charger enemies
                if (chargerSwarms)
                {
                    for (int i = 0; i < chargeSwamNum; i++)
                    {
                        Instantiate(charger, new Vector3(Random.Range(-8, 8), transform.position.y, 0), new Quaternion(0, 0, 0, 0));
                    }
                }
                //Spawns just one charger otherwise
                else
                {
                    Instantiate(charger, new Vector3(Random.Range(-8, 8), transform.position.y, 0), new Quaternion(0, 0, 0, 0));
                }
            }

            //Shooter Spawning
            if (shooterLastSpawn + shooterSpawnRate < Time.time)
            {
                shooterLastSpawn = Time.time;
                Instantiate(shooter, new Vector3(Random.Range(-8, 8), transform.position.y, 0), new Quaternion(0, 0, 0, 0));
            }
        }
    }
}
