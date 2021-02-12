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
    
    private void Awake()
    {
        instance = this;
    }

    private void SetAlertText()
    {
        text.transform.parent.gameObject.SetActive(true);
        if (alert >= 99)
            text.text = "ALERT! 99";
        else
            text.text = "ALERT! " + alert;
        text.color = Color.red;
    }
    
    private void SetWarningText()
    {
        text.transform.parent.gameObject.SetActive(true);
        if (warning >= 99)
            text.text = "WARNING! 99";
        else
            text.text = "WARNING! " + warning;
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
                    SetAlertText();
                }
                else if (warning > 0)
                {
                    if (warning == 110)
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
                    SetWarningText();
                }
                else if (text.gameObject.activeInHierarchy)
                {
                    AllEnemies.instance.ResetEnemiesState();

                    text.transform.parent.gameObject.SetActive(false);

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
            
        
        alert = 110;
        warning = 110;
        SetAlertText();
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
        
        warning = 110;
        SetWarningText();
    }
}
