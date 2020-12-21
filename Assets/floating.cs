using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class floating : MonoBehaviour
{
    public AnimationCurve myCurve;
    public GameManager GM;
    // Start is called before the first frame update
    void Start()
    {
        GM = FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.right * Time.deltaTime * 90);
       // transform.position = new Vector3(transform.position.x, myCurve.Evaluate((Time.time % myCurve.length)), transform.position.z);
    }

    void OnControllerColliderHit(ControllerColliderHit hit)
    {

        GM.AS.Play();
        Destroy(gameObject);
    }
    void OnCollisionEnter(Collision collision)
    {
        if (GM.DisplayCounter != null)
        {
            GM.CoinCount += 1;
            GM.DisplayCounter.text = "Collected: " + GM.CoinCount.ToString() + "\nRequired: " + GM.LevelTotal.ToString();
        }

        GM.AS.Play();
        Destroy(gameObject);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (GM.DisplayCounter != null)
        {
            GM.CoinCount += 1;
            GM.DisplayCounter.text = "Collected: " + GM.CoinCount.ToString() + "\nRequired: " + GM.LevelTotal.ToString();
        }
        GM.AS.Play();
        Destroy(gameObject);
    }
}
