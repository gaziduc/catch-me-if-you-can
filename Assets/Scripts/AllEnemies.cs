using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class AllEnemies : MonoBehaviour
{
    public static AllEnemies instance = null;
    public FollowThePath[] enemiesFollowingPath;
    public int moveSpeed;
    public GameObject redSquare;
    public bool isInAlert;

    private AudioSource spottedMusic;
    public AudioSource music;
    
    private void Start()
    {
        instance = this;

        isInAlert = false;
        spottedMusic = GetComponent<AudioSource>();
    }

    public void AlertEnemies()
    {
        music.Stop();
        spottedMusic.Play();
        
        foreach (var enemy in enemiesFollowingPath)
        {
            enemy.moveSpeed = moveSpeed;
            enemy.transform.GetChild(1).gameObject.SetActive(true);
        }
        
        redSquare.SetActive(true);

        isInAlert = true;
    }
}
