using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinObjScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    void OnTriggerStay2D(Collider2D collision) {
        //Debug.Log("Trriger..." + gameObject.tag);

        if (collision.gameObject.CompareTag("_body") && collision.gameObject.GetComponent<Body>().readyToPin ) {
            transform.parent.gameObject.GetComponent<BodyPart>().pin(collision.gameObject, gameObject);
        } else if (collision.gameObject.CompareTag("_bodyPart") && collision.gameObject.GetComponent<BodyPart>().isPined) {
            if (!collision.gameObject.transform.root.gameObject.GetComponent<Body>().readyToPin) return;

            transform.parent.gameObject.GetComponent<BodyPart>().pin(collision.gameObject, gameObject);

        }
    }
}
