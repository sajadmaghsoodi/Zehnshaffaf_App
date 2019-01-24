using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Net;
using System.Text;
using System.IO;

public class Appmanager : MonoBehaviour {
	public GameObject signup;
	public GameObject login;
	public GameObject mainpage;
	public GameObject download1;
	public GameObject download2;
	public GameObject download3;
	public GameObject download4;
	public GameObject download5;
	public GameObject download6;
	public GameObject download7;
	public GameObject download8;
	public GameObject download9;
	public GameObject download10;
	public GameObject download11;
	public GameObject download12;
	public GameObject play1;
	public GameObject play2;
	public GameObject play3;
	public GameObject play4;
	public GameObject play5;
	public GameObject play6;
	public GameObject play7;
	public GameObject play8;
	public GameObject play9;
	public GameObject play10;
	public GameObject play11;
	public GameObject play12;
	public GameObject Expierd1;
	public GameObject Expierd2;
	public GameObject updatemsg;
	public GameObject Buypannel1;
	public GameObject Buypannel2;
	public GameObject Buypannel3;
	public GameObject Buypannel4;
	public GameObject Buypannel5;
	public GameObject Buypannel6;
	public GameObject Buypannel7;
	public GameObject Buypannel8;
	public GameObject Buypannel9;
	public GameObject Buypannel10;
	public GameObject Buypannel11;
	public GameObject Buypannel12;
	public GameObject CB1;
	public GameObject CB2;
	public GameObject CB3;
	public GameObject CB4;
	public GameObject CB5;
	public GameObject CB6;
	public GameObject CB7;
	public GameObject CB8;
	public GameObject CB9;
	public GameObject CB10;
	public GameObject CB11;
	public GameObject CB12;
	int i = 0;
	// Use this for initialization
	void Start () {
		PlayerPrefs.SetInt("version", 1);
		UpdateChecker();
		Logincheck();
		voicedownloadcheck();
		Specialofferchecker();
		SyncvoiceBuyed();
		VoiceBChecker();
	}
	public void Logincheck()
	{
		int tmp = PlayerPrefs.GetInt("login");
		if( tmp == 1)
		{
			mainpage.SetActive(true);
			login.SetActive(false);
		}
		if(tmp == 0)
		{
			login.SetActive(true);
			mainpage.SetActive(false);
		}
	}
	public void voicedownloadcheck()
	{
		for (int i = 1; i <= 12; i++)
		{
			int tmp = PlayerPrefs.GetInt("1" + i + "D");
			if (i == 1 && tmp == 1)
			{
				download1.SetActive(false);
				play1.SetActive(true);
			}
			if (i == 2 && tmp == 1)
			{
				download2.SetActive(false);
				play2.SetActive(true);
			}
			if (i == 3 && tmp == 1)
			{
				download3.SetActive(false);
				play3.SetActive(true);
			}
			if (i == 4 && tmp == 1)
			{
				download4.SetActive(false);
				play4.SetActive(true);
			}
			if (i == 5 && tmp == 1)
			{
				download5.SetActive(false);
				play5.SetActive(true);
			}
			if (i == 6 && tmp == 1)
			{
				download6.SetActive(false);
				play6.SetActive(true);
			}
			if (i == 7 && tmp == 1)
			{
				download7.SetActive(false);
				play7.SetActive(true);
			}
			if (i == 8 && tmp == 1)
			{
				download8.SetActive(false);
				play8.SetActive(true);
			}
			if (i == 9 && tmp == 1)
			{
				download9.SetActive(false);
				play9.SetActive(true);
			}
			if (i == 10 && tmp == 1)
			{
				download10.SetActive(false);
				play10.SetActive(true);
			}
			if (i == 11 && tmp == 1)
			{
				download11.SetActive(false);
				play11.SetActive(true);
			}
		
			if (i == 12 && tmp == 1)
			{
				download12.SetActive(false);
				play12.SetActive(true);
			}

		}
		//Debug.Log("voicedownload checked");
	}
	public void UpdateChecker()
	{
	
			int version = PlayerPrefs.GetInt("version");
			try
			{
				string url = "http://unityhosting.ir/zehn/appUpdator.php";
				HttpWebRequest req = (HttpWebRequest)WebRequest.Create(url);
				req.Method = "POST";
				string Data = "v=" + version;
				byte[] postbytes = Encoding.ASCII.GetBytes(Data);
				req.ContentType = "application/x-www-form-urlencoded";
				req.ContentLength = postbytes.Length;
				Stream requestStream = req.GetRequestStream();
				requestStream.Write(postbytes, 0, postbytes.Length);
				requestStream.Close();
				HttpWebResponse response = (HttpWebResponse)req.GetResponse();
				var sr = new StreamReader(response.GetResponseStream());
				string responseTxt = sr.ReadToEnd();
		 if (responseTxt[0] == '1')
				{
					//Debug.Log("updated");
				}
			else
				{
					updatemsg.SetActive(true);
					Debug.Log("new version avalable");
				}

			}
			catch
			{
				Debug.Log("faild to check update");
			}
			
	}
    public void Specialofferchecker()
	{

		try
		{
			string code = "354241";//کدی که باید چک شود


			string url = @"http://unityhosting.ir/zehn/codeChecker.php";
			HttpWebRequest req = (HttpWebRequest)WebRequest.Create(url);
			req.Method = "POST";
			string Data = "c=" + code;
			byte[] postBytes = Encoding.ASCII.GetBytes(Data);
			req.ContentType = "application/x-www-form-urlencoded";
			req.ContentLength = postBytes.Length;
			Stream requestStream = req.GetRequestStream();
			requestStream.Write(postBytes, 0, postBytes.Length);
			requestStream.Close();

			HttpWebResponse response = (HttpWebResponse)req.GetResponse();

			var sr = new StreamReader(response.GetResponseStream());
			string responseText = sr.ReadToEnd();

			if (responseText == "1")
			{
				Expierd1.SetActive(false);
			}
			else
			{
				Expierd1.SetActive(true);
			}

		}
		catch
		{

		}
		try
		{
			string code = "12345332";//کدی که باید چک شود


			string url = @"http://unityhosting.ir/zehn/codeChecker.php";
			HttpWebRequest req = (HttpWebRequest)WebRequest.Create(url);
			req.Method = "POST";
			string Data = "c=" + code;
			byte[] postBytes = Encoding.ASCII.GetBytes(Data);
			req.ContentType = "application/x-www-form-urlencoded";
			req.ContentLength = postBytes.Length;
			Stream requestStream = req.GetRequestStream();
			requestStream.Write(postBytes, 0, postBytes.Length);
			requestStream.Close();

			HttpWebResponse response = (HttpWebResponse)req.GetResponse();

			var sr = new StreamReader(response.GetResponseStream());
			string responseText = sr.ReadToEnd();
			if (responseText == "1")
			{
				Expierd2.SetActive(false);
			}
			else
			{
				Expierd2.SetActive(true);
			}

		}
		catch
		{

		}
	}
	public void SyncvoiceBuyed()
	{
		try
		{
			string url = @"http://unityhosting.ir/zehn/userBuyid.php";
			HttpWebRequest req = (HttpWebRequest)WebRequest.Create(url);
			req.Method = "POST";
            string Data = "mail=" + PlayerPrefs.GetString("usrMail");
			byte[] postBytes = Encoding.ASCII.GetBytes(Data);
			req.ContentType = "application/x-www-form-urlencoded";
			req.ContentLength = postBytes.Length;
			Stream requestStream = req.GetRequestStream();
			requestStream.Write(postBytes, 0, postBytes.Length);
			requestStream.Close();

			HttpWebResponse response = (HttpWebResponse)req.GetResponse();

			var sr = new StreamReader(response.GetResponseStream());
			string responseText = sr.ReadToEnd();
			responseText.Trim();
			Debug.Log(responseText);
			if ( responseText == "1")
			{
				PlayerPrefs.SetInt("VoiceB", 1);
			}
			if (responseText == "2")
			{
				PlayerPrefs.SetInt("VoiceB", 2);
			}
			if (responseText == "3")
			{
				PlayerPrefs.SetInt("VoiceB", 3);
			}
			if (responseText == "4")
			{
				PlayerPrefs.SetInt("VoiceB", 4);
			}
			if (responseText == "5")
			{
				PlayerPrefs.SetInt("VoiceB", 5);
			}
			if (responseText == "6")
			{
				PlayerPrefs.SetInt("VoiceB", 6);
			}
			if (responseText == "7")
			{
				PlayerPrefs.SetInt("VoiceB", 7);
			}
			if (responseText == "8")
			{
				PlayerPrefs.SetInt("VoiceB", 8);
			}
			if (responseText == "9")
			{
				PlayerPrefs.SetInt("VoiceB", 9);
			}
			if (responseText == "10")
			{
				PlayerPrefs.SetInt("VoiceB", 10);
			}
			if (responseText == "11")
			{
				PlayerPrefs.SetInt("VoiceB", 11);
			}
			if (responseText == "12")
			{
				PlayerPrefs.SetInt("VoiceB", 12);
			}

		}
		catch
		{

		}
	}
	public void VoiceBChecker()
	{
		GameObject[] Buypannel;
		Buypannel = new GameObject[13];
		Buypannel[1] = Buypannel1;
		Buypannel[2] = Buypannel2;
		Buypannel[3] = Buypannel3;
		Buypannel[4] = Buypannel4;
		Buypannel[5] = Buypannel5;
		Buypannel[6] = Buypannel6;
		Buypannel[7] = Buypannel7;
		Buypannel[8] = Buypannel8;
		Buypannel[9] = Buypannel9;
		Buypannel[10] = Buypannel10;
		Buypannel[11] = Buypannel11;
		Buypannel[12] = Buypannel12;
		int Tmp = PlayerPrefs.GetInt("VoiceB");
        for (int i = Tmp; i > 0; i --)
		{
			Buypannel[i].SetActive(false);
		}
		
	}

	
	void Update () {
 
	}
}
