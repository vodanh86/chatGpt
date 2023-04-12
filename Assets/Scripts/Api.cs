using UnityEngine;
using System;
using UnityEngine.Networking;
using System.Collections;
using UnityEngine.UI;

public class Api : MonoBehaviour
{
    string preInput = "";
    string preResponse = "";

    //string URL = "http://27.71.226.7:8000/api/getChat";

    string URL = "http://localhost:8000/api/getChat";

    public void CallApi(string txtInput, Action<string> callback)
    {
        StartCoroutine(Upload(txtInput, callback));
    }

    IEnumerator Upload(string txtInput, Action<string> callback)
    {
        WWWForm form = new WWWForm();
        form.AddField("text", txtInput.Trim());
        form.AddField("preInput", preInput);
        form.AddField("preResponse", preResponse);

        UnityWebRequest www = UnityWebRequest.Post(URL, form);
        yield return www.SendWebRequest();

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
}
