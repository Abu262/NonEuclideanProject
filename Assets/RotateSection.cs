using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateSection : MonoBehaviour
{
    //[HideInInspector]
    public int Dir = 1;
    Vector3 to = new Vector3(0, 0, 0);
    public Transform T;
    //public RotationCenterPoint RCP;
    public Vector3 Axis;
    private float degrees = 90;
    private float axisCount = 0;
    //Vector3 to = new Vector3(0, 0, 0);
    //Vector3 initial = (0, 0, 0);
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        T.transform.rotation = Quaternion.RotateTowards(T.transform.rotation, Quaternion.Euler(to.x, to.y, to.z), 2);
        transform.localRotation = Quaternion.RotateTowards(transform.localRotation,Quaternion.Euler(0,axisCount * degrees,0), 2);
    }

    public void RotateChildren()
    {
        //degrees = (degrees + 90) % 360;
        //Debug.Log(degrees);
        //Vector3 baseAxis = new Vector3(1, 1, 1) - Axis;
        //to = new Vector3(baseAxis)
        //baseAxis = new Vector3(baseAxis.x * T.rotation.eulerAngles.x, baseAxis.y * T.rotation.eulerAngles.y, baseAxis.z * T.rotation.eulerAngles.z);
        to += Axis * degrees * Dir;
        axisCount += 1;
        Debug.Log(to);
        
        //to = T.rotation.eulerAngles + Axis * degrees;// new Vector3(degrees, 0, 0);

    }

}
