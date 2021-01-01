﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckFeet : MonoBehaviour
{
    //[HideInInspector]
    public bool feet;
    public Rigidbody rb;

    [HideInInspector]
    public Vector3 feetVel;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
        feet = true;
        if (other.transform.tag == "Moving Platform")
        {

            feetVel = other.transform.parent.GetComponent<BasicMovingPlatform>().rb.velocity;
            //Debug.Log(rb.velocity);
        }
    }
    private void OnTriggerEnter(Collider other)
    {

    }

    private void OnTriggerExit(Collider other)
    {
        feet = false;
        feetVel = Vector3.zero;
        //if (other.transform.tag == "Moving Platform")
        //{
        //    transform.parent.GetComponent<Rigidbody>().isKinematic = false;
        //    transform.parent.parent = null;
        //}
    }
}
