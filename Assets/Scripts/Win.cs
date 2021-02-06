using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Win : MonoBehaviour
{
    public GameObject endScreen;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            endScreen.SetActive(true);
            other.gameObject.GetComponent<PlayerMove>().canMove = false;
            Time.timeScale = 0f;
        }
    }
}
