    using UnityEngine;

    public class BossFightDestinationPortal : MonoBehaviour
    {
        private Animator animator;
        private SpriteRenderer spriteRenderer;              
        private SpriteRenderer playerSprite;
        private Rigidbody2D playerRigidbody;
        private PlayerMovement playerMovement;

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

            playerRigidbody = collision.GetComponent<Rigidbody2D>();
            
            // Stop player movement and freeze them in place
            if (playerRigidbody != null)
            {
                playerRigidbody.linearVelocity = Vector2.zero;
                playerRigidbody.constraints = RigidbodyConstraints2D.FreezeAll;
            }

            playerMovement = collision.GetComponent<PlayerMovement>();

            if (playerMovement != null)
            {
                playerMovement.enabled = false;
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
            // Make player visible when spawned from the portal
            if (playerSprite != null)
            {
                Debug.Log("Spawning player from portal");
                playerSprite.enabled = true;
            }

            // Enable player movement
            if (playerMovement != null)
            {
                playerMovement.enabled = true;
            }

            // Unfreeze player movement
            if (playerRigidbody != null)
            {
                playerRigidbody.constraints = RigidbodyConstraints2D.FreezeRotation;
            }
        }
    }
