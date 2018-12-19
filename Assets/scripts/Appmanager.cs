using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Appmanager : MonoBehaviour {
	public GameObject signup;
	public GameObject login;
	public GameObject mainpage;
	// Use this for initialization
	void Start () {
		
	}
	public void Logincheck()
	{
		int tmp = PlayerPrefs.GetInt("login");
		if( tmp == 1)
		{
			mainpage.SetActive(true);
		}
		if(tmp == 0)
		{
			login.SetActive(true);
		}
	}
	public void Loadvoicescene()
	{
		SceneManager.LoadScene(1);
	}
	// Update is called once per frame
	void Update () {
		
	}
}
