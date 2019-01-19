using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using System.Net;
using System.IO;
public class voice7 : MonoBehaviour {
	bool setactived1;
	public GameObject Downloading1;
	public GameObject play1;
	public GameObject musicplayer;
	public AudioSource ouraudiosource;
	// Use this for initialization
	void Start () {
	 
	}

		public void LoadURL( String adress,string name)
	{
		System.Net.ServicePointManager.ServerCertificateValidationCallback +=
		   delegate (object sender, System.Security.Cryptography.X509Certificates.X509Certificate certificate,
								   System.Security.Cryptography.X509Certificates.X509Chain chain,
								   System.Net.Security.SslPolicyErrors sslPolicyErrors)
		   {
			   return true; // **** Always accept
		   };
		System.Net.WebClient client = new WebClient();
		client.DownloadFileCompleted += new System.ComponentModel.AsyncCompletedEventHandler(DownloadFileCompleted);
	
		client.DownloadFileAsync( new Uri (adress), Application.persistentDataPath +"/"+ name);
		Downloading1.SetActive(true);
        
		Debug.Log("download started");
	}
	void DownloadFileCompleted(object sender, System.ComponentModel.AsyncCompletedEventArgs e)
	{
		if (e.Error == null)
		{
			AllDone();
			setactived1 = true;
		}
		else
		{ Debug.Log(e.Error); }
	}
	void AllDone()
	{
		Debug.Log("compelete");
		
	}
	public void download1()
	{

		LoadURL("https://storage.tarafdari.com/contents/user221704/content-sound/nirvana_-_the_man_who_sold_the_world.mp3","17.mp3");
	}
	public  void playbtn1()
	{
		WWW www = new WWW("file:///" + Application.persistentDataPath + "/17.mp3");
		while (!www.isDone)
		{
			Debug.Log("loadingxxx");
		}
		ouraudiosource. GetComponent<AudioSource>().clip = www.GetAudioClip(false, true);
		musicplayer.SetActive(true);
		ouraudiosource.GetComponent<AudioSource>().Pause();
	}
	// Update is called once per frame
	void Update () {

		if(setactived1 == true)
		{
			play1.SetActive(true);
			Downloading1.SetActive(false);
			PlayerPrefs.SetInt("17D", 1);
		}
	
	
   /*
		
		if(play.active && !playbtn.active)
		{
			int lngth = (int)mas.clip.length;
			X = lngth / 100;
			timer += Time.deltaTime;
			
			if(timer > X)
			{
				priviusmusicvalue = music.value;
				music.value = music.value + 1 ;
				timer = 0;
			}
			if((priviusmusicvalue > (music.value + 2))  || priviusmusicvalue < (music.value - 2))
			{
				valuechanged();
			}
			*/
		}
	}

