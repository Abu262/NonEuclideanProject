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

        // print(distance);

        if (distance >= 2f && !isHolding)
        {
            isHolding = false;
            return;
        }

        if (isHolding) 
        {
            item.Rb.velocity = Vector3.zero;
            item.transform.localPosition = tempParent.transform.localPosition;

            if (Input.GetMouseButtonUp(0)) 
            {
                print("set isHolding to false");
                item.gameObject.transform.SetParent(null);
                isHolding = false;
            }
        }
        else if (!isHolding)
        {
            item.gameObject.transform.SetParent(null);
            if (Input.GetMouseButton(0)) 
            {
                item.gameObject.transform.SetParent(tempParent.transform);
                isHolding = true;
                item.transform.eulerAngles = Camera.main.transform.eulerAngles;
            }
        }
        item.graphicsObject.transform.localPosition = Vector3.zero;
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
