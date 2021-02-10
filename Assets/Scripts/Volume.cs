using UnityEngine;

public class Volume : MonoBehaviour
{
    void Start()
    {
        AudioListener.volume = PlayerPrefs.GetFloat("MasterVolume", 1f);
        Debug.Log("start " + AudioListener.volume);
    }

    private void Update()
    {
        Debug.Log(AudioListener.volume);
    }

    public void SetMasterVolume(float volume)
    {
        AudioListener.volume = volume;
        PlayerPrefs.SetFloat("MasterVolume", AudioListener.volume);
        PlayerPrefs.Save();
    }
}
