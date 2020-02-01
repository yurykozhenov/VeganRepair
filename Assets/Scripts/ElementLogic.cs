using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElementLogic : MonoBehaviour
{
    private float startPosX;
    private float startPosY;
    private bool isBeingHeld = false;
    public string bodyName;

    public bool onPoint = false;
    private bool spawned = false;
    private GameObject slot;
    private List<GameObject> collisions = new List<GameObject>();

    void Update()
    {
        if (onPoint)
        {
            transform.position = slot.transform.position;
        }

        if (!isBeingHeld) return;
        
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.localPosition = new Vector2(mousePos.x - startPosX, mousePos.y - startPosY);
    }

    private void OnMouseDown()
    {
        if (onPoint) return;

        if (!spawned)
        {
            transform.SetParent(null);
            Vector3 mousePos;
            mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            startPosX = mousePos.x - transform.localPosition.x;
            startPosY = mousePos.y - transform.localPosition.y;

            isBeingHeld = true;
        }
       
    }

    private void OnMouseUp()
    {
        var rb = GetComponent<Rigidbody2D>();
        rb.bodyType = RigidbodyType2D.Dynamic;
        isBeingHeld = false;
        spawned = true;

        if (collisions.Count <= 0)
        {
            return;
        }

        var minDistance = Vector2.Distance(transform.position, collisions[0].transform.position);
        var minIndex = 0;
        for (int i = 1; i < collisions.Count; i++)
        {
            if (Vector2.Distance(transform.position, collisions[i].transform.position) < minDistance)
            {
                minIndex = i;
            }
        }
        slot = collisions[minIndex];


        if (slot.gameObject.GetComponent<Slot>().connected)
        {
            return;
        }
        else
        {
            onPoint = true;
            slot.gameObject.GetComponent<Slot>().connected = true;
            slot.gameObject.GetComponent<SpriteRenderer>().enabled = false;
            slot.gameObject.GetComponent<Collider2D>().enabled = false;
            GetComponent<Collider2D>().isTrigger = true;
            rb.bodyType = RigidbodyType2D.Kinematic;
            if(transform.childCount < 1 || slot.transform.parent.CompareTag("Body"))
            {
                return;
            }
            else
            {
                for (int i = 0; i < transform.childCount; i++)
                {
                    transform.GetChild(i).gameObject.SetActive(true);
                }
            }
            transform.rotation = slot.transform.rotation;
            //transform.localScale = slot.transform.localScale * 5;
            //fix parent...
            if(transform.childCount < 1 || slot.transform.parent.CompareTag("Body"))
            {
                return;
            }
            else
            {
                for(int i = 0; i < transform.childCount; i++)
                {
                    transform.GetChild(i).gameObject.SetActive(true);
                }
            }
        }

        if (slot.gameObject.GetComponent<Slot>().bodyName.ToLower() == bodyName.ToLower())
        {
            Debug.Log("You Rock");
        }
        else
        {
            Debug.Log("You LOX");
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Slot"))
        {
            collisions.Add(collision.gameObject);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Slot"))
        {
            collisions.Remove(collision.gameObject);
        }
    }
}
