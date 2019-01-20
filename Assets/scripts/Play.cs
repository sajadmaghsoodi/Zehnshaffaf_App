using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Play : MonoBehaviour {
	public AudioSource myaudiosource;
	public Slider myslider;
	bool playing = false;
	public GameObject pausebtn;
	public GameObject playbtn;
	float timer;
	float value;
	public float lastvalue;
	// Use this for initialization
	void Start () {
		myaudiosource= GetComponent<AudioSource>();
	}
	public void play()
	{
		myaudiosource.Play();
		playing = true;
		pausebtn.SetActive(true);
		playbtn.SetActive(false);
		value = 200 / myaudiosource.clip.length;
	}
	public void pause()
	{
		myaudiosource.Pause();
		playing = false;
		playbtn.SetActive(true);
		pausebtn.SetActive(false);
	}
	public void reset()
	{
		myaudiosource.time = 0;
		myslider.value = 0;
	}
	public void close()
	{
		myslider.value = 0;
		playbtn.SetActive(true);
		pausebtn.SetActive(false);
		myaudiosource.Stop();
	}
	// Update is called once per frame
	void Update () {
		

		if(playing == true)
		{
			timer += Time.deltaTime;
			if (myslider.value > lastvalue + 1 || myslider.value < lastvalue )
			{
				myaudiosource.time = myslider.value / value;
				lastvalue = myslider.value;
			    
			}
		   if(timer > 0.5f)
			{
				Debug.Log("ass");
				timer = 0;
				lastvalue = myslider.value;
				myslider.value = myslider.value + value;
			}
		   
		}
	}
}
