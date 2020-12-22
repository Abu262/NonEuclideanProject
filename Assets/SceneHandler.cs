using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class SceneHandler : MonoBehaviour
{
    public int Dir;
    public GameManager GM;
    [HideInInspector]
    public int CoinCount = 0;


    public TextMeshProUGUI DisplayCounter;

    public int LevelTotal = 0;
    public Vector3 initialGrav;



    private void Awake()
    {
        Physics.gravity = new Vector3(0, -9.8f, 0);
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
