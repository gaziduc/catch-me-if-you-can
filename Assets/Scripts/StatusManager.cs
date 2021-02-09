using UnityEngine;
using UnityEngine.UI;

public class StatusManager : MonoBehaviour
{
    public Text text;
    public int alert = 0;
    public int warning = 0;
    private int framecount = 0;

    public static StatusManager instance;
    
    public AudioSource spottedMusic;
    public AudioSource warningMusic;
    public AudioSource music;
    
    private void Start()
    {
        instance = this;
    }

    private void SetAlertText(int alert)
    {
        text.gameObject.SetActive(true);
        text.text = "Alert! " + alert;
        text.color = Color.red;
    }
    
    private void SetWarningText(int alert)
    {
        text.gameObject.SetActive(true);
        text.text = "Warning! " + warning;
        text.color = new Color(1f, 0.5f, 0f, 1f);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // If not in menu
        if (text != null)
        {
            if (framecount % 6 == 0)
            {
                if (alert > 0)
                {
                    alert--;
                    SetAlertText(alert);
                }
                else if (warning > 0)
                {
                    if (warning == 99)
                    {
                        if (music.isPlaying)
                            music.Stop();
                        if (spottedMusic.isPlaying)
                            spottedMusic.Stop();
                        if (!warningMusic.isPlaying)
                            warningMusic.Play();
                        AllEnemies.instance.WarnEnemies();
                    }
                        
                    
                    warning--;
                    SetWarningText(warning);
                }
                else if (text.gameObject.activeSelf)
                {
                    AllEnemies.instance.ResetEnemiesState();

                    text.gameObject.SetActive(false);

                    if (spottedMusic.isPlaying)
                        music.Stop();
                    if (warningMusic.isPlaying)
                        warningMusic.Stop();

                    music.Play();
                }

            }

            framecount++;
        }
    }

    public void Alert99()
    {
        if (alert == 0)
        {
            if (music.isPlaying)
                music.Stop();
            if (warningMusic.isPlaying)
                warningMusic.Stop();
            
            spottedMusic.Play();
        }
            
        
        alert = 99;
        warning = 99;
        SetAlertText(alert);
    }
    
    public void Warning99()
    {
        if (alert > 0)
            return;

        if (warning == 0)
        {
            if (music.isPlaying)
                music.Stop();
            if (spottedMusic.isPlaying)
                spottedMusic.Stop();
            
            warningMusic.Play();
        }
        
        warning = 99;
        SetWarningText(warning);
    }
}
