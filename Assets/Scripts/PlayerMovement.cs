using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f;
    public float jumpForce = 7f;
    public float climbSpeed = 3f;
    public float jumpOffForce = 5f;

    private Rigidbody2D rb;
    private Animator animator;
    private SpriteRenderer spriteRenderer;

    private bool isGrounded = true;
    private bool isClimbing = false;
    private bool isOnLadder = false;
    private float originalGravityScale;

    public CoinManager CoinManager;
    private Vector2 movement;

    public GameObject attackPoint;
    public float radius;
    public LayerMask enemies;
    public float damage;
    public bool isSpeedBoosted;
    private float originalSpeed;

    public ProjectileBehaviour ProjectilePrefab;
    public Transform LaunchOffset;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        

        //Store original gravity so that it it can be changed
        originalGravityScale = rb.gravityScale;
    }

    void Update()
    {
        // Movement controls
        movement.x = Input.GetAxisRaw("Horizontal"); // left and right
        movement.y = Input.GetAxisRaw("Vertical"); // up and down

        //Player is climbing the ladder
        LadderClimbing();

        // Set animator parameter
        bool isWalking = movement.x != 0 && !isClimbing;
        animator.SetBool("isWalking", isWalking);

        // Flip sprite left/right
        if (movement.x > 0)
        {
            transform.rotation = Quaternion.Euler(0f, 0f, 0f); // Facing right
        }
        else if (movement.x < 0)
        {
            transform.rotation = Quaternion.Euler(0f, 180f, 0f); // Facing left
        }
        
        // Player is jumping either off a ladder or just jumping in general
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded && !isClimbing)
        {
            Jump();
        }
        else if (Input.GetKeyDown(KeyCode.Space) && isClimbing)
        {
            //Runs the jumping off the ladder method
            JumpOffLadder();
        }

        if (Input.GetMouseButtonDown(0))
        {
            animator.SetBool("isAttacking", true);
        }

        // Update vertical velocity for fall animation
        animator.SetFloat("VelocityY", rb.linearVelocity.y);
        animator.SetBool("isGrounded", isGrounded);


        //Launching the projectile
        if (Input.GetKeyDown(KeyCode.F))
        {
            animator.SetTrigger("Shoot");
        }
    }

    void FixedUpdate()
    {
        // The player is climbing the ladder
        if (isClimbing)
        {
            // Move up and down on the ladder
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, movement.y * climbSpeed);
        }
        else
        {
            // Normal horizontal movement
            rb.linearVelocity = new Vector2(movement.x * speed, rb.linearVelocity.y);
        }
    }

    // Entering, exiting, climbing and moving on the ladder
    void LadderClimbing()
    {
        // Call the StartClimbing method if the player is pressing up whilst on the ladder
        if (isOnLadder && !isClimbing && movement.y > 0)
        {
            StartClimbing();
        }

        // Exit climbing when touching the ground or walking off the ladder
        if (isClimbing && isGrounded && (!isOnLadder || movement.x > 0.1f || movement.x < -0.1f))
        {
            ExitClimbing();
        }

        // if no input is pressed when the player is still on the ladder the climb animation should pause
        if (isClimbing)
        {
            if (movement.y > 0.01f || movement.y < -0.01f)
            {
                animator.speed = 1f; // Play animation
            }
            else
            {
                animator.speed = 0f; // Pause animation (stick in place)
            }
        }
        else
        {
            // Make sure animation speed is normal when not climbing
            animator.speed = 1f;
        }
    }

    // Climbing the ladder
    void StartClimbing()
    {
        isClimbing = true;
        rb.gravityScale = 0f; 
        rb.linearVelocity = Vector2.zero; 
        animator.SetBool("isClimbing", true);
        animator.speed = 1f; 
    }

    // Exiting the ladder
    void ExitClimbing()
    {
        isClimbing = false;
        rb.gravityScale = originalGravityScale; // Restore gravity back to what it was before the player entered the ladder
        animator.SetBool("isClimbing", false);
        animator.speed = 1f; 
    }

    // Jumping off the ladder
    void JumpOffLadder()
    {
        ExitClimbing();
        rb.linearVelocity = new Vector2(movement.x * jumpOffForce, jumpOffForce);
        animator.SetTrigger("jump");
    }

    //Player jumping
    void Jump()
    {
        rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        animator.SetTrigger("jump");
        isGrounded = false;
    }

    // Checks if player is on the ground
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.contacts[0].normal.y > 0.5f)
        {
            isGrounded = true;
        }
    }

    // Checks if the player is within the ladder's box collider
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Ladder"))
        {
            isOnLadder = true;
        }

        //Checks if the player has interacted with a coin
        if (collision.CompareTag("Coin"))
        {
            Destroy(collision.gameObject);
            CoinManager.coinCount++;
        }
    }

    // Checks if the player has left the ladder's box collider
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Ladder"))
        {
            isOnLadder = false;
            if (isClimbing)
            {
                ExitClimbing();
            }
        }
    }

    public void attack()
    {
        Collider2D[] enemy = Physics2D.OverlapCircleAll(attackPoint.transform.position, radius, enemies);

        foreach (Collider2D enemyGameObject in enemy)
        {
            Debug.Log("Hit enemy");
            enemyGameObject.GetComponent<EnemyHealth>().health -= damage;
        }
    }

    public void endAttack()
    {
        animator.SetBool("isAttacking", false);
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(attackPoint.transform.position, radius);
    }

    public System.Collections.IEnumerator SpeedBoost(float multiplier, float duration)
    {
        isSpeedBoosted = true;
        // Save the player's current speed before changing it
        originalSpeed = speed;
        speed = originalSpeed * multiplier;
        
        // Wait for the set duration (10 seconds)
        yield return new WaitForSeconds(duration);
        //Change the player's speed back to the original
        speed = originalSpeed;

        isSpeedBoosted = false;
    }

    public void SpawnProjectile()
    {
        Instantiate(ProjectilePrefab, LaunchOffset.position, transform.rotation);
    }
}