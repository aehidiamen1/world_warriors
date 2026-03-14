using UnityEngine;

public class ChangeJumpForce : MonoBehaviour
{
    [SerializeField] private float newJumpForce = 6f;
    private float oldJumpForce;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // Change the player's jump force when they enter the trigger
            PlayerMovement playerJump= other.GetComponent<PlayerMovement>();
            oldJumpForce = playerJump.jumpForce; // Store the old jump force
            if (playerJump != null)
            {
                playerJump.jumpForce = newJumpForce; // Set to new jump force
                Debug.Log("Jump force changed to 6!");
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // Reset the player's jump force when they exit the trigger
            PlayerMovement playerJump = other.GetComponent<PlayerMovement>();
            if (playerJump != null)
            {
                playerJump.jumpForce = oldJumpForce; // Reset to old jump force
                Debug.Log("Jump force reset to " + oldJumpForce);
            }
        }
    }
}
