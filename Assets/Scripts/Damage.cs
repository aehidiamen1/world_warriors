using UnityEngine;

public class Damage : MonoBehaviour
{
    [SerializeField]
    private FloatSO healthSO;
    public float damage;

    private void OnTriggerEnter2D(Collider2D other)
    {
        //Checks if the player has collided with the obstacle and reduces the players health
        PlayerHealth playerHealth = other.gameObject.GetComponent<PlayerHealth>();

        // If the player collides with an enemy, check if the enemy is already dead. If it is, don't damage the player.
        if (other.gameObject.layer == LayerMask.NameToLayer("Enemy"))
        {
            if (other.GetComponent<EnemyHealth>() != null && other.GetComponent<EnemyHealth>().isDead)
            {
                return;
            }
        }

        // Play hurt animation
        Animator playerAnimator = other.GetComponent<Animator>();
            if (playerAnimator != null)
            {
                playerAnimator.SetTrigger("hurt");
            }
        
        if (playerHealth != null)
        {
            playerHealth.TakeDamage(damage);
        }
    }
}
