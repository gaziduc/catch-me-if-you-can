using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillPlayer : MonoBehaviour
{
    private Lose loose;

    private void Start()
    {
        loose = GameObject.Find("LoseManager").GetComponent<Lose>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            loose.Loose();
        }
    }
}
