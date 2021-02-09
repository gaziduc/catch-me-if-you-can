using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using Debug = System.Diagnostics.Debug;

public class FOV : MonoBehaviour
{
    public float viewRadius = 5;
    public float viewAngle = 115;
    public LayerMask obstacleMask, detectionMask;
    public Collider2D[] targetsInRadius;

    private void FixedUpdate()
    {
        FindTargets();
    }

    void FindTargets()
    {
        targetsInRadius = Physics2D.OverlapCircleAll(transform.position,
            viewRadius,
            detectionMask,
            -Mathf.Infinity,
            Mathf.Infinity);

        for (int i = 0; i < targetsInRadius.Length; i++)
        {
            Transform target = targetsInRadius[i].transform;

            if (target.gameObject.CompareTag("CollisionTiles"))
            {
                continue;
            }
            
            Vector2 dirTarget = new Vector2(target.position.x - transform.position.x, target.position.y - transform.position.y);
            Vector2 dir = new Vector2();
            
            dir = transform.right;

            if (Vector2.Angle(dirTarget, dir) < viewAngle / 2)
            {
                float distanceTarget = Vector2.Distance(transform.position, target.position);

                UnityEngine.Debug.DrawRay(transform.position, dirTarget, Color.red);
                var hit = Physics2D.Raycast(transform.position, dirTarget, distanceTarget, obstacleMask);

                if (hit)
                {
                    if (hit.collider.CompareTag("Player"))
                    {
                        UnityEngine.Debug.Log("Enter loose manager: " + gameObject.transform.parent.name);
                        UnityEngine.Debug.Log(hit.collider);
                        GameObject.Find("LoseManager").GetComponent<Lose>().Loose();
                    }
                    else if (hit.collider.CompareTag("BloodSplash"))
                    {
                        if (!AllEnemies.instance.isInAlert)
                            AllEnemies.instance.AlertEnemies();
                    }
                }
            }
        }
    }

    public Vector2 DirFromAngle(float angleDeg, bool global)
    {
        if (!global)
            angleDeg += transform.eulerAngles.z;
        
        return new Vector2(Mathf.Cos(angleDeg * Mathf.Deg2Rad), Mathf.Sin(angleDeg * Mathf.Deg2Rad));
    }
}