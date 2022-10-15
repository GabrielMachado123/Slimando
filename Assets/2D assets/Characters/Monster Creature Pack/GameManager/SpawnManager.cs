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
       

          
        }
       
    }
}
