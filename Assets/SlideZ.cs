using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlideZ : MonoBehaviour
{
    
    public float Dir = 0;
    Rigidbody rb;

    public Transform Orientation;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Physics.IgnoreCollision(this.GetComponent<BoxCollider>(),Orientation.GetComponent<BoxCollider>());
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = Orientation.forward * Dir; 
    }
}
