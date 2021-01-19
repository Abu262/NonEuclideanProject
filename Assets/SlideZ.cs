using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlideZ : PortalTraveller
{

    float speed = 90f;
    Vector3 initialPos;
    public float distance;
    public Vector3 Direction = new Vector3(0, 0, 1);
    public bool flip;
    [HideInInspector]
    public Rigidbody rb;
    Rigidbody childRb;
    public Transform Orientation;

    float timeLeft;
    [HideInInspector]
    public bool inPortal;


    public FlagTrigger Front;
    public FlagTrigger Back;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        childRb = Orientation.gameObject.GetComponent<Rigidbody>();
        initialPos = transform.localPosition;
        Physics.IgnoreCollision(this.GetComponent<BoxCollider>(), Orientation.GetComponent<BoxCollider>());
        if ((transform.rotation * Direction).x == 0)
        {
            rb.constraints = rb.constraints | RigidbodyConstraints.FreezePositionX;
            childRb.constraints = childRb.constraints | RigidbodyConstraints.FreezePositionX;
        }
        if ((transform.rotation * Direction).y == 0)
        {
            rb.constraints = rb.constraints | RigidbodyConstraints.FreezePositionY;
            childRb.constraints = childRb.constraints | RigidbodyConstraints.FreezePositionY;
        }
        if ((transform.rotation * Direction).z == 0)
        {
            rb.constraints = rb.constraints | RigidbodyConstraints.FreezePositionZ;
            childRb.constraints = childRb.constraints | RigidbodyConstraints.FreezePositionZ;
        }
        rb.constraints = rb.constraints | RigidbodyConstraints.FreezeRotation;
    }
    private void Update()
    {
        timeLeft -= Time.deltaTime;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //Debug.Log(transform.localPosition.magnitude - initialPos.magnitude);
        //if (timeLeft <= 0)
        //{
        //    timeLeft = distance;
        //    flip = !flip;
        //}
        //else if (transform.localPosition.magnitude - initialPos.magnitude <= 0)
        //{
        //    flip = false;
        //}
        
        if (flip == false)
        {
            if  (Front.Flag == false)
            {
                rb.velocity = Orientation.rotation * Direction * Time.fixedDeltaTime * speed;
            }
            else
            {
                rb.velocity = Vector3.zero;
            }


        }
        else
        {
            if (Back.Flag == false)
            {
                rb.velocity = Orientation.rotation * -Direction * Time.fixedDeltaTime * speed;
            }
            else
            {
                rb.velocity = Vector3.zero;
            }


        }


        childRb.MovePosition(this.transform.position);
        childRb.MoveRotation(this.transform.rotation);


    }

    //private void OnCollisionStay(Collision collision)
    //{ 
    //    if (collision.gameObject.tag != "Player")
    //    {
    //        touchingNonPlayer = true;
    //    }
    //}
    //private void OnCollisionExit(Collision collision)
    //{
    //    if (collision.gameObject.tag != "Player")
    //    {
    //        touchingNonPlayer = false;
    //    }
    //}
}
