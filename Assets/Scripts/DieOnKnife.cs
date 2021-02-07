using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DieOnKnife : MonoBehaviour
{
    public Object instantiate;

    private void SwitchState()
    {
        GameObject.Instantiate(instantiate, transform.position, transform.rotation);
        gameObject.SetActive(false);
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Stay: En collision avec l'ennemi");
            var animation = other.gameObject.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0);
            
            if (animation.IsName("PlayerAttackKnife"))
            {
                SwitchState();
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Enter: En collision avec l'ennemi");
            var animation = other.gameObject.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0);
            
            if (animation.IsName("PlayerAttackKnife"))
            {
                SwitchState();
            }
        }
    }
}
