using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int Dir;
    public AudioSource AS;
    public AudioSource BGM;
    //-2 negative y
    //2 positive y

    //-1 negative x
    //1 positive x

    //-3 negative z
    //3 positive z

    // Start is called before the first frame update
    void Start()
    {
        BGM.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
