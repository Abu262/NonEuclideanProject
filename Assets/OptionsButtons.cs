﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
public class OptionsButtons : MonoBehaviour
{
    GameManager GM;
    public TextMeshProUGUI colorT;
    public TextMeshProUGUI mouseT;
    public TextMeshProUGUI volumeT;
    public TextMeshProUGUI levelT;

    float initialPos;
    float bobSpeed;
    float waitTime;
    float timer;
    // Start is called before the first frame update
    void Start()
    {
        bobSpeed = Random.Range(-2f, 2f);
//        waitTime = Random.Range(0f, 4f);
        GM = FindObjectOfType<GameManager>();
        initialPos = transform.localPosition.y;
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(Time.deltaTime);
     
            transform.localPosition = new Vector3(transform.localPosition.x, initialPos + Mathf.Cos(Time.time) * bobSpeed, transform.localPosition.z);
        

    }

    public void ChangeMouse()
    {
        GM.MouseScale += 1;
        if (GM.MouseScale > 10)
        {
            GM.MouseScale = 1;
        }
        mouseT.text = "Mouse Sensitivity: " + GM.MouseScale.ToString();
    }
    public void ChangeVolume()
    {
        GM.VolumeScale += 1;
        if (GM.VolumeScale > 10)
        {
            GM.VolumeScale = 0;
        }
        volumeT.text = "Volume: " + GM.VolumeScale.ToString();
    }
    public void SwapColorblind()
    {
        GM.colorblindMode = !GM.colorblindMode;
        if (GM.colorblindMode == false)
        {
            colorT.text = "Colorblind: OFF";
        }
        else
        {
            colorT.text = "Colorblind: ON";
        }
    }

    public void chooseLevel(int ID)
    {
        GM.startID += 1;
        if (GM.startID > ID)
        {
            GM.startID = 1;
        }
        levelT.text = "Level: " + GM.startID.ToString();
    }

    public void loadScene(int ID)
    {
        SceneManager.LoadScene(ID);
    }

    public void startGame()
    {
        SceneManager.LoadScene(GM.startID);
    }


}
