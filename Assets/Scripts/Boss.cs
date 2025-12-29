using UnityEngine;

public class Boss : MonoBehaviour
{
    public Transform player;

    public bool isFlipped = false;

    public float meleeDamage = 10f;
    public Transform attackPoint;
    public float attackRadius = 0.8f;

    public void LookAtPlayer()
    {
        Vector3 flipped = transform.localScale;

        flipped.z *= -1f;

        if (transform.position.x > player.position.x && isFlipped)
        {
            transform.localScale = flipped;
            transform.Rotate(0f, 180f, 0f);
            isFlipped = false;
        }
        else if (transform.position.x < player.position.x && !isFlipped)
        {
            transform.localScale = flipped;
            transform.Rotate(0f, 180f, 0f);
            isFlipped = true;
        }
    }

    public void DealMeleeDamage()
    {
        // Check if player is in attack range
        Collider2D[] hits = Physics2D.OverlapCircleAll(attackPoint.position, attackRadius);

        // Deal damage to player if hit
        foreach (Collider2D hit in hits)
        {
            PlayerHealth playerHealth = hit.GetComponent<PlayerHealth>();

            if (playerHealth != null)
            {
                Debug.Log("Boss melee attack hit the player!");
                playerHealth.TakeDamage(meleeDamage);
            }
        }
    }
    
    void OnDrawGizmosSelected()
    {
        // Draw melee reach distance in editor
        Gizmos.DrawWireSphere(attackPoint.position, attackRadius);
    }
}
