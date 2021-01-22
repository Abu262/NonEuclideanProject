using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class GameManager : MonoBehaviour
{
    public AudioManager AM;
    public int Dir;
    
    //[HideInInspector]
    public bool colorblindMode = false;
    public Material[] materialsCB;

    //[HideInInspector]
    public int VolumeScale = 10;
    //[HideInInspector]
    public int MouseScale = 5;

    //[HideInInspector]
    public int startID = 1;

    [HideInInspector]
    public int CoinCount = 0;

    [HideInInspector]
    public int levelProgress;
    

    public static GameManager instance;

    public TextMeshProUGUI DisplayCounter;

    public int LevelTotal = 0;

    public Quaternion GravityDir;
    public Vector3 defaultVel;
    public Vector3 realVel;
    public Vector3 initialGrav;
    //public AudioSource AS;
    //public AudioSource BGM;
    //-2 negative y
    //2 positive y

    //-1 negative x
    //1 positive x

    void Awake()
    {
//        RenderSettings.ambientLight = new Color(144f, 148f, 156f, 255f);//Color.red;
        levelProgress = PlayerPrefs.GetInt("furthestLevel",1);
        Application.targetFrameRate = 60;

        if (instance == null)
            instance = this;
        else
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);

        startID = levelProgress;
    }

    // Start is called before the first frame update
    void Start()
    {

        AM = FindObjectOfType<AudioManager>();
        initialGrav = Physics.gravity;
        //BGM.Play();
        AM.PlaySound("BGMusic",AM.gameObject,true,0.1f * VolumeScale,true);
    }

    // Update is called once per frame
    void Update()
    {
        //defaultVel = Quaternion.Inverse(GravityDir) * realVel;
        //Physics.gravity = GravityDir * initialGrav;
        //Debug.Log(Physics.gravity); 
    }
}
