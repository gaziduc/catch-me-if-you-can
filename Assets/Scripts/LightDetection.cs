using UnityEngine;

public class LightDetection : MonoBehaviour
{
    private Lose lose;
    
    private void Start()
    {
        lose = GameObject.Find("LoseManager").GetComponent<Lose>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            HitTarget(other);
        }
    }
    
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            HitTarget(other);
        }
    }

    void HitTarget(Collider2D other)
    {
        Transform target = other.transform;

        Vector2 dirToTarget = (target.position - transform.parent.position).normalized;
        float dstToTarget = Vector2.Distance(transform.parent.position, target.position);
            
        //Debug.DrawRay(transform.parent.position, dirToTarget * dstToTarget, Color.blue, 5);

        RaycastHit2D hit = Physics2D.Raycast(transform.parent.position, dirToTarget, dstToTarget);

        if (hit.collider.gameObject.CompareTag("Player"))
        {
            hit.collider.gameObject.GetComponent<PlayerMove>().canMove = false;
            lose.Loose();
        }
    }
}
