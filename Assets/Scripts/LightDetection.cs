using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightDetection : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("player");
            Transform target = other.transform;

            Vector2 dirToTarget = (target.position - transform.parent.position).normalized;
            float dstToTarget = Vector2.Distance(transform.parent.position, target.position);

            Debug.Log(dstToTarget);
            Debug.Log(dirToTarget);

            Debug.DrawRay(transform.parent.position, dirToTarget * dstToTarget, Color.blue, 5);

            RaycastHit2D hit = Physics2D.Raycast(transform.parent.position, dirToTarget, dstToTarget);

            if (hit.collider.gameObject.CompareTag("Player"))
            {
                Debug.Log("Caught");
            }
        }
    }
}
