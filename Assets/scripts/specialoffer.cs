using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Net;
using System.Text;
using System.IO;
public class specialoffer : MonoBehaviour {
	public InputField code;
	public GameObject Error;
	// Use this for initialization
	void Start () {
		
	}
	public void buy ()
	{
		try {
			string code1 = code.text.Trim();
			Debug.Log(code1);
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
			Debug.Log(responseText);
		if (responseText.Trim() == "1")
		{
				
			if(code1 == "2dj32cq")
				{
					Zarinpal.Initialize();
					Zarinpal.Purchase(68000, " خرید کل ویس های ماه اول ", "12");
					Debug.Log("1");
				}
				if (code1 ==	 "4tgc312")
				{
					Zarinpal.Initialize();
				int a =	PlayerPrefs.GetInt("VoiceB");
					Zarinpal.Purchase(24000, " خرید 4 تا ویس ماه اول باهم ", (a+4+""));
					Debug.Log("2");
				}
				if (code1 == "24wctq")
				{
					Zarinpal.Initialize();
					Zarinpal.Purchase(68000, " خرید کل ویس های ماه اول ", "12");
					Debug.Log("3");
				}
				if (code1 == "22sckg")
				{
					Zarinpal.Initialize();
					int a = PlayerPrefs.GetInt("VoiceB");
					Zarinpal.Purchase(24000, " خرید 4 تا ویس ماه اول باهم ", (a + 4 + ""));
					Debug.Log("4");
				}
			}
		else
		{
			Error.SetActive(true);
		}

	}
		catch
		{

		}
	}
	// Update is called once per frame
	void Update () {
		
	}
}
