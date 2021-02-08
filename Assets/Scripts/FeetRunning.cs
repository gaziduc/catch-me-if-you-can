using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FeetRunning : MonoBehaviour
{
    private Animator anim;
    
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        anim.SetBool("Moving", true);
    }
}
