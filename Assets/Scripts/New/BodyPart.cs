using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodyPart : MonoBehaviour {
    public bool isPined = false;
    public bool isDragging= false;

    private Animator anim;
    private Collider2D collider;

    public string typet;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        collider = GetComponent<Collider2D>();

    }

    // Update is called once per frame
    void Update()
    {
        moveWithMouse();
    }

    public void OnMouseDown()
    {
        if (isPined) return;

        transform.SetParent(null);
        isDragging = true;
    }

    public void OnMouseUp()
    {
        isDragging = false;
    }

    void moveWithMouse() {
        if (!isDragging) return;
        if (isPined) return;

        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = new Vector3(mousePosition.x, mousePosition.y, 0);
    }

    public void pin(GameObject cGameObject, GameObject deletePoint) {
        if (isDragging) return;
        if (isPined) return;

        transform.SetParent(cGameObject.transform);
        isPined = true;
        Destroy(deletePoint);
        transform.root.gameObject.GetComponent<Body>().addPart();
        startMoveAnim();
    }

    void startMoveAnim() {
        anim.SetTrigger("Move");
    }
}
