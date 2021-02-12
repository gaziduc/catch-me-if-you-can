using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Win : MonoBehaviour
{
    public GameObject endScreen;
    public Text scoreText;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            endScreen.SetActive(true);
            scoreText.text = "SCORE: " + ((Inventory.instance.numKills + Inventory.instance.numTVs) * 100).ToString();
            other.gameObject.GetComponent<PlayerMove>().canMove = false;
            Time.timeScale = 0f;
        }
    }
}
