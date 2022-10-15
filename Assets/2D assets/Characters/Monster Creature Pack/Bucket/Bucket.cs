using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Bucket : MonoBehaviour
{
    public List<GameObject> ZombiesToSpaw = new List<GameObject>();
    public List<GameObject> ZombiesSpawned = new List<GameObject>();


    public GameObject ZombiePrefab;

    void Start()
    {
        for (int i = 0; i < 1000; i++)
        {
            CreateZombie();
        }
    }
    void Update()
    {
        
    }

    public void SpawnZombie(Vector3 position)
    {
        GameObject zombie = ZombiesToSpaw[0];
        zombie.transform.position = position;
        ZombiesToSpaw.Remove(zombie);
        ZombiesSpawned.Add(zombie);
        zombie.SetActive(true);
       
    }

    public void CreateZombie()
    {
        GameObject zombie = Instantiate(ZombiePrefab,new Vector3(5000, 5000, 5000), Quaternion.identity);
        ZombiesToSpaw.Add(zombie);
        zombie.SetActive(false);
    }
    public void PutInBucketZombie(GameObject zombie)
    {
        ZombiesSpawned.Remove(zombie);
        ZombiesToSpaw.Add(zombie);
    }
}
