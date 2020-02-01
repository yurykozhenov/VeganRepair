using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElementLogic : MonoBehaviour
{
    public float speed = 5f;
    private bool moving = false;
    private bool onPoint = false;
    private Transform point;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (moving)
        {
            Move();
        }
        else if (onPoint)
        {
            transform.position = point.position;
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Conveer")
        {
            moving = true;
        }
    }

    void Move()
    {
        transform.Translate(Vector2.right * Time.deltaTime * speed);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "End")
        {
            Destroy(gameObject);
        }
        else if(collision.tag == "BodyPoint")
        {
            if (onPoint || collision.GetComponent<BodyPoint>().isTriggered)
            {
                return;
            }
            onPoint = true;
            point = collision.transform;
            collision.GetComponent<BodyPoint>().Triggered();
            moving = false;
        }
    }
}
