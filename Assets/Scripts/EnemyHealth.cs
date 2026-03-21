using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public float health;
    public float currentHealth;
    private Animator animator;
    private enemy_patrol patrolScript;
    private Rigidbody2D rb;
    private bool isDead = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        animator = GetComponent<Animator>();
        currentHealth = health;
        patrolScript = GetComponent<enemy_patrol>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //Method doesn't run if enemy is already dead
        if (isDead) return;

        if (health < currentHealth)
        {
            currentHealth = health;
            animator.SetTrigger("Attacked");
        }

        if (health <= 0)
        {
            Die();
        }
    }

    // Detect when projectile hits the enemy
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Check if the object that hit the enemy is a projectile
        if (collision.CompareTag("Projectile"))
        {
            // Destroy the projectile
            Destroy(collision.gameObject);
            //Reduce enemy health when hit
            health -= 10;
        }
    }

    //Stop moving when the enemy dies
    private void Die()
        {
            isDead = true;
            animator.SetBool("isDead", true);

            if (patrolScript != null)
            {
                patrolScript.enabled = false;
            }
            rb.linearVelocity = Vector2.zero;

            Collider2D enemyCollider = GetComponent<Collider2D>();
            if (enemyCollider != null)
            {
                enemyCollider.enabled = false;
            }

            Debug.Log("Enemy is dead");
        }
}
