using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    public Sprite greySprite;
    public Sprite coloredSprite;
    private SpriteRenderer spriteRenderer;
    private bool isActivated = false;

    PlayerHealth playerHealth;
    Collider2D checkpointCollider;

    private void Awake()
    {   
        playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>();
        checkpointCollider = GetComponent<Collider2D>();
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // Set initial sprite to deactivated
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = greySprite;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Activate checkpoint when player touches it
        if (!isActivated && other.CompareTag("Player"))
        {
            // Update player's respawn position
            playerHealth.UpdateCheckpoint(transform.position);
            isActivated = true;
            //Change the sprite to the activated checkpoint
            spriteRenderer.sprite = coloredSprite;
            // Disable the collider to prevent reactivation
            checkpointCollider.enabled = false;
            Debug.Log("Checkpoint activated!");
        }
    }
}
