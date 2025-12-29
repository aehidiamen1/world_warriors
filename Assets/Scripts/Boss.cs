using UnityEngine;

public class Boss : MonoBehaviour
{
    public Transform player;

    public bool isFlipped = false;

    public float meleeDamage = 10f;
    public float meleeReachDistance = 2f;

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
        // Calculate how far away the player is
        float distanceToPlayer = Vector2.Distance(transform.position, player.position);
        
        // If player is close enough, hit them
        if (distanceToPlayer <= meleeReachDistance)
        {
            Debug.Log("Boss melee attack hit the player!");
            player.GetComponent<PlayerHealth>().TakeDamage(meleeDamage);
        }
        else
        {
            Debug.Log("Boss melee attack missed the player!");
        }
    }
    
    void OnDrawGizmosSelected()
    {
        // Draw melee reach distance in editor
        Gizmos.DrawWireSphere(transform.position, meleeReachDistance);
    }
}
