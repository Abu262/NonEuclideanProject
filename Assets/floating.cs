using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class floating : MonoBehaviour
{
    public AnimationCurve myCurve;
    public GameManager GM;
    public SceneHandler SM;
    public LayerMask whatIsPlayer;
    // Start is called before the first frame update
    void Start()
    {
        GM = FindObjectOfType<GameManager>();
        SM = FindObjectOfType<SceneHandler>();
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
        int layer = collision.gameObject.layer;
        if (whatIsPlayer != (whatIsPlayer | (1 << layer))) return;
        if (SM.DisplayCounter != null)
        {
            SM.CoinCount += 1;
            SM.DisplayCounter.text = "Collected: " + SM.CoinCount.ToString() + "\nRequired: " + SM.LevelTotal.ToString();
        }

        GM.AS.Play();
        Destroy(gameObject);
    }
    private void OnTriggerEnter(Collider other)
    {
        int layer = other.gameObject.layer;
        if (whatIsPlayer != (whatIsPlayer | (1 << layer))) return;
        if (SM.DisplayCounter != null)
        {
            SM.CoinCount += 1;
            SM.DisplayCounter.text = "Collected: " + SM.CoinCount.ToString() + "\nRequired: " + SM.LevelTotal.ToString();
        }
        GM.AS.Play();
        Destroy(gameObject);
    }
}
