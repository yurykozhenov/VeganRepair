using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElementLogic : MonoBehaviour
{
    private float startPosX;
    private float startPosY;
    private bool isBeingHeld = false;

    public bool onPoint = false;
    private Vector2 point;
    private GameObject body;
    // Start is called before the first frame update
    void Start()
    {
        point = Vector2.zero;
    }

    // Update is called once per frame
    void Update()
    {
        if (onPoint)
        {
            transform.SetParent(body.transform);
        }

        if (isBeingHeld)
        {
            Vector3 mousePos;
            mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.localPosition = new Vector2(mousePos.x - startPosX, mousePos.y - startPosY);
        }
    }

    private void OnMouseDown()
    {
        if (Input.GetMouseButtonDown(0))
        {
            transform.SetParent(null);
            Vector3 mousePos;
            mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            startPosX = mousePos.x - transform.localPosition.x; //- transform.parent.transform.position.x;
            startPosY = mousePos.y - transform.localPosition.y;  //- transform.parent.transform.position.y;

            isBeingHeld = true;
        }

    }

    private void OnMouseUp()
    {
        GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
        isBeingHeld = false;
    }

    private void OnCollisionStay2D(Collision2D collision)
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //else if(collision.tag == "BodyPoint")
        //{
        //    if (onPoint || collision.GetComponent<BodyPoint>().isTriggered)
        //    {
        //        return;
        //    }
        //    onPoint = true;
        //    point = collision.transform;
        //    collision.GetComponent<BodyPoint>().Triggered();
        //    moving = false;
        //}
        //else if (collision.tag == "Body")
        //{
        //    if (onPoint)
        //    {
        //        return;
        //    }
        //    onPoint = true;
        //    point = collision.transform;
        //    moving = false;
        //}
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //if (collision.gameObject.tag == "Body" && collision.gameObject.GetComponent<ElementLogic>().onPoint && !collision.gameObject.GetComponent<ElementLogic>())
        //{
        //    if (onPoint)
        //    {
        //        return;
        //    }
        //    onPoint = true;
        //    moving = false;
        //    Vector2 hitPoint = collision.GetContact(0).point;
        //    point = hitPoint;
        //    body = collision.gameObject;
        //    Debug.Log(point);
        //    transform.position = hitPoint;
        //    GetComponent<Rigidbody2D>().gravityScale = 0f;
        //    GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
        //}
    }
}
