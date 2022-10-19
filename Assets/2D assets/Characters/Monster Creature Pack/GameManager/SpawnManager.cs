using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    private float zombieSpawnRate = 5;
    private int zombieSpawnAmount = 2;

    private float GameTimer = 0f;
    private int timeOffset = 15;

    private float timer = 0;

    private int Max = 250;

    private Bucket bucket;

    public Transform[] spawnAreas;

    private float wraithSpawnRate = 20;
    private int wraithSpawnAmount = 10;

    private float timer2 = 0;

    private float FireSkullSpawnRate = 20;
    private int FireSkullSpawnAmount = 5;

    private float timer3 = 0;

    private float MummySpawnRate = 20;
    private int MummySpawnAmount = 1;

    private float timer4 = 0;

    private float buffTime = 15;


    private bool wraithWave = false;
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
        GameTimer += Time.deltaTime;
        timer += Time.deltaTime;


        if (timer > zombieSpawnRate)
        {
            for (int i = 0; i < zombieSpawnAmount; i++)
            {
                if (bucket.ZombiesToSpaw.Count != 0)
                {
                    bucket.SpawnZombie(RandomSpawnLocation());
                }
            }
            timer = 0;

          if(GameTimer > buffTime)
            {
                if (zombieSpawnRate > 1)
                {
                    zombieSpawnRate -= 1f;
                }

                zombieSpawnAmount += 5;
            } 
        }


        if(GameTimer > 45)
        {
            if(!wraithWave)
            {
                for (int i = 0; i < 20; i++)
                {
                    if (bucket.WraithToSpawn.Count != 0)
                    {
                        bucket.SpawnWraith(RandomSpawnLocation());
                    }
                }

                wraithWave = true;
            }
            timer2 += Time.deltaTime;

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

                if (GameTimer > buffTime)
                {
                    if (wraithSpawnRate > 1)
                    {
                        wraithSpawnRate -= 1f;
                    }
                    wraithSpawnAmount += 5;
                }
            }
            if (GameTimer > 120)
            {
                timer3 += Time.deltaTime;

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

                    if (GameTimer > buffTime)
                    {
                        if (FireSkullSpawnRate > 1)
                        {
                            FireSkullSpawnRate -= 1f;
                        }
                        FireSkullSpawnAmount += 5;
                    }
                }

                if(GameTimer > 250)
                {
                    timer4 += Time.deltaTime;

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

                        if (GameTimer > buffTime)
                        {
                            if (MummySpawnRate > 1)
                            {
                                MummySpawnRate -= 1f;
                            }
                            MummySpawnAmount += 2;
                        }
                    }
                }
            }

        }


        if (GameTimer > buffTime)
        {
            buffTime += buffTime;
        }

        }
}
