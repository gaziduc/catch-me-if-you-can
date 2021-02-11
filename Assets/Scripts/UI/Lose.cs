using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lose : MonoBehaviour
{
    public GameObject losePanel;
    private PlayerMove player;

    private void Start()
    {
        GameObject go = GameObject.FindGameObjectWithTag("Player");
        
        // if not in menu
        if (go != null)
            player = go.GetComponent<PlayerMove>();
    }

    public void Loose()
    {
        player.gameObject.GetComponent<AudioSource>().Play();
        losePanel.SetActive(true);
        player.canMove = false;
        player.speed = 0;
        Time.timeScale = 0f;
    }
}
