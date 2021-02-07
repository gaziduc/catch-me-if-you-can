using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class AllEnemies : MonoBehaviour
{
    public static AllEnemies instance = null;
    public FollowThePath[] enemiesFollowingPath;
    public int moveSpeed;
    public GameObject redSquare;

    private AudioSource audio;
    
    private void Start()
    {
        instance = this;
        audio = GetComponent<AudioSource>();
    }

    public void AlertEnemies()
    {
        audio.Play();
        
        foreach (var enemy in enemiesFollowingPath)
        {
            enemy.moveSpeed = moveSpeed;
            enemy.transform.GetChild(1).gameObject.SetActive(true);
        }
        
        redSquare.SetActive(true);
    }
}
