using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    private float zombieSpawnRate = 5;
    private int zombieSpawnAmount = 5;

    private float GameTimer = 0f;
    private int timeOffset = 15;

    private float timer = 0;

    private int MaxZombies = 250;

    private Bucket bucket;

    public Transform[] spawnAreas;

    private float wraithSpawnRate = 10;
    private int wraithSpawnAmount = 5;

    private int MaxWraith = 250;
    private float timer2 = 0;


    private float FireSkullSpawnRate = 15;
    private int FireSkullSpawnAmount = 1;


    private int MaxSkull = 250;
    private float timer3 = 0;

    public Vector3 RandomSpawnLocation()
    {
        return spawnAreas[Random.Range(0, spawnAreas.Length - 1)].transform.position;  
    }

    private void Start()
    {
        bucket = gameObject.GetComponent<Bucket>();
    }


    void Update()
    {
        if(GameTimer < timeOffset)
        {
            GameTimer += Time.deltaTime;
            timer += Time.deltaTime;
            timer2 += Time.deltaTime;
            timer3 += Time.deltaTime;

            if(timer > zombieSpawnRate)
            {
                for(int i = 0; i < zombieSpawnAmount; i++)
                {
                    if(bucket.ZombiesToSpaw.Count != 0)
                    {
                        bucket.SpawnZombie(RandomSpawnLocation());
                    }
                }
                timer = 0;
            }


            if (timer2 > wraithSpawnRate)
            {
                for (int i = 0; i < wraithSpawnAmount; i++)
                {
                    if (bucket.WraithToSpawn.Count != 0)
                    {
                        bucket.SpawnWraith(RandomSpawnLocation());
                    }
                }
                timer2 = 0;
            }

            if (timer3 > FireSkullSpawnRate)
            {
                for (int i = 0; i < FireSkullSpawnAmount; i++)
                {
                    if (bucket.FireSkullToSpawn.Count != 0)
                    {
                        bucket.SpawnFireSkull(RandomSpawnLocation());
                    }
                }
                timer3 = 0;
            }

        }
        else
        {
            timeOffset += timeOffset;

            if(zombieSpawnAmount < MaxZombies)
            {
                zombieSpawnAmount += 5;
            }
            else
            {
                zombieSpawnAmount = MaxZombies;
            }

            if(zombieSpawnRate > 1f)
            {
                zombieSpawnRate -= 0.1f;
            }


            if (wraithSpawnAmount < MaxWraith)
            {
                wraithSpawnAmount += 1;
            }
            else
            {
                wraithSpawnAmount = MaxWraith;
            }

            if (wraithSpawnRate > 1f)
            {
                wraithSpawnRate -= 0.05f;
            }



            if (FireSkullSpawnAmount < MaxSkull)
            {
                FireSkullSpawnAmount += 1;
            }
            else
            {
                FireSkullSpawnAmount = MaxSkull;
            }

            if (FireSkullSpawnRate > 1f)
            {
                FireSkullSpawnRate -= 0.05f;
            }

        }
       
    }
}
