using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Body : MonoBehaviour
{
    public string type;
    public bool readyToPin = false;

    private bool isFull = false;
    private bool isDragging= false;
    private int parts = 0; // Have to be == 5

    private bool canMove = false;
    public int speed = 3;

    void Update()
    {
        moveWithMouse();
        move();
    }

    void OnTriggerStay2D(Collider2D collision) {
        //Debug.Log("Trriger..." + gameObject.tag);
        if (collision.gameObject.CompareTag("_builderPlace")) {
            pin(collision.gameObject);
        }
    }

    public void OnMouseDown()
    {
        if (isFull) return;
        if (readyToPin) return;

        transform.SetParent(null);

        isDragging = true;
    }

    public void OnMouseUp()
    {
        isDragging = false;
    }

    void moveWithMouse() {
        if (isFull) return;
        if (!isDragging) return;
        if (readyToPin) return;

        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = new Vector3(mousePosition.x, mousePosition.y, 0);
    }

    public void pin(GameObject cGameObject) {
        if (isFull) return;
        if (isDragging) return;
        if (readyToPin) return;

        //transform.SetParent(cGameObject.transform);
        readyToPin = true;
    }

    public void addPart(){
        parts += 1;

        if (parts >= 5) {
            isFull = true;
            readyToPin = false;
            showCoins();
            moveOut();
        }
    }

    void showCoins(){
        GameObject.FindGameObjectWithTag("Coins").GetComponent<CointsControl>().show((int)Random.Range(1, 4));
        Debug.Log("Show Coins ...");
    }

    void moveOut() {
        canMove = true;
        // move out of the borders
        Debug.Log("Move Out ...");
    }

    void move()
    {
        if (canMove == false) return;

        transform.Translate(Vector3.left * Time.deltaTime * speed);

        Vector3 point = Camera.main.ScreenToWorldPoint(new Vector3(-2.2f, 0, 0));

        if (transform.position.x < point.x)
        {
            Destroy(gameObject);
        }
    }
}
