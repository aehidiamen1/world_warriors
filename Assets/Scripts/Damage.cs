using UnityEngine;

public class Damage : MonoBehaviour
{
    public float damage;

    private void OnTriggerEnter2D(Collider2D other)
    {
        //Checks if the player has collided with the obstacle and reduces the players health
        PlayerHealth playerHealth = other.gameObject.GetComponent<PlayerHealth>();
            if (playerHealth != null)
            {
                playerHealth.health -= damage;
            }

        // Play hurt animation
        Animator playerAnimator = other.GetComponent<Animator>();
            if (playerAnimator != null)
            {
                playerAnimator.SetTrigger("hurt");
            }
    }
}
