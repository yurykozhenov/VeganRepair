using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Client : MonoBehaviour
{
    private bool good;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("MovableByConveyor"))
        {
            good = true;
        }
            if (collision.CompareTag("Body"))
        {
            good = false;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Body"))
        {
            good = false;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Body"))
        {
            good = false;
        }

        if (collision.CompareTag("MovableByConveyor"))
        {
            if (good)
            {
                Debug.Log("Good shavyha!");
                LevelManager.instance.score += 1;
            }
            else
            {
                Debug.Log("Khe Khe");
                LevelManager.instance.score -= 2;
            }
            Destroy(collision.gameObject);
        }
    }
}
