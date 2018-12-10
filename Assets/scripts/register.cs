using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.UI;

public enum PasswordScore
{
    Blank = 0,
    VeryWeak = 1,
    Weak = 2,
    Medium = 3,
    Strong = 4,
    VeryStrong = 5
}

public class register : MonoBehaviour
{
    public InputField username;
    public InputField password;
    public InputField rePassword;
    public InputField mail;
    public InputField phone;
    public GameObject netErr;
    public Slider passCmx;

    void Update()
    {
        if (password.text.Trim() != "")
        {
            passCmx.value = checkStrength(password.text.Trim());
        }
        else
        {
            passCmx.value = 0;
        }
    }
    public void REGISTER()
    {
        if (CheckInternetConnection())
        {
            if (IsValidEmail())
            {
                if (IsValidPhone())
                {
                    if (passSync())
                    {
                        if (password.text.Trim().Length > 8)
                        {
                            if (username.text.Trim().Length > 5)
                            {
                                if (password.text.Contains("\"") || password.text.Contains("\'"))
                                {
                                    //pass ' , " dare
                                }
                                else
                                {
                                    if (password.text.Contains("\"") || password.text.Contains("\'"))
                                    {
                                        //usr ' , " dare
                                    }
                                    else
                                    {
                                        sync();
                                    }
                                }
                            }
                            else
                            {
                                //usr kootahe
                            }
                        }
                        else
                        {
                            //pass kootahe
                        }
                    }
                    else
                    {
                        //pass not sync
                    }
                }
                else
                {
                    //phone
                }
            }
            else
            {
                //mail
            }
        }
        else
        {
            netErr.SetActive(true);
            StartCoroutine(Example(netErr));
        }
    }
    bool IsValidPhone()
    {
        if (phone.text.Trim()[0] + "" + phone.text.Trim()[1] != "09")
            return false;
        if (phone.text.Trim().Length != 11)
            return false;
        for (int i = 2; i < phone.text.Trim().Length; i++)
        {
            if (!char.IsDigit(phone.text.Trim()[i]))
            {
                return false;
            }
        }

        return true;
    }

    
    public PasswordScore CheckStrength(string password)
    {
        int score = 0;
        if (password.Length < 1)
            return PasswordScore.Blank;
        if (password.Length < 4)
            return PasswordScore.VeryWeak;

        if (password.Length >= 8)
            score++;
        if (password.Length >= 12)
            score++;
        if (Regex.Match(password, @"/\d+/", RegexOptions.ECMAScript).Success)
            score++;
        if (Regex.Match(password, @"/[a-z]/", RegexOptions.ECMAScript).Success &&
          Regex.Match(password, @"/[A-Z]/", RegexOptions.ECMAScript).Success)
            score++;
        if (Regex.Match(password, @"/.[!,@,#,$,%,^,&,*,?,_,~,-,£,(,)]/", RegexOptions.ECMAScript).Success)
            score++;

        return (PasswordScore)score;

    }
    int passCmpx()
    {
        string pass = password.text.Trim();
        PasswordScore passwordStrengthScore = CheckStrength(pass);

        switch (passwordStrengthScore)
        {
            case PasswordScore.Blank:
                return 0;
            case PasswordScore.VeryWeak:
                return 1;
            case PasswordScore.Weak:
                return 2;
            case PasswordScore.Medium:
                return 3;
            case PasswordScore.Strong:
                return 4;
            case PasswordScore.VeryStrong:
                return 5;
            default:
                return 0;
        }
    }
    void sync()
    {
        try
        {
            string url = @"http://unityhosting.ir/zehn/register.php";
            string str = username.text.Trim();
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create(url);
            req.Method = "POST";
            string Data = "username=" + str;
            Data += "&pass=" + rePassword.text.Trim();
            Data += "&mail=" + mail.text.Trim();
            Data += "&phone=" + phone.text.Trim();
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
                Debug.Log("azGhablHast");
            }
            else if (responseText == "3")
            {
                Debug.Log("shod");
            }
            else
            {
                Debug.Log("naShod");
            }
        }
        catch
        {

        }
    }
    bool passSync()
    {
        if (password.text.Trim() == rePassword.text.Trim())
        {
            return true;
        }
        return false;
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
    bool IsValidEmail()
    {
        try
        {
            var addr = new System.Net.Mail.MailAddress(mail.text.Trim());
            return addr.Address == mail.text.Trim();
        }
        catch
        {
            return false;
        }
    }
    public int checkStrength(string password)
    {
        int score = 0;
        if (password.Length > 2)
            score++;
        if (password.Length > 5)
            score++;
        if (password.Length > 8)
            score++;
        if (password.Length > 10)
            score++;
        string arr = "!@#$%^&*()_+";
        for (int i = 0; i < arr.Length; i++)
        {
            if (password.Contains(arr[i].ToString()))
            {
                score++;
                break;
            }
        }

        if (password.Contains("\"") || password.Contains("\'"))
        {
            return -1;
        }
        return 0;

    }
}
