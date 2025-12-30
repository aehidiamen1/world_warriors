using UnityEngine;

public class BossProjectile : MonoBehaviour
{
    public float damage = 10f;
    public float speed = 6f;
    public float lifetime = 5f; // Destroy after 5 seconds
    
    private Vector2 direction;

    private void Start()
    {
        // Auto-destroy after lifetime
        Destroy(gameObject, lifetime);
    }

    public void Initialize(Vector2 dir, float spd)
    {
        direction = dir.normalized;
        speed = spd;
        
        Debug.Log("Projectile initialized - Direction: " + direction + " Speed: " + speed);
    }

    private void Update()
    {
        // Simple transform movement - no physics
        transform.position += (Vector3)(direction * speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Hit: " + collision.name);
        
        // Check if hit player
        PlayerHealth player = collision.GetComponent<PlayerHealth>();
        if (player != null)
        {
            player.TakeDamage(damage);
            Destroy(gameObject);
        }
    }
}