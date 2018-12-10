using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

public class login : MonoBehaviour
{
    public InputField username;
    public InputField password;
    public GameObject vareded;
    public GameObject netErr;
    public GameObject usrErr;
	public GameObject mainpage;
	public GameObject loginpage;
	public void LOGIN()
    {
        if (CheckInternetConnection())
        {
            sync();
        }
        else
        {
            netErr.SetActive(true);
            StartCoroutine(Example(netErr));
        }
    }
    void sync()
    {
        try
        {
            string url = @"http://unityhosting.ir/zehn/login.php";
            string str = username.text.Trim();
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create(url);
            req.Method = "POST";
            string Data = "username=" + str;
            Data += "&password=" + password.text.Trim();
            byte[] postBytes = Encoding.ASCII.GetBytes(Data);
            req.ContentType = "application/x-www-form-urlencoded";
            req.ContentLength = postBytes.Length;
            Stream requestStream = req.GetRequestStream();
            requestStream.Write(postBytes, 0, postBytes.Length);
            requestStream.Close();

            HttpWebResponse response = (HttpWebResponse)req.GetResponse();

            var sr = new StreamReader(response.GetResponseStream());
            string responseText = sr.ReadToEnd();
            if (responseText == "0")
            {
                PlayerPrefs.SetInt("login", 0);
                PlayerPrefs.SetString("username", "");
                usrErr.SetActive(true);
                StartCoroutine(Example(usrErr));
            }
            else if (responseText == "2")
            {
                PlayerPrefs.SetInt("login", 1);
                PlayerPrefs.SetString("username", username.text.Trim());
                vareded.SetActive(true);
                StartCoroutine(Example(vareded));
				mainpage.active = true;
				loginpage.active = false;
			}
        }
        catch
        {

        }
    }
    IEnumerator Example(GameObject a)
    {
        yield return new WaitForSecondsRealtime(2);
        a.SetActive(false);
    }
    bool CheckInternetConnection()
    {
        try
        {
            using (var client = new WebClient())
            using (var stream = client.OpenRead("http://google.com"))
            {
                return true;
            }
        }
        catch
        {
            return false;
        }
    }
}
