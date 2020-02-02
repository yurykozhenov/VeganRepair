using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slot : MonoBehaviour
{
    public string bodyName;
    public bool connected = false;
    public GameObject body;
    private bool moving = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (connected && moving)
        {
            transform.position = Vector2.MoveTowards(transform.position, body.transform.position, 1f * Time.deltaTime);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject == body.gameObject)
        {
            moving = false;
        }
    }
}
