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

    void Update() 
    {
        // left mouse button
        // if (Input.GetMouseButtonDown(0)) 
        // {
        //     MouseDown();
        // }

        distance = Vector3.Distance(item.gameObject.transform.position, tempParent.transform.position);

        if (distance >= 2f)
        {
            isHolding = false;
        }

        if (isHolding) 
        {
            item.Rb.velocity = Vector3.zero;
            item.Rb.angularVelocity = Vector3.zero;
            
            item.graphicsObject.transform.localPosition = Vector3.zero;
            // right mouse button to release
            if (Input.GetMouseButtonDown(1)) 
            {
                // item.Rb.AddForce(tempParent.transform.forward * throwForce);
                isHolding = false;
            }
        }
        else if (!isHolding)
        {
            // objectPos = item.transform.position;
            item.gameObject.transform.SetParent(null);

            if (Input.GetMouseButtonDown(0)) 
            {
                item.gameObject.transform.SetParent(tempParent.transform);
                isHolding = true;
                item.graphicsObject.transform.eulerAngles = Vector3.zero;
                // item.graphicsObject.transform.localPosition = tempParent.transform.localPosition - new Vector3(0, 0, 3);

                // item.transform.position = objectPos;
            }
        }
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
