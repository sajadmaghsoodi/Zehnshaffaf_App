using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

public class feedBack : MonoBehaviour
{
    public InputField feedTxt;
    public InputField tlgText;
    public InputField nameTxt;
    public GameObject msg;
    public GameObject khalier;
    public GameObject movaf;
    public GameObject neter;


    public void SENDFEEDBACK()
    {
        if (feedTxt.text.Trim() != "" && tlgText.text.Trim() != "" && nameTxt.text.Trim() != "")
        {
            if (CheckInternetConnection())
            {
                sync();
                errShower(movaf);
            }
            else
            {
            errShower(neter);
            }
        }
        else
        {
            errShower(khalier);
        }
    }
    private void errShower(GameObject name)
    {
        khalier.SetActive(false);
        movaf.SetActive(false);
        neter.SetActive(false);
        msg.SetActive(true);
        name.SetActive(true);
    }
    bool CheckInternetConnection()
    {
        if (Application.internetReachability == NetworkReachability.NotReachable)
        {
            return false;
        }
        return true;
    }




    void sync()
    {
        try
        {
            string url = @"http://unityhosting.ir/zehn/feed_back.php";
            string str = PlayerPrefs.GetString("username");
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create(url);
            req.Method = "POST";
            string Data = "username=" + str;
            Data += "&feed_text=" + feedTxt.text.Trim();
            Data += "&tlg=" + tlgText.text.Trim();
            Data += "&name=" + nameTxt.text.Trim();

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
                //nashod
            }
            else if (responseText == "1")
            {
                //shod
            }
        }
        catch
        {

        }
    }
}
