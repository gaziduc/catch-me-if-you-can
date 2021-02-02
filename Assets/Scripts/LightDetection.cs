using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightDetection : MonoBehaviour
{
    public LayerMask layerMask;

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

            var output = JsonUtility.ToJson(Physics2D.Raycast(transform.parent.position, dirToTarget, dstToTarget, layerMask), true);
            Debug.Log(output);

            if (Physics2D.Raycast(transform.parent.position, dirToTarget, dstToTarget, layerMask))
                Debug.Log("caught");
        }
    }
}
