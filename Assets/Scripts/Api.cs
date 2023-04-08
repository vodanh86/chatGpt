using UnityEngine;
using System;
using UnityEngine.Networking;
using System.Collections;
using UnityEngine.UI;

public class Api : MonoBehaviour
{
    public void CallApi(string txtInput, Action<string> callback)
    {
        StartCoroutine(Upload(txtInput, callback));
    }

    IEnumerator Upload(string txtInput, Action<string> callback)
    {
        WWWForm form = new WWWForm();
        form.AddField("text", txtInput);

        UnityWebRequest www = UnityWebRequest.Post("http://localhost:8000/api/getResult", form);
        yield return www.SendWebRequest();

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
