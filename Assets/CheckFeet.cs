using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckFeet : MonoBehaviour
{
    //[HideInInspector]
    public bool feet;
    public Rigidbody rb;

    [HideInInspector]
    public Vector3 feetVel;

    [HideInInspector]
    public float feetScale;

    [HideInInspector]
    public bool onPlatform = false;
    private bool readytoswitch = false;
    float objectCount = 0;
    BasicMovingPlatform BMP;
    public Vector3 feetDir;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (readytoswitch && gameObject.GetComponentInParent<SimplePlayerControls>().inPortal == false && (BMP == null || BMP.inPortal == false))
        {
            //if (BMP == null)
            //{
            onPlatform = false;
            readytoswitch = false;
            BMP = null;

            //}
            //else if (BMP.inPortal == false)
            //{
//                onPlatform = false;
  //              readytoswitch = false;
            //}
            //if (BMP == null || BMP.inPortal == false)
            //{

              //  BMP = null;
            //}

        }
    }

    private void OnTriggerStay(Collider other)
    {
        feet = true;
        if (other.transform.tag == "Moving Platform" || other.transform.tag == "ZBlock")
        {
            BMP = other.GetComponentInParent<BasicMovingPlatform>();
            onPlatform = true;
            //            gameObject.transform.parent.SetParent(other.transform.parent.transform);
            //
            //Debug.Log(other.transform.parent.GetComponent<BasicMovingPlatform>().rb.velocity);
            //Quaternion.Inverse(other.transform.parent.rotation) * 

            //Quaternion.Inverse(other.transform.parent.rotation) *  
            //if (!other.name.Contains("Clone"))
            //{
//            Debug.Log(other.name);

            if (other.transform.tag == "Moving Platform")
            {
                Quaternion newGrav = Quaternion.FromToRotation(new Vector3(0f, -9.8f, 0f).normalized, Physics.gravity.normalized);
                Vector3 defVel = Quaternion.Inverse(other.transform.parent.rotation) * other.transform.parent.GetComponent<BasicMovingPlatform>().rb.velocity;
                //Debug.Log(Quaternion.Inverse(other.transform.rotation) * other.transform.parent.GetComponent<BasicMovingPlatform>().rb.velocity);
                feetScale = Vector3.Dot(other.transform.parent.GetComponent<BasicMovingPlatform>().rb.velocity, new Vector3(1, 1, 1));
                feetDir = (other.transform.parent.GetComponent<BasicMovingPlatform>().rb.velocity).normalized;
                if (Vector3.Dot(other.transform.parent.GetComponent<BasicMovingPlatform>().rb.velocity, Physics.gravity) == 0)
                {
                    feetVel = other.transform.parent.GetComponent<BasicMovingPlatform>().rb.velocity;
                    //feetScale = other.transform.parent.GetComponent<BasicMovingPlatform>().rb.velocity
                }
            }
            else if (other.transform.tag == "ZBlock")
            {
                Quaternion newGrav = Quaternion.FromToRotation(new Vector3(0f, -9.8f, 0f).normalized, Physics.gravity.normalized);
                Vector3 defVel = Quaternion.Inverse(other.transform.parent.rotation) * other.transform.parent.GetComponent<SlideZ>().rb.velocity;
                //Debug.Log(Quaternion.Inverse(other.transform.rotation) * other.transform.parent.GetComponent<BasicMovingPlatform>().rb.velocity);
                feetScale = Vector3.Dot(other.transform.parent.GetComponent<SlideZ>().rb.velocity, new Vector3(1, 1, 1));
                feetDir = (other.transform.parent.GetComponent<SlideZ>().rb.velocity).normalized;
                Debug.Log(other.transform.parent.GetComponent<SlideZ>().rb.velocity);
                if (Vector3.Dot(other.transform.parent.GetComponent<SlideZ>().rb.velocity, Physics.gravity) == 0)
                {
                    
                        feetVel = other.transform.parent.GetComponent<SlideZ>().rb.velocity;


                    //feetScale = other.transform.parent.GetComponent<BasicMovingPlatform>().rb.velocity
                }
            }
            //else
            //{
            //    feetVel = Vector3.zero;
            //}

            //                feetVel = other.transform.rotation * other.transform.parent.GetComponent<BasicMovingPlatform>().rb.velocity;
            //}
            //else
            //{

            //}

            //Debug.Log(other.name);
            //Debug.Log(rb.velocity);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        //if (other.transform.tag == "Moving Platform")
        //{

        //    other.transform.parent = transform.parent.parent;

        //}
    }

    private void OnTriggerExit(Collider other)
    {
        readytoswitch = true;

        feet = false;
        feetVel = Vector3.zero;
        //if (other.transform.tag == "Moving Platform")
        //{

        //    other.transform.parent = null;
        //}
    }
}
