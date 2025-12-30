using UnityEngine;

public class BossProjectile : MonoBehaviour
{
    public float damage = 10f;

    public Vector2 direction;
    public float speed = 6f;

    private void Update()
    {
        // Move the projectile
        transform.position += (Vector3)(direction * speed * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Check if the projectile hit the player
        PlayerHealth player = collision.collider.GetComponent<PlayerHealth>();

        if (player != null)
        {
            // Deal damage to the player
            player.TakeDamage(damage);
        }

        //Destroy the projectile on impact with any gameobject
        Destroy(gameObject);
    }
}