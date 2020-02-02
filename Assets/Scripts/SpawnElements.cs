using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnElements : MonoBehaviour
{
    public Transform[] points;
    private Items templates;
    // Start is called before the first frame update
    void Start()
    {
        templates = GameObject.FindGameObjectWithTag("Spawner").GetComponent<Items>();

        Spawn();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Spawn()
    {
        int randAnimal = 0;
        int randPart = 0;
        int randVegetable = 0;
        randAnimal = Random.Range(0, templates.items.Length);

        for (int i = 0; i < points.Length; i++) {
            randPart = Random.Range(0, templates.items[randAnimal].GetComponent<Animal>().parts.Length + 3);

            if(randPart >= templates.other.Length)
            {
                randVegetable = Random.Range(0, templates.other.Length);
                GameObject item = Instantiate(
                    templates.other[randVegetable],
                    points[i].position,
                    templates.other[randVegetable].transform.rotation
                );
                item.transform.SetParent(this.transform);

            }
            else
            {
                GameObject item = Instantiate(
                    templates.items[randAnimal].GetComponent<Animal>().parts[randPart],
                    points[i].position,
                    templates.items[randAnimal].GetComponent<Animal>().parts[randPart].transform.rotation
                );
                item.transform.SetParent(this.transform);

            }

            Destroy(points[i].gameObject);

        }
    }
}
