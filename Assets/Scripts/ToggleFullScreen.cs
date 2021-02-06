using UnityEngine;

public class ToggleFullScreen : MonoBehaviour
{
    public void toggleFullScreen()
    {
        Screen.fullScreen = !Screen.fullScreen;
    }
}
