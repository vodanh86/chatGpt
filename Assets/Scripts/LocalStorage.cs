using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class LocalStorage 
{
    public static void SetInput(string value)
    {
        PlayerPrefs.SetString("myInputString", value);
    }
    public static string GetInput()
    {
        return PlayerPrefs.GetString("myInputString");
    }
}
