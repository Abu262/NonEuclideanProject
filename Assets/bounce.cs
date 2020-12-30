using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bounce : MonoBehaviour
{
    float initialPos;
    public bool flip;
    // Start is called before the first frame update
    void Start()
    {
        initialPos = transform.localPosition.z;
    }

    // Update is called once per frame
    void Update()
    {
        //transform.Rotate(Vector3.forward * Time.deltaTime * 60);
        if (flip)
        {
            transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y, initialPos + Mathf.Cos(Time.time) / 20);
        }
        else
        {
            transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y, initialPos - Mathf.Cos(Time.time) / 20);
        }

    }
}
