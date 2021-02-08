using UnityEngine;

public class Water : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            PlayerMove player = other.gameObject.GetComponent<PlayerMove>();
            player.speed = player.speed / 2;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            PlayerMove player = other.gameObject.GetComponent<PlayerMove>();
            player.speed = player.speed * 2;
        }
    }
}
