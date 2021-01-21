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
        GM = FindObjectOfType<GameManager>();
        Physics.gravity = new Vector3(0, -9.8f, 0);
    }
    // Start is called before the first frame update
    void Start()
    {
        DisplayCounter.text = "Collected: " + CoinCount.ToString() + "\nRequired: " + LevelTotal.ToString();
        if (GM.colorblindMode == true)
        {
            Debug.Log("Its true!");
            GameObject[] obj = Object.FindObjectsOfType<GameObject>(); //GameObject.FindSceneObjectsOfType(typeof(GameObject));
            foreach (GameObject o in obj)
            {
                //.gameObject.GetComponent<MeshRenderer>().material.ToString()
                if (o.gameObject.GetComponent<MeshRenderer>() != null)
                {
//                    o.gameObject.GetComponent<MeshRenderer>().face
                    Debug.Log(o.gameObject.GetComponent<MeshRenderer>().material.name.Replace("(Instance)", ""));
                    if (o.gameObject.GetComponent<MeshRenderer>().material.name.Replace(" (Instance)", "") == "Blue")
                    {
                        o.gameObject.GetComponent<MeshRenderer>().material = GM.materialsCB[0];
                    }
                    else if (o.gameObject.GetComponent<MeshRenderer>().material.name.Replace(" (Instance)", "") == "Red")
                    {
                        o.gameObject.GetComponent<MeshRenderer>().material = GM.materialsCB[1];
                    }
                    else if (o.gameObject.GetComponent<MeshRenderer>().material.name.Replace(" (Instance)", "") == "Green")
                    {
                        o.gameObject.GetComponent<MeshRenderer>().material = GM.materialsCB[2];
                    }
                    else if (o.gameObject.GetComponent<MeshRenderer>().material.name.Replace(" (Instance)", "") == "Purple")
                    {
                        o.gameObject.GetComponent<MeshRenderer>().material = GM.materialsCB[3];
                    }
                    else if (o.gameObject.GetComponent<MeshRenderer>().material.name.Replace(" (Instance)", "") == "Teal")
                    {
                        o.gameObject.GetComponent<MeshRenderer>().material = GM.materialsCB[4];
                    }
                    else if (   o.gameObject.GetComponent<MeshRenderer>().material.name.Replace(" (Instance)", "") == "Orange")
                    {
                        o.gameObject.GetComponent<MeshRenderer>().material = GM.materialsCB[5];
                    }
                }


                //GameObject g = (GameObject)o;
                //Debug.Log(g.name);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
