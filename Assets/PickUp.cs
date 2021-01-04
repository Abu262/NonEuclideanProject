using UnityEngine;

public class PickUp : MonoBehaviour
{
    float throwForce = 600;
    Vector3 objectPos;
    float distance;

    public bool canHold = true;
    public PickableItem item;
    public GameObject tempParent;
    public bool isHolding = false;

    void Start() 
    {
        isHolding = false;
    }

    void Update() 
    {
        distance = Vector3.Distance(item.gameObject.transform.position, tempParent.transform.position);

        if (distance >= 2f)
        {
            isHolding = false;
        }

        if (isHolding) 
        {
            item.Rb.velocity = Vector3.zero;
            item.Rb.angularVelocity = Vector3.zero;
            // item.transform.localPosition = Vector3.zero;
            item.transform.localPosition = tempParent.transform.localPosition;
            // item.transform.position = Vector3.zero + new Vector3(0, 0 , 1.5f);

            // right mouse button to release
            if (Input.GetMouseButtonUp(0)) 
            {
                // item.Rb.AddForce(tempParent.transform.forward * throwForce);
                isHolding = false;
            }
        }
        else if (!isHolding)
        {
            // objectPos = item.transform.position;
            item.gameObject.transform.SetParent(null);
            // item.graphicsObject.transform.localPosition = item.gameObject.transform.position;
            if (Input.GetMouseButton(0)) 
            {
                item.gameObject.transform.SetParent(tempParent.transform);
                isHolding = true;
                // item.graphicsObject.transform.eulerAngles = Camera.main.transform.eulerAngles;
                item.transform.eulerAngles = Camera.main.transform.eulerAngles;

                // item.transform.position = objectPos;
            }
        }
        item.graphicsObject.transform.localPosition = Vector3.zero;
        // print(item.graphicsObject.transform.position);
    }


    void MouseDown() 
    {
        if (distance > 2f)
            return;

        print("Down");

        isHolding = true;
        item.Rb.useGravity = false;
        item.Rb.detectCollisions = true;
    }


    void MouseUp() 
    {
        print("Up");
        isHolding = false;
    }
}
