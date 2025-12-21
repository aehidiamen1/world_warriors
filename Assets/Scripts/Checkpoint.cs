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
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = greySprite;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!isActivated && other.CompareTag("Player"))
        {
            playerHealth.UpdateCheckpoint(transform.position);
            isActivated = true;
            spriteRenderer.sprite = coloredSprite;
            checkpointCollider.enabled = false;
            Debug.Log("Checkpoint activated!");
        }
    }
}
