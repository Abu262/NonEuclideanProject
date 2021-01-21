﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class grab : MonoBehaviour
{
    public float grabLength = 4f;
    //public LayerMask Mask;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {


        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            if (Physics.Raycast(
                    Camera.main.transform.position,
                    Camera.main.transform.forward,
                    out hit,
                    grabLength,
                    ~(1 << 12)
                ))
            {
                //if we hit an item display the item
                if (hit.collider.tag == "ZBlock")
                {
                    Debug.Log("HIT");
                    SlideZ sz = hit.collider.GetComponentInParent<SlideZ>();//.GetComponent<SlideZ>();

                    //if (sz.Dir == 0 || sz.Dir == -1)
                    //{
                    //    sz.Dir = 1;
                    //}
                    //else if (sz.Dir == 1)
                    //{
                    //    sz.Dir = -1;
                    //}
                    sz.flip = !sz.flip;
                }
                else if (hit.collider.tag == "Rotator")
                {
//                    Debug.Log("anime0");
                    RotateSection rs = hit.collider.gameObject.GetComponent<RotateSection>();
                    rs.RotateChildren();
                }
            }
        }
    }
}
