using System;
using UnityEngine;

public class Resolution : MonoBehaviour
{
    private void Start()
    {
        int w = PlayerPrefs.GetInt("Screenmanager Resolution Width", Screen.width);
        int h = PlayerPrefs.GetInt("Screenmanager Resolution Height", Screen.height);
        int isFullscreen = PlayerPrefs.GetInt("Screenmanager Fullscreen mode", 1);
        int rr = PlayerPrefs.GetInt("Screenmanager Refresh Rate", -1);
        
        if (rr == -1)
            Screen.SetResolution(w, h, isFullscreen == 1);
        else
            Screen.SetResolution(w, h, isFullscreen == 1, rr);
            
    }
}
