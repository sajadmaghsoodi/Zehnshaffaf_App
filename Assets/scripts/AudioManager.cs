using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
[RequireComponent(typeof(AudioSource))]
public class AudioManager : MonoBehaviour {
    //Variables
    float reseter;
    bool Pausedd;
    float smt;
    float second;
    public string minutes, seconds, miliseconds;
    public bool ended = true;
    private float starttime;
    public float t;
    float b;
    private int a = 0;
    private int tmp = 0;
    //Classes For Objects
    public Slider[] slider;
    public Text[] TimSec;
    public AudioClip[] Audios;
    private AudioSource source;
	public GameObject play1;
	public GameObject play2;
	public GameObject play3;
	public GameObject play4;
	public GameObject play5;
	public GameObject pause1;
	public GameObject pause2;
	public GameObject pause3;
	public GameObject pause4;
	public GameObject pause5;
	public Text timer1;
	public Text timer2;
	public Text timer3;
	public Text timer4;
	public Text timer5;
	void Start () {
        source = GetComponent<AudioSource>();
		
	}
	
	void Update ()
    {
        #region MusicPlayer
        if (source.isPlaying)
        {
            second = smt % 20;
            slider[tmp].maxValue = source.clip.length;
            if(slider[tmp].maxValue<=source.clip.length)
            {
                slider[tmp].value += second;
            }
             t = Time.time - reseter;
             smt = Time.deltaTime;
            string minutes = ((int)t / 60).ToString();
            string seconds = (t % 60).ToString("f0");
            TimSec[tmp].text ="0"+ minutes + ":" + seconds ;
        }
        if(t==source.clip.length)
          {
              reseter = Time.time;
           TimSec[tmp].text = "00:00";
          }
        #endregion
    }
    //AudioPlayer Functions
    public void PlayAudio01()
    {
            ended = false;
            tmp = 0;
            a = 0;
            source.clip = Audios[a];
            source.Play();
    }
    public void PlayAudio02()
    {
            ended = false;
            tmp = 1;
            a = 1;
            source.clip = Audios[a];
            source.Play();
    }
    public void PlayAudio03()
    {
            ended = false;
            tmp = 2;
            a = 2;
            source.clip = Audios[a];
            source.Play();
    }
    public void PlayAudio04()
    {
            ended = false;
            tmp = 3;
            a = 3;
            source.clip = Audios[a];
            source.Play();
    }
    public void PlayAudio05()
    {
            tmp = 4;
            a = 4;
            source.clip = Audios[a];
            source.Play();
            ended = false;
    }
    //The One and Only Pause Function
    public void Paused()
    {
        Pausedd = true;
        ended = true;
        source.Pause();
    }
    public void Back()
    {
		SceneManager.LoadScene(0);
    }
    //Reset Functions
    public void Reset01()
    {
        reseter = Time.time;
        tmp = 0;
        a = 0;
        slider[tmp].value = 0;
        source.clip = Audios[a];
        source.Play();
    }
    public void Reset02()
    {
        reseter = Time.time;
        tmp = 1;
        a = 1;
        slider[tmp].value = 0;
        source.clip = Audios[a];
        source.Play();
    }
    public void Reset03()
    {
        reseter = Time.time;
        tmp = 2;
        a = 2;
        slider[tmp].value = 0;
        source.clip = Audios[a];
        source.Play();
    }
    public void Reset04()
    {
        reseter = Time.time;
        tmp = 3;
        a = 3;
        slider[tmp].value = 0;
        source.clip = Audios[a];
        source.Play();
    }
    public void Reset05()
    {
        reseter = Time.time;
        tmp = 4;
        a = 4;
        slider[tmp].value = 0;
        source.clip = Audios[a];
        source.Play();
    }
	public void Allpause()
	{
		play1.SetActive(true);
		play2.SetActive(true);
		play3.SetActive(true);
		play4.SetActive(true);
		play5.SetActive(true);
		pause1.SetActive(false);
		pause2.SetActive(false);
		pause3.SetActive(false);
		pause4.SetActive(false);
		pause5.SetActive(false);
	}

}
