using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using TMPro;

public class ImageController : MonoBehaviour
{
    // Start is called before the first frame update
    public TMP_Text TxtInput;
    public Api objApi;

    public RawImage generatedRawImage;
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GenerateImage(){
        if (string.IsNullOrWhiteSpace(TxtInput.text)){
            return;
        }
        
        Debug.Log(TxtInput.text);
        LocalStorage.SetInput(TxtInput.text);

        objApi.GenerateImage(TxtInput.text, (string result) => {
            Debug.Log(result);
            StartCoroutine(DownloadImage(result));
        });
    }

    IEnumerator DownloadImage(string MediaUrl)
    {   
        UnityWebRequest request = UnityWebRequestTexture.GetTexture(MediaUrl);
        yield return request.SendWebRequest();
        if(request.isNetworkError || request.isHttpError) 
            Debug.Log(request.error);
        else
            generatedRawImage.texture = ((DownloadHandlerTexture) request.downloadHandler).texture;
    } 
}
