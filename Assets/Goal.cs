using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Goal : MonoBehaviour
{

    public AnimationCurve myCurve;
    public GameManager GM;
    public SceneHandler SM;

    float initialPos;
    // Start is called before the first frame update
    void Start()
    {
        initialPos = transform.position.y;
        GM = FindObjectOfType<GameManager>();
        SM = FindObjectOfType<SceneHandler>();
    }

    // Update is called once per frame
    void Update()
    {
        if (SM.CoinCount >= SM.LevelTotal)
        {
            transform.Rotate(Vector3.up * Time.deltaTime * 60);
            transform.position = new Vector3(transform.position.x, initialPos + Mathf.Cos(Time.time)/4, transform.position.z);
        }

    }

    void OnControllerColliderHit(ControllerColliderHit hit)
    {

       
    }
    void OnCollisionEnter(Collision collision)
    {
        //if (GM.DisplayCounter != null)
        //{
        //    GM.CoinCount += 1;
        //    GM.DisplayCounter.text = "Collected: " + GM.CoinCount.ToString() + "\nRequired: " + GM.LevelTotal.ToString();
        //}

        //GM.AS.Play();
        //Destroy(gameObject);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (SM.CoinCount >= SM.LevelTotal)
        {
            SceneManager.LoadScene(0);
        }
    }
}
