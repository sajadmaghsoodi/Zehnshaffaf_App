using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class voice1 : MonoBehaviour {
	public string urlvoice1 = "https://www.tarafdari.com/sites/default/files/contents/user6984/content-sound/157.anathema_-_parisienne_moonlight.mp3";
	public GameObject processbar1;
	WWW www;
	AudioClip clip;
	public AudioSource mas;
	public	GameObject download;
	public GameObject buy;
	public GameObject play;
	bool playing;
	float timer;
	public GameObject prossmusic;
	float tmp;
	public GameObject playbtn;
	public GameObject pausebtn;
	int pointer;
	public Slider music;
	int i = 0;
	float X;
	int currentcliplngth;
	float priviusmusicvalue;
	// Use this for initialization
	void Start () {
	 
	}
	IEnumerator LoadURL()
	{
		www = new WWW(urlvoice1);
		clip = www.GetAudioClip(false, true);
		while (!www.isDone)
		{
			yield return www;
		}
		if(www.error == null)
		{
			mas.clip = clip;
			download.active = false;
			play.active = true;
		}
		if(www.error != null)
		{
			Debug.Log("error");
		}
		yield return 0;	
	}
	public void download1()
	{
		StartCoroutine(LoadURL());
	}
	public void play1()
	{

		Debug.Log("play1");
		mas.clip = clip;
		mas.Play();
		played();
		
	}
	public void pause1()
	{
		mas.Pause();

	}
	public void Reset1()
	{
		mas.time = 0;
		music.value = 0;
	}
	
	public void played()
	{
		currentcliplngth = (int)mas.clip.length;
	}
	// Update is called once per frame
	void Update () {



		if ( www != null)
		{
			processbar1.transform.localScale = new Vector3(www.progress * 2.5f, 1, 1);
			//gameObject.active = true;
		}


		
		if(play.active && !playbtn.active)
		{
			int lngth = (int)mas.clip.length;
			timer += Time.deltaTime;
			if(pointer <= lngth)
			if(timer > 1)
			{
					X = 100f / (float)lngth;
					pointer++;
				music.value = music.value + X ;
					priviusmusicvalue = music.value;
				timer = 0;
			}
			
		}
	}
}
