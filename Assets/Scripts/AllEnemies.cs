using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class AllEnemies : MonoBehaviour
{
    public static AllEnemies instance = null;
    public FollowThePath[] enemiesFollowingPath;
    public int moveSpeed;

    private void Start()
    {
        instance = this;
    }

    public void AlertEnemies()
    {
        foreach (var enemy in enemiesFollowingPath)
        {
            enemy.moveSpeed = moveSpeed;
        }
    }
}
