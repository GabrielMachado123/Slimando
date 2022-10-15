using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Bucket : MonoBehaviour
{
    List<GameObject> ZombiesToSpaw = new List<GameObject>();
    List<GameObject> ZombiesSpawned = new List<GameObject>();


    
    void Update()
    {
        
    }

    public void SpawnZombie(Vector2 position)
    {
        GameObject zombie = ZombiesToSpaw[0];

        zombie.transform.position = position;

        ZombiesToSpaw.Remove(zombie);

        ZombiesSpawned.Add(zombie);
    }

    public void CreateZombie(GameObject zombie)
    {
        ZombiesToSpaw.Add(zombie);
    }
    public void PutInBucketZombie(GameObject zombie)
    {
        ZombiesSpawned.Remove(zombie);
        ZombiesToSpaw.Add(zombie);
    }
}
