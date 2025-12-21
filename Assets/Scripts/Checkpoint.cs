using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    public Sprite greySprite;
    public Sprite coloredSprite;
    private SpriteRenderer spriteRenderer;
    private bool isActivated = false;

    PlayerHealth playerHealth;
    private void Awake()
    {   
        playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>();
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
            Debug.Log("Checkpoint activated!");
        }
    }
}
