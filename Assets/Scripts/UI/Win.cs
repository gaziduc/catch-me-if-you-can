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
            scoreText.text = "100 x " + Inventory.instance.numTVs + " TVs = " + (Inventory.instance.numTVs * 100)
                             + "\n80 x " + Inventory.instance.numKills + " kills = " + (Inventory.instance.numKills * 80) +
                "\nTOTAL = " + (Inventory.instance.numTVs * 100 + Inventory.instance.numKills * 80);
            other.gameObject.GetComponent<PlayerMove>().canMove = false;
            Time.timeScale = 0f;
        }
    }
}
