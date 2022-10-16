using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Bucket : MonoBehaviour
{
    public List<GameObject> ZombiesToSpaw = new List<GameObject>();
    public List<GameObject> ZombiesSpawned = new List<GameObject>();

    public List <GameObject> WraithToSpawn = new List<GameObject>();
    public List<GameObject> WraithSpanwed = new List<GameObject>();

    public List<GameObject> FireSkullToSpawn = new List<GameObject>();
    public List<GameObject> FireSkullSpawned = new List<GameObject>();

    public GameObject ZombiePrefab;

    public GameObject WraithPrefab;

    public GameObject FireSkullPrefab;
    void Start()
    {
        for (int i = 0; i < 1000; i++)
        {
            CreateZombie();
            CreateWraith();
            CreateFireSkull();
        }

  
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

    public void CreateWraith()
    {
        GameObject wraith = Instantiate(WraithPrefab, new Vector3(5000, 5000, 5000), Quaternion.identity);
        WraithToSpawn.Add(wraith);
        wraith.SetActive(false);
    }

    public void PutInBucketWraith(GameObject wraith)
    {
        WraithSpanwed.Remove(wraith);
        WraithToSpawn.Add(wraith);
    }

    public void SpawnWraith(Vector3 position)
    {
        GameObject wraith = WraithToSpawn[0];
        wraith.transform.position = position;
        WraithToSpawn.Remove(wraith);
        WraithSpanwed.Add(wraith);
        wraith.SetActive(true);

    }


    public void CreateFireSkull()
    {
        GameObject skull = Instantiate(FireSkullPrefab, new Vector3(5000, 5000, 5000), Quaternion.identity);
        FireSkullToSpawn.Add(skull);
        skull.SetActive(false);
    }

    public void PutInBucketFireSkull(GameObject skull)
    {
        FireSkullSpawned.Remove(skull);
        FireSkullToSpawn.Add(skull);
    }

    public void SpawnFireSkull(Vector3 position)
    {
        GameObject skull = FireSkullToSpawn[0];
        skull.transform.position = position;
        FireSkullToSpawn.Remove(skull);
        FireSkullSpawned.Add(skull);
        skull.SetActive(true);

    }
}
