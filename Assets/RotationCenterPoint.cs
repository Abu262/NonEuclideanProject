using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationCenterPoint : MonoBehaviour
{
    //[HideInInspector]
    Vector3 to = new Vector3(0, 0, 0);
    //public Transform Orientation;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(to.x, to.y, to.z), 2);
        //transform.eulerAngles = Vector3.Lerp(transform.rotation.eulerAngles, to, Time.deltaTime);
    }
}
