using UnityEngine;

public class BossArena : MonoBehaviour
{
    public static bool playerInArena = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInArena = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInArena = false;
        }
    }
}
