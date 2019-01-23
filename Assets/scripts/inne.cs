using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

public class inne : MonoBehaviour
{

    void Start()
    {
        Zarinpal.StoreInitialized += Zarinpal_StoreInitialized;
        Zarinpal.PurchaseStarted += Zarinpal_PurchaseStarted;
        Zarinpal.PurchaseFailedToStart += Zarinpal_PurchaseFailedToStart;
        Zarinpal.PurchaseSucceed += Zarinpal_PurchaseSucceed;
        Zarinpal.PurchaseFailed += Zarinpal_PurchaseFailed;
        Zarinpal.PurchaseCanceled += Zarinpal_PurchaseCanceled;
        Zarinpal.PaymentVerificationStarted += Zarinpal_PaymentVerificationStarted;
        Zarinpal.PaymentVerificationSucceed += Zarinpal_PaymentVerificationSucceed;
        Zarinpal.PaymentVerificationFailed += Zarinpal_PaymentVerificationFailed;
    }

    void OnDestroy()
    {
        Zarinpal.StoreInitialized -= Zarinpal_StoreInitialized;
        Zarinpal.StoreInitializeFailed += Zarinpal_StoreInitializeFailed;
        Zarinpal.PurchaseStarted -= Zarinpal_PurchaseStarted;
        Zarinpal.PurchaseFailedToStart -= Zarinpal_PurchaseFailedToStart;
        Zarinpal.PurchaseSucceed -= Zarinpal_PurchaseSucceed;
        Zarinpal.PurchaseFailed -= Zarinpal_PurchaseFailed;
        Zarinpal.PurchaseCanceled -= Zarinpal_PurchaseCanceled;
        Zarinpal.PaymentVerificationStarted -= Zarinpal_PaymentVerificationStarted;
        Zarinpal.PaymentVerificationSucceed -= Zarinpal_PaymentVerificationSucceed;
        Zarinpal.PaymentVerificationFailed -= Zarinpal_PaymentVerificationFailed;
    }



    private void Zarinpal_StoreInitialized()
    {
        Log("Store initialized");
    }

    private void Zarinpal_StoreInitializeFailed(string error)
    {
        LogError(error);
    }

    private void Zarinpal_PurchaseStarted()
    {
        Log("Purchase started");
    }

    private void Zarinpal_PurchaseFailedToStart(string error)
    {
        LogError("Purchase failed to start : " + error);
    }

    private void Zarinpal_PurchaseSucceed(string productID, string authority)
    {
        Log(string.Format("Purchase success : productID : {0} , authority : {1} ", productID, authority));
        try
        {
            string url = @"http://unityhosting.ir/zehn/userBuyer.php";
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create(url);
            req.Method = "POST";
            string Data = "mail=" + PlayerPrefs.GetString("usrMail");
            Data += "&ln=" + productID.Trim();
            byte[] postBytes = Encoding.ASCII.GetBytes(Data);
            req.ContentType = "application/x-www-form-urlencoded";
            req.ContentLength = postBytes.Length;
            Stream requestStream = req.GetRequestStream();
            requestStream.Write(postBytes, 0, postBytes.Length);
            requestStream.Close();

            HttpWebResponse response = (HttpWebResponse)req.GetResponse();

            var sr = new StreamReader(response.GetResponseStream());
            string responseText = sr.ReadToEnd();
        }
        catch
        {

        }
    }

    private void Zarinpal_PurchaseFailed()
    {
        LogError("Purchase failed");
    }

    private void Zarinpal_PurchaseCanceled()
    {
        Log("Purchase canceled by user");
    }

    private void Zarinpal_PaymentVerificationStarted(string authority)
    {
        Log("Start verifying purchase for : url : " + authority);
    }

    private void Zarinpal_PaymentVerificationSucceed(string refID)
    {
        Log("Purchase verification success : refid : " + refID);
    }

    private void Zarinpal_PaymentVerificationFailed()
    {
        LogError("Purchase verification failed");
    }


    private void Log(string log)
    {
    }

    private void LogError(string error)
    {
    }














    public void Initialize()
    {
        Zarinpal.Initialize();
    }
    public void Purchase1()
    {
        Zarinpal.Initialize();
        Zarinpal.Purchase(7700, "صوت شماره ی 1 ماه اول", "1");
    }
    public void Purchase2()
    {
        Zarinpal.Initialize();
        Zarinpal.Purchase(7700, "صوت شماره ی 2 ماه اول", "2");
    }
    public void Purchase3()
    {
        Zarinpal.Initialize();
        Zarinpal.Purchase(7700, "صوت شماره ی 3 ماه اول", "3");
    }
    public void Purchase4()
    {
        Zarinpal.Initialize();
        Zarinpal.Purchase(7700, "صوت شماره ی 4 ماه اول", "4");
    }
    public void Purchase5()
    {
        Zarinpal.Initialize();
        Zarinpal.Purchase(7700, "صوت شماره ی  5ماه اول", "5");
    }
    public void Purchase6()
    {
        Zarinpal.Initialize();
        Zarinpal.Purchase(7700, "صوت شماره ی 6 ماه اول", "6");
    }
    public void Purchase7()
    {
        Zarinpal.Initialize();
        Zarinpal.Purchase(7700, "صوت شماره ی 7 ماه اول", "7");
    }
    public void Purchase8()
    {
        Zarinpal.Initialize();
        Zarinpal.Purchase(7700, "صوت شماره ی 8 ماه اول", "8");
    }
    public void Purchase9()
    {
        Zarinpal.Initialize();
        Zarinpal.Purchase(7700, "صوت شماره ی 9 ماه اول", "9");
    }
    public void Purchase10()
    {
        Zarinpal.Initialize();
        Zarinpal.Purchase(7700, "صوت شماره ی 10 ماه اول", "10");
    }
    public void Purchase11()
    {
        Zarinpal.Initialize();
        Zarinpal.Purchase(7700, "صوت شماره ی 11 ماه اول", "11");
    }
    public void Purchase12()
    {
        Zarinpal.Initialize();
        Zarinpal.Purchase(7700, "صوت شماره ی 12 ماه اول", "12");
    }
}
