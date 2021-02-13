using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchComponent : MonoBehaviour
{
    public GameObject component;
    public Sprite newSprite;
    public bool HasToCut;
    private SpriteRenderer spriteRenderer;
    private AudioSource sound;

    private bool hasSwitchedState = false;
    
    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        sound = GetComponent<AudioSource>();
    }

    private void SwitchState()
    {
        if (!hasSwitchedState)
        {
            sound.Play();
            component.SetActive(false);
            spriteRenderer.sprite = newSprite;

            hasSwitchedState = true;
        }
    }

    private void PlayerCut(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (!HasToCut)
            {
                SwitchState();
                return;
            }

            var animation = other.gameObject.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0);
            
            if (animation.IsName("PlayerAttackKnife"))
            {
                SwitchState();
            }
        }
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        PlayerCut(other);
        
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        PlayerCut(other);
    }
}
