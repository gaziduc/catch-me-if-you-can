using UnityEngine;

public class PanelOpener : MonoBehaviour
{
    public GameObject settingsPanel;
    public GameObject helpPanel;
    public GameObject levelsPanel;

    public void OpenSettingsPanel()
    {
        if (settingsPanel != null)
        {
            Animator anim = settingsPanel.GetComponent<Animator>();

            if (anim != null)
            {
                bool isOpen = anim.GetBool("Open");
                anim.SetBool("Open", !isOpen);
            }
        }
    }
    
    public void OpenLevelsPanel()
    {
        if (levelsPanel != null)
        {
            Animator anim = levelsPanel.GetComponent<Animator>();

            if (anim != null)
            {
                bool isOpen = anim.GetBool("Open");
                anim.SetBool("Open", !isOpen);
            }
        }
    }

    public void OpenHelpPanel()
    {
        if (helpPanel != null)
        {
            Animator anim = helpPanel.GetComponent<Animator>();

            if (anim != null)
            {
                bool isOpen = anim.GetBool("Open");
                anim.SetBool("Open", !isOpen);
            }
        }
    }
}
