using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawner : MonoBehaviour
{
    public GameObject[] items;
    [Range(0, 8)] public float timeToSpawn;
    [Range(0, 20)] public float timeBetweenSpawning;
    public Transform spawnPoint;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Spawn", timeToSpawn, timeBetweenSpawning);
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
        Instantiate(items[rand], new Vector3(spawnPoint.position.x, spawnPoint.position.y, 0), items[rand].transform.rotation);
    }
}
