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
    public Slider passCmx;
    public GameObject msg;
    public GameObject passer;
    public GameObject usrer;
    public GameObject userkootah;
    public GameObject passkotah;
    public GameObject passync;
    public GameObject mailer;
    public GameObject phoneer;
    public GameObject mailtek;
    public GameObject eter;
    public GameObject neter;
	public GameObject signuppanel;
	public GameObject mainpanel;

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
        if (username.text != "" && password.text != "" && rePassword.text != "" && mail.text != "" && phone.text != "")
        {
            if (CheckInternetConnection())
            {
                if (IsValidEmail())
                {
                    if (IsValidPhone())
                    {
                        if (passSync())
                        {
                            if (password.text.Trim().Length > 5)
                            {
                                if (username.text.Trim().Length > 5)
                                {
                                    if (password.text.Contains("\"") || password.text.Contains("\'"))
                                    {
                                        errShower(passer);
                                    }
                                    else
                                    {
                                        if (username.text.Contains("\"") || username.text.Contains("\'"))
                                        {
                                            errShower(usrer);
                                        }
                                        else
                                        {
                                            sync();
											signuppanel.SetActive(false);
											mainpanel.SetActive(true);
										}
                                    }
                                }
                                else
                                {
                                    errShower(userkootah);
                                }
                            }
                            else
                            {
                                errShower(passkotah);
                            }
                        }
                        else
                        {
                            errShower(passync);
                        }
                    }
                    else
                    {
                        errShower(phoneer);
                    }
                }
                else
                {
                    errShower(mailer);
                }
            }
            else
            {
                errShower(neter);
            }
        }
        else
        {
            errShower(eter);
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
    private void errShower(GameObject name)
    {
        passer.SetActive(false);
        usrer.SetActive(false);
        userkootah.SetActive(false);
        passkotah.SetActive(false);
        passync.SetActive(false);
        mailer.SetActive(false);
        phoneer.SetActive(false);
        mailtek.SetActive(false);
        eter.SetActive(false);
        neter.SetActive(false);
        msg.SetActive(true);
        name.SetActive(true);
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
                errShower(mailtek);
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
        if (Application.internetReachability == NetworkReachability.NotReachable)
        {
            return false;
        }
        return true;
    }
    bool IsValidEmail()
    {
        string t = mail.text.Trim();
        bool f = false;
        int i = 0;
        for (; i < t.Length; i++)
        {
            if (t[i] == '@')
            {
                f = true;
                break;
            }
        }
        if (f)
        {
            for (; i < t.Length; i++)
            {
                if (t[i] == '.')
                {
                    return true;
                }
            }
        }
        return false;
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
