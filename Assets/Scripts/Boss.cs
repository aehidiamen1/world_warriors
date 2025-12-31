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
    public bool hasTriggeredSecondAirAttack = false;

    public float maxHealth = 100f;
    public float currentHealth;

    public float AirAttackActivation = 50f;
    public float SecondAirAttackActivation = 25f;
    public Transform skyPoint;
    public GameObject projectilePrefab;
    public int projectileAmount = 16;
    public float projectileSpeed = 6f;

    public Vector2 startAirAttackPosition;
    public bool shouldDescend = false;
    
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
                Animator playerAnimator = hit.GetComponent<Animator>();
                if (playerAnimator != null)
                {
                    playerAnimator.SetTrigger("hurt");
                }
            }
        }
    }

    public void ShootProjectilesRadially()
    {
        if (projectilePrefab == null)
        {
            Debug.LogError("Projectile prefab is missing");
            return;
        }

        float startAngle = 180f;
        float endAngle = 360f;
        
        for (int i = 0; i < projectileAmount; i++)
        {
            // Calculate angle
            float t = i / (float)(projectileAmount - 1);
            float angle = Mathf.Lerp(startAngle, endAngle, t);
            float angleRad = angle * Mathf.Deg2Rad;
            
            // Calculate direction
            Vector2 direction = new Vector2(Mathf.Cos(angleRad), Mathf.Sin(angleRad));
            
            // Spawn offset to prevent collision with the boss
            Vector3 spawnPos = transform.position + (Vector3)(direction * 1f);
            
            // Create projectile
            GameObject proj = Instantiate(projectilePrefab, spawnPos, Quaternion.identity);
            
            BossProjectile projectile = proj.GetComponent<BossProjectile>();
            if (projectile != null)
            {
                projectile.SetupProjectile(direction, projectileSpeed);
            }
        }
    }

    public void StartDescending()
    {
        shouldDescend = true;
    }

    
    void OnDrawGizmosSelected()
    {
        // Draw melee reach distance in editor
        Gizmos.DrawWireSphere(attackPoint.position, attackRadius);
    }
}
