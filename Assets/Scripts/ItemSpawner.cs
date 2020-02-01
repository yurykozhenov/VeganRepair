using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawner : MonoBehaviour
{
    public GameObject[] items;
    [Range(0, 8)] public int timeToSpawn;
    [Range(0, 8)] public int timeBeforeSpawn;
    public Transform spawnPoint;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Spawn", timeToSpawn, timeBeforeSpawn);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Spawn()
    {
        if (items.Length <= 0)
            return;
        int rand = Random.Range(0, items.Length);
        Instantiate(items[rand], spawnPoint.position, items[rand].transform.rotation);
    }
}
