using UnityEngine;

public class BossProjectile : MonoBehaviour
{
    public float damage = 10f;
    public float speed = 6f;
    public float lifetime = 5f;
    
    private Vector2 direction;

    private void Start()
    {
        //Destroy projectile after set time has passed
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
            Animator playerAnimator = collision.GetComponent<Animator>();
            if (playerAnimator != null)
            {
                playerAnimator.SetTrigger("hurt");
            }
            Destroy(gameObject);
        }
    }
}