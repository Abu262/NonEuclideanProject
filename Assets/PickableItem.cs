﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// [RequireComponent(typeof(Rigidbody))]
public class PickableItem : PortalTraveller
{
    private Rigidbody rb;
    public Rigidbody Rb => rb;
    public bool isGrabbed;

    private void Awake() 
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Start() 
    {
        rb.useGravity = false;
    }

    private void Update() 
    {
        rb.velocity = Vector3.zero;
    }

    
}
