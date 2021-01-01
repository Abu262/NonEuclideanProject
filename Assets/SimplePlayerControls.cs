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


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        //playerScale = transform.localScale;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }


    private void Update()
    {
        Look();


    }


    void LateUpdate()
    {
        // Handle the movement
        HandleMovement();

        // Handle Jumping
        HandleJump();

        Restart();
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
            Vector3 curVel = orientation.transform.forward * move.z * moveSpeed
                + orientation.transform.right * move.x * moveSpeed;    //rb.velocity;
            curVel += transform.rotation * new Vector3(0, baseVel.y, 0);
            rb.velocity = curVel + cf.feetVel;
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
