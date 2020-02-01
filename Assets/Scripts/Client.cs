using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Client : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Body"))
        {
            Debug.Log("Khe Khe");
        }

        if (collision.CompareTag("MovableByConveyor"))
        {
            Destroy(collision.gameObject);
        }
    }
}
