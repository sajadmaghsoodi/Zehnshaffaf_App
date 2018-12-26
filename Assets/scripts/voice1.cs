using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
	// Use this for initialization
	void Start () {
	 tmp = prossmusic.transform.localPosition.x;
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

		playing = true;
		mas.clip = clip;
		mas.Play();
		
	}
	public void pause1()
	{
		mas.Pause();

	}
	// Update is called once per frame
	void Update () {
		if ( www != null)
		{
			processbar1.transform.localScale = new Vector3(www.progress * 2.5f, 1, 1);
			//gameObject.active = true;
			
		}
		Debug.Log(playing);	
		if (playing)
		{
			Debug.Log("entered");
			timer += Time.deltaTime;
			Debug.Log(timer);
			prossmusic.transform.localPosition = new Vector3(tmp + timer, prossmusic.transform.localPosition.y, prossmusic.transform.localPosition.z);
		}
	}
}
