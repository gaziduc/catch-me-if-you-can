using UnityEngine;

public class PanelOpener : MonoBehaviour
{
    public GameObject panel;


    public void OpenPanel()
    {
        if (panel != null)
        {
            Animator anim = panel.GetComponent<Animator>();

            if (anim != null)
            {
                bool isOpen = anim.GetBool("Open");
                anim.SetBool("Open", !isOpen);
            }
        }
    }
}
