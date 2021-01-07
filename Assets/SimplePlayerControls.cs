using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SimplePlayerControls : PortalTraveller
{
    Rigidbody rb;
    public float moveSpeed = 20f;
    public float jumpForce = 100f;
    public CheckFeet cf;

    [Header("Rotation and Look")]
    private float xRotation;
    private float sensitivity = 100f;
    private float senMultiplier = 1f;


    [Header("Assingables")]
    public Transform playerCam;
    public Transform orientation;

    bool disabled;
    SceneHandler SM;

    [HideInInspector]
    public bool inPortal = false;
    // Start is called before the first frame update
    void Start()
    {
        SM = FindObjectOfType<SceneHandler>();
        rb = GetComponent<Rigidbody>();
        //playerScale = transform.localScale;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }


    private void Update()
    {
        if (Input.GetKeyDown (KeyCode.P)) {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            Debug.Break ();
        }
        if (Input.GetKeyDown (KeyCode.O)) {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
        if (disabled) {
            return;
        }
        Look();


    }


    void LateUpdate()
    {
        // Handle the movement
        

        // Handle Jumping
        HandleJump();

        Restart();
    }
    private void FixedUpdate()
    {
        HandleMovement();
    }

    private void Restart()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

    }

    void HandleMovement()
    {

        // Get the movement vector
        Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        //Debug.Log(Time.deltaTime);
        //move *= moveSpeed;// * Time.deltaTime;

        // Use ForceMode to make it smoother
        // Force is the default but you can also try
        // Acceleration & VelocityChange a bit more sharper movement
        // We must also ensure that we don't add force to exceed max velocity/speed    

        Vector3 baseVel = Quaternion.Inverse(transform.rotation) * rb.velocity;

        if (move == Vector3.zero)
        {
            Vector3 newVel = transform.rotation * new Vector3(baseVel.x, 0, baseVel.z);

            //rb.velocity = newVel;
            //rb.AddForce(-newVel, ForceMode.Force);
        }

        //var movementPlane = new Vector3(baseVel.x, 0, baseVel.z);
        //if (movementPlane.magnitude < moveSpeed)
        //{
            Vector3 curVel = (orientation.transform.forward * move.z * moveSpeed
                + orientation.transform.right * move.x * moveSpeed) * Time.fixedDeltaTime;    //rb.velocity;
            curVel += transform.rotation * new Vector3(0, baseVel.y, 0);


        //        Debug.Log(Quaternion.FromToRotation(new Vector3(0f, -9.8f, 0f).normalized, Physics.gravity.normalized) * (cf.feetVel));

        //Transform c = gameObject.transform.Find("Model(Clone)");



        //if in a portal and on a platform
        //ignore the platform rigidbody because it sucks
        //and match the velocity and keep it moving until we are out of the portal
        

        if ((inPortal == true && cf.onPlatform == false))
        {
            Debug.Log("PENIS");

            //          float scale = Mathf.Abs( Vector3.Dot(cf.feetVel, new Vector3(1, 1, 1)));
            //rb.useGravity = false;
            //rb.isKinematic = true;
            //            rb.velocity = cf.feetVel.normalized * scale;///Vector3.zero;
        }


        if ((inPortal == true && cf.onPlatform == true ))
        {
            
            curVel -= transform.rotation * new Vector3(0, baseVel.y, 0);


            rb.velocity = curVel;
            if ((transform.rotation * cf.feetDir).y != 0)
            {
                rb.velocity += transform.rotation * new Vector3(0, (cf.feetScale), 0);
            }
            else
            {
                rb.velocity = curVel + (cf.feetVel);
            }
            //          float scale = Mathf.Abs( Vector3.Dot(cf.feetVel, new Vector3(1, 1, 1)));
            rb.useGravity = false;
            Debug.Log(transform.rotation * new Vector3(0, (cf.feetScale), 0));
            //Debug.Log(transform.rotation * cf.feetDir);
            //rb.isKinematic = true;
            //            rb.velocity = cf.feetVel.normalized * scale;///Vector3.zero;
        }
        else
        {
            Debug.Log("GRAVITY IS ON");
            rb.useGravity = true;
            //rb.isKinematic = false;
            rb.velocity = curVel + (cf.feetVel);

        }

    //    float scale = Vector3.Dot(cf.feetVel, new Vector3(1, 1, 1));
    //    //curVel -= transform.rotation * new Vector3(0, baseVel.y, 0);
    //    rb.velocity = curVel;// + cf.feetDir;// * cf.feetScale;//transform.rotation * new Vector3(0, cf.feetScale, 0);
    //                         //          float scale = Mathf.Abs( Vector3.Dot(cf.feetVel, new Vector3(1, 1, 1)));
    //    if (cf.feetDir == Physics.gravity.normalized)
    //    {
    //        rb.velocity += transform.rotation * new Vector3(0, cf.feetScale, 0);
    //        rb.useGravity = true;
    //    }
    //    else
    //    {
    //        rb.useGravity = false;
    //    }

    //    Debug.Log(rb.velocity.ToString() + cf.feetVel.ToString());
    //    //rb.isKinematic = true;
    //    //            rb.velocity = cf.feetVel.normalized * scale;///Vector3.zero;
    //}


        //}
//        Debug.Log(rb.velocity);
        if (cf.feetVel != Vector3.zero)
        {
            
        }

        //rb.AddForce(orientation.transform.forward * move.z * moveSpeed,ForceMode.Impulse);// * Time.deltaTime * modifier * multiplier * multiplierV);
        //rb.AddForce(orientation.transform.right * move.x * moveSpeed, ForceMode.Impulse);// * Time.deltaTime * modifier * multiplier);
        //}


    }

    void HandleJump()
    {

        // For jumping we do something similar with force
        // However we want it instant so we can use the Impulse force mode
        if (cf.feet && Input.GetKeyDown(KeyCode.Space))
        {
            rb.velocity += orientation.up * jumpForce;
            //rb.AddForce(orientation.up * jumpForce, ForceMode.Impulse);
        }
    }

    private float desiredX;
    private void Look()
    {
        float mouseX = Input.GetAxis("Mouse X") * sensitivity * Time.fixedDeltaTime * senMultiplier;
        float mouseY = Input.GetAxis("Mouse Y") * sensitivity * Time.fixedDeltaTime * senMultiplier;

        // Find current look rotation
        Vector3 rot = playerCam.transform.localRotation.eulerAngles;
        desiredX = rot.y + mouseX;

        // Rotate, and also make sure we don't over or under rotate
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        // Perform the rotations
        playerCam.transform.localRotation = Quaternion.Euler(xRotation, desiredX, 0);
        orientation.transform.localRotation = Quaternion.Euler(0, desiredX, 0);

        // While Wallrunning
        // Tilts camera in .5 second
        
    }


    

}
