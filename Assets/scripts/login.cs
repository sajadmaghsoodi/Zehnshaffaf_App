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
    public void LOGIN()
    {
        if (CheckInternetConnection())
        {
            sync();
            Debug.Log("shod");
        }
        else
        {
            Debug.Log("NET ERR");
        }
    }
    void sync()
    {
        try
        {
            string url = @"http://arch.coolpage.biz/install.php";
            string str = username.text.Trim();
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create(url);
            req.Method = "POST";
            string Data = "name=" + str;
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
                Debug.Log("نام کاربری صحیح نمیباشد");
            }
            else if (responseText == "1")
            {
                PlayerPrefs.SetInt("login", 0);
                PlayerPrefs.SetString("username", "");
                Debug.Log("کلمه عبور صحیح نمیباشد");
            }
            else if (responseText == "2")
            {
                PlayerPrefs.SetInt("login", 1);
                PlayerPrefs.SetString("username", username.text.Trim());
                Debug.Log("وارد شدید");
            }
        }
        catch
        {

        }
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
