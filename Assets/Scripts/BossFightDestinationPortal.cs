using UnityEngine;

public class BossFightDestinationPortal : MonoBehaviour
{
    private Animator animator;
    private SpriteRenderer spriteRenderer;              
    private SpriteRenderer playerSprite;

    void Start()
    {
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        
        // Hide the portal initially
        if (spriteRenderer != null)
        {
            spriteRenderer.enabled = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Player"))
        {
            return;
        }

        playerSprite = collision.GetComponent<SpriteRenderer>();

        // Hide player sprite when it reaches the portal
        if (playerSprite != null)
        {
            playerSprite.enabled = false;
        }

        ActivatePortal();
    }

    private void ActivatePortal()
    {
        if (spriteRenderer != null) 
        {
            spriteRenderer.enabled = true;
        }
        

        if (animator != null && spriteRenderer.enabled == true)
        {
            animator.SetTrigger("Appear");
        }
    }

    public void SetToIdle()
    {
        if (animator != null)
        {
            animator.SetTrigger("Idle");
        }
    }

    public void SpawnPlayerFromPortal()
    {
        if (playerSprite != null)
        {
            Debug.Log("Spawning player from portal");
            playerSprite.enabled = true;
        }
    }
}
