﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicMovingPlatform : PortalTraveller
{
    float speed = 90f;
    Vector3 initialPos;
    public float distance;
    public Vector3 Direction = new Vector3(0,0,1);
    bool flip;
    [HideInInspector]
    public Rigidbody rb;
    public Transform Orientation;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        initialPos = transform.localPosition;
        Physics.IgnoreCollision(this.GetComponent<BoxCollider>(), Orientation.GetComponent<BoxCollider>());
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Debug.Log(transform.localPosition.magnitude - initialPos.magnitude);
        if (Mathf.Abs(transform.localPosition.magnitude - initialPos.magnitude) >= distance)
        {
            flip = true;
        }
        else if (transform.localPosition.magnitude - initialPos.magnitude <= 0)
        {
            flip = false;
        }

        if (flip == false)
        {
            
            rb.velocity = Orientation.rotation * Direction * Time.fixedDeltaTime * speed;
        }
        else
        {
            rb.velocity = Orientation.rotation * -Direction * Time.fixedDeltaTime * speed;
        }
    }
}