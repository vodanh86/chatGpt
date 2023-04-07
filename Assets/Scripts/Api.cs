using UnityEngine;
using System;
using UnityEngine.Networking;
using System.Collections;
using UnityEngine.UI;

public class Api : MonoBehaviour
{
    public void CallApi(string txtInput, Action callback)
    {
        Debug.Log(3);
        StartCoroutine(Upload(txtInput, callback));
        Debug.Log(4);
    }

    IEnumerator Upload(string txtInput, Action callback)
    {
        WWWForm form = new WWWForm();
        form.AddField("text", txtInput);

        UnityWebRequest www = UnityWebRequest.Post("http://localhost:8000/api/getResult", form);
        yield return www.SendWebRequest();

        if (www.result != UnityWebRequest.Result.Success)
        {
            Debug.Log(www.error);
        }
        else
        {
            Debug.Log(www.downloadHandler.text);
            callback.Invoke();
        }
    }
}
