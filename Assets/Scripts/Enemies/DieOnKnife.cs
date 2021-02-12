using UnityEngine;

public class DieOnKnife : MonoBehaviour
{
    public Object instantiate;
    public bool isDead = false;

    private void SwitchStateIfKnife(Collider2D other)
    {
        if (other.gameObject.CompareTag("Knife"))
        {
            var animation = other.transform.parent.gameObject.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0);
            
            if (animation.IsName("PlayerAttackKnife"))
            {
                isDead = true;
                GameObject.Instantiate(instantiate, transform.position, transform.rotation);
                gameObject.SetActive(false);
                Inventory.instance.AddKill();
            }
        }
        
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        SwitchStateIfKnife(other);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
       SwitchStateIfKnife(other);
    }
}
