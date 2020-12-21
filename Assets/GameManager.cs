using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class GameManager : MonoBehaviour
{
    public int Dir;

    [HideInInspector]
    public int CoinCount = 0;

    
    public TextMeshProUGUI DisplayCounter;

    public int LevelTotal = 0;

    public Quaternion GravityDir;
    public Vector3 defaultVel;
    public Vector3 realVel;
    public Vector3 initialGrav;
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
        initialGrav = Physics.gravity;
        //BGM.Play();
    }

    // Update is called once per frame
    void Update()
    {
        //defaultVel = Quaternion.Inverse(GravityDir) * realVel;
        //Physics.gravity = GravityDir * initialGrav;
        //Debug.Log(Physics.gravity); 
    }
}
