using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mainCamera : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {
        //PlayerPrefs.SetInt("login", 0);

        if (PlayerPrefs.GetInt("login") == 1)
        {
            Debug.Log(PlayerPrefs.GetString("username") + "khoshamadi");
        }
        else
        {
            //Debug.Log("lotfan vared shavid");
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
