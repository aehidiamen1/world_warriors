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

    public void SetupProjectile(Vector2 dir, float spd)
    {
        direction = dir.normalized;
        speed = spd;
        
        // Rotate the projectile to face the direction it's moving
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, angle);
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

        // Destroy if it moves to far away
        Destroy(gameObject, 10f);
    }
}