using UnityEngine;
using System;
using UnityEngine.Networking;
using System.Collections;
using UnityEngine.UI;

public class Api : MonoBehaviour
{
    string preInput = "";
    string preResponse = "";

    public RectTransform panel;


    #if UNITY_EDITOR
        string URL = "http://localhost:8000/api/getChat";

        string IMAGE_URL = "http://localhost:8000/api/getImage";
    #else 
        string URL = "http://27.71.226.7:8000/api/getChat";

        string IMAGE_URL = "http://27.71.226.7:8000/api/getImage";
    #endif


    public void CallApi(string txtInput, Action<string> callback)
    {
        StartCoroutine(Upload(txtInput, callback));
    }

    public void GenerateImage(string txtInput, Action<string> callback)
    {
        StartCoroutine(Generate(txtInput, callback));
    }

    IEnumerator Upload(string txtInput, Action<string> callback)
    {
        WWWForm form = new WWWForm();
        form.AddField("text", txtInput.Trim());
        form.AddField("preInput", preInput);
        form.AddField("preResponse", preResponse);
        panel.localScale = new Vector3(1, 1);

        UnityWebRequest www = UnityWebRequest.Post(URL, form);
        yield return www.SendWebRequest();

        panel.localScale = new Vector3(0, 0);
        if (www.result != UnityWebRequest.Result.Success)
        {
            callback.Invoke(www.error);
        }
        else
        {
            preInput = txtInput;
            preResponse = www.downloadHandler.text;
            callback.Invoke(www.downloadHandler.text);
        }
    }


    IEnumerator Generate(string txtInput, Action<string> callback)
    {
        WWWForm form = new WWWForm();
        form.AddField("text", txtInput.Trim());
        panel.localScale = new Vector3(1, 1);
        UnityWebRequest www = UnityWebRequest.Post(IMAGE_URL, form);
        yield return www.SendWebRequest();

        panel.localScale = new Vector3(0, 0);
        if (www.result != UnityWebRequest.Result.Success)
        {
            callback.Invoke(www.error);
        }
        else
        {
            callback.Invoke(www.downloadHandler.text);
        }
    }
}
