using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Conveer : MonoBehaviour
{
    public float speed = 1f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    // private void OnCollisionStay2D(Collision2D collision)
    // {
    //     collision.gameObject.transform.Translate(Vector3.right * Time.deltaTime * speed);
    // }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("MovableByConveyor"))
        {
            collision.gameObject.transform.Translate(Vector3.right * (Time.deltaTime * speed));
        }
    }
}
