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

    private int Max = 250;

    private Bucket bucket;

    public Transform[] spawnAreas;

    private float wraithSpawnRate = 10;
    private int wraithSpawnAmount = 5;

    private float timer2 = 0;

    private float FireSkullSpawnRate = 20;
    private int FireSkullSpawnAmount = 5;

    private float timer3 = 0;

    private float MummySpawnRate = 40;
    private int MummySpawnAmount = 1;

    private float timer4 = 0;

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
            timer4 += Time.deltaTime;

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

            if (timer4 > MummySpawnRate)
            {
                for (int i = 0; i < MummySpawnAmount; i++)
                {
                    if (bucket.MummyToSpawn.Count != 0)
                    {
                        bucket.SpawnMummy(RandomSpawnLocation());
                    }
                }
                timer4 = 0;
            }

        }
        else
        {
            timeOffset += timeOffset;
            //zombie
            if(zombieSpawnAmount < Max)
            {
                zombieSpawnAmount += 5;
            }
            else
            {
                zombieSpawnAmount = Max;
            }

            if(zombieSpawnRate > 1f)
            {
                zombieSpawnRate -= 0.1f;
            }

            //wraith
            if (wraithSpawnAmount < Max)
            {
                wraithSpawnAmount += 1;
            }
            else
            {
                wraithSpawnAmount = Max;
            }

            if (wraithSpawnRate > 1f)
            {
                wraithSpawnRate -= 0.05f;
            }

            //skull

            if (FireSkullSpawnAmount < Max)
            {
                FireSkullSpawnAmount += 1;
            }
            else
            {
                FireSkullSpawnAmount = Max;
            }

            if (FireSkullSpawnRate > 1f)
            {
                FireSkullSpawnRate -= 0.05f;
            }

            //mummy
            if (MummySpawnAmount < Max)
            {
                MummySpawnAmount += 1;
            }
            else
            {
                MummySpawnAmount = Max;
            }

            if (MummySpawnRate > 1f)
            {
                MummySpawnRate -= 5f;
            }

        }
       
    }
}
