using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LoadGame : MonoBehaviour
{
    public int levelID;
    float initialPos;

    // Start is called before the first frame update
    void Start()
    {
        initialPos = transform.localPosition.y;
    }

    // Update is called once per frame
    void Update()
    {
        transform.localPosition = new Vector3(transform.localPosition.x, initialPos + Mathf.Cos(Time.time) * 4f, transform.localPosition.z);
    }

    public void click()
    {
        SceneManager.LoadScene(levelID);

    }
}
