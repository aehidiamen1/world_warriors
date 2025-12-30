using UnityEngine;

public class Boss : MonoBehaviour
{
    public Transform player;

    public bool isFlipped = false;

    public float meleeDamage = 10f;
    public Transform attackPoint;
    public float attackRadius = 0.8f;

    public Animator animator;
    public bool hasTriggeredAirAttack = false;

    public float maxHealth = 100f;
    public float currentHealth;

    public float AirAttackActivation = 50f;
    public Transform skyPoint;
    public GameObject projectilePrefab;
    public int projectileAmount = 16;
    public float projectileSpeed = 6f;

    private void Awake()
    {
        // Set the boss health
        currentHealth = maxHealth;
    }

    public void TakeDamage(float damage)
    {
        // Reduce health of the boss if damaged by the player
        currentHealth -= damage;
        Debug.Log("Boss damaged, reducing health");

        // Trigger air attack if health drops below a set amount
        if (!hasTriggeredAirAttack && currentHealth <= AirAttackActivation)
        {
            hasTriggeredAirAttack = true;
            animator.SetTrigger("AirAttack");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Check if the object that hit the enemy is a projectile
        if (collision.CompareTag("Projectile"))
        {
            // Destroy the projectile
            Destroy(collision.gameObject);
            //Reduce enemy health when hit
            currentHealth -= 10;
        }
    }

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

    public void ShootProjectilesRadially()
    {
        float startAngle = 180f;
        float endAngle = 360f;
        float angleStep = (endAngle - startAngle) / (projectileAmount - 1);
        float angle = startAngle;

        for (int i = 0; i < projectileAmount; i++)
        {
            float directionInX = Mathf.Cos(angle * Mathf.Deg2Rad);
            float directionInY = Mathf.Sin(angle * Mathf.Deg2Rad);

            Vector2 shootdirection = new Vector2(directionInX, directionInY).normalized;

            GameObject projectile = Instantiate(projectilePrefab, transform.position, Quaternion.identity);
            BossProjectile bossProjectile = projectile.GetComponent<BossProjectile>();
            
            if (bossProjectile != null)
            {
                bossProjectile.direction = shootdirection;
                bossProjectile.speed = projectileSpeed;
            }

            angle += angleStep;
        }
    }
    
    void OnDrawGizmosSelected()
    {
        // Draw melee reach distance in editor
        Gizmos.DrawWireSphere(attackPoint.position, attackRadius);
    }
}
