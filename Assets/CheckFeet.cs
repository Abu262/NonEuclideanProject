using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckFeet : MonoBehaviour
{
    //[HideInInspector]
    public bool feet;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
        feet = true;
    }
    private void OnTriggerExit(Collider other)
    {
        feet = false;
    }
}
