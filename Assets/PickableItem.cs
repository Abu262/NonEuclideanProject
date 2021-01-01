using System.Collections;
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
        rb = graphicsObject.GetComponent<Rigidbody>();
    }

    private void Start() 
    {
        rb.useGravity = false;
    }

    private void Update() 
    {
        rb.velocity = Vector3.zero;
    }
    
    public override void EnterPortalThreshold()
    {
        base.EnterPortalThreshold();
        if (graphicsClone && graphicsClone.GetComponent<Rigidbody>()) 
        {
            // Destroy(graphicsClone.GetComponent<Rigidbody>());
            Destroy(graphicsClone.GetComponent<BoxCollider>());
        }
    }
}
