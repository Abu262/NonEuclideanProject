using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BobbingDecoration : MonoBehaviour
{
    public AnimationCurve myCurve;

    public Transform pTransform;
    public Transform cTransform;

    private float rotateSpeed;
    private float bobSpeed;
    float initialPos;
    // Start is called before the first frame update
    void Start()
    {
        rotateSpeed = Random.Range(0, 90);
        bobSpeed = Random.Range(1, 5);
        pTransform.rotation = Quaternion.Euler(Random.Range(0, 360), Random.Range(0, 360), Random.Range(0, 360));
        cTransform.rotation = Quaternion.Euler(Random.Range(0, 360), Random.Range(0, 360), Random.Range(0, 360));
        float size = Random.Range(0.5f, 4);
        cTransform.localScale = new Vector3(size, size, size);

        initialPos = transform.localPosition.y;

    }

    // Update is called once per frame
    void Update()
    {
       
            //transform.Rotate(Vector3.up * Time.deltaTime * rotateSpeed);
            transform.localPosition = new Vector3(transform.localPosition.x, initialPos + Mathf.Cos(Time.time) / bobSpeed, transform.localPosition.z);
       

    }


}
