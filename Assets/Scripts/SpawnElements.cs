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
        int rand = 0;

        for (int i = 0; i < points.Length; i++) {
            rand = Random.Range(0, templates.items.Length + 1);
            if (rand >= templates.items.Length)
            {
                Destroy(points[i].gameObject);
                continue;
            }
            else
            {
                GameObject item = Instantiate(templates.items[rand], points[i].position, templates.items[rand].transform.rotation);
                item.transform.SetParent(this.transform);
                item.transform.localScale = new Vector2(1.1f, 1.1f); ;
            }
            Destroy(points[i].gameObject);

        }
    }
}
