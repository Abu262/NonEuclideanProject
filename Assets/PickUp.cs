using UnityEngine;

public class PickUp : PortalTraveller
{
    private Rigidbody rb;
    private bool hasTeleported;

    float throwForce = 600;
    Vector3 objectPos;
    float distance;

    public bool canHold = true;
    public GameObject tempParent;
    public bool isHolding = false;

    void Awake() 
    {
        rb = GetComponent<Rigidbody>();
    }

    void Start() 
    {
        rb.useGravity = false;
        isHolding = false;
    }

    void Update() 
    {
        rb.velocity = Vector3.zero;

        distance = Vector3.Distance(gameObject.transform.position, tempParent.transform.position);

        // print(distance);

        if (distance >= 2f && !isHolding)
        {
            isHolding = false;
            return;
        }

        if (isHolding) 
        {
            rb.velocity = Vector3.zero;
            transform.position = tempParent.transform.position;
            transform.eulerAngles = Camera.main.transform.eulerAngles;

            if (Input.GetMouseButtonUp(0)) 
            {
                print("set isHolding to false");
                // item.gameObject.transform.SetParent(null);
                isHolding = false;
            }
        }
        else if (!isHolding)
        {
            // item.gameObject.transform.SetParent(null);
            if (Input.GetMouseButton(0)) 
            {
                // item.gameObject.transform.SetParent(tempParent.transform);
                isHolding = true;
                
            }
        }
        // item.graphicsObject.transform.localPosition = Vector3.zero;
    }

    public override void Teleport(Transform fromPortal, Transform toPortal, Vector3 pos, Quaternion rot) 
    {
        if (!hasTeleported) 
        {
            transform.position = pos;
            transform.rotation = rot;
        }

        hasTeleported = true;
    }
}
