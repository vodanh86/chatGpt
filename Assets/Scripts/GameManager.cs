using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public TMP_InputField TxtInput;

    // Start is called before the first frame update
    void Start()
    {
        TxtInput.text = LocalStorage.GetInput();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
