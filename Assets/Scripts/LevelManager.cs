using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public GameObject body;
    public float rotatingSpeed = 30f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //body.transform.Rotate(Time.deltaTime * rotatingSpeed * Vector3.forward);
    }
}
