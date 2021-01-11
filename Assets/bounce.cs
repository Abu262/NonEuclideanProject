using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bounce : MonoBehaviour
{
    float initialPos;
    public bool flip;
    public Vector3 bounceAxis = new Vector3(0,0,1);
    Vector3 baseAxis;
    // Start is called before the first frame update
    void Start()
    {
        baseAxis = new Vector3(1, 1, 1) - bounceAxis;
        initialPos = Vector3.Dot(transform.localPosition,bounceAxis);
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 newPos = new Vector3(transform.localPosition.x * baseAxis.x, transform.localPosition.y * baseAxis.y, transform.localPosition.z * baseAxis.z);
        //transform.Rotate(Vector3.forward * Time.deltaTime * 60);
        if (flip)
        {
            

            transform.localPosition = newPos + (initialPos + Mathf.Cos(Time.time) / 20) * bounceAxis;
//            transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y, initialPos + Mathf.Cos(Time.time) / 20);
        }
        else
        {
            transform.localPosition = newPos + (initialPos - Mathf.Cos(Time.time) / 20) * bounceAxis;
            //            transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y, initialPos - Mathf.Cos(Time.time) / 20);
        }

    }
}
