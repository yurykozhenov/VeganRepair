﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shaverma : MonoBehaviour
{
    private int swipes;
    public int needSwipes = 3;
    public GameObject wrappedShaverma;
    private bool spawned;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(swipes >= needSwipes && !spawned)
        {
            GameObject wrappedShav = Instantiate(wrappedShaverma, transform.position, transform.rotation);
            //wrappedShav.transform.SetParent(this.transform);
            Destroy(gameObject);
            spawned = true;
        }
    }

    private void OnMouseDown()
    {

        if(swipes < needSwipes)
        {
            swipes++;
        }
            
    }

    private void OnCollisionStay2D(Collision2D collision)
    {

    }

}
