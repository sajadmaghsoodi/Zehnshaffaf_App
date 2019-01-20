using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mainCamera : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {
        Zarinpal.Initialize();
        Zarinpal.Purchase(100,"test");
        //PlayerPrefs.SetInt("login", 0);
        Debug.Log("pardakht shod");
        if (PlayerPrefs.GetInt("login") == 1)
        {
            //Debug.Log(PlayerPrefs.GetString("username") + "khoshamadi");
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
