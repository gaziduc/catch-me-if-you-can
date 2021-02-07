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
        if (other.gameObject.CompareTag("Knife"))
        {
            var animation = other.transform.parent.gameObject.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0);
            
            if (animation.IsName("PlayerAttackKnife"))
            {
                SwitchState();
                other.transform.parent.GetComponent<Inventory>().AddKill();
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Knife"))
        {
            var animation = other.transform.parent.gameObject.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0);
            
            if (animation.IsName("PlayerAttackKnife"))
            {
                SwitchState();
                other.transform.parent.GetComponent<Inventory>().AddKill();
            }
        }
    }
}
