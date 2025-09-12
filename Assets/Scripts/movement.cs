using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class movement : MonoBehaviour
{
    public float moveSpeed = 5f; // How fast the player moves between nodes

    // Reference to the next level to load
    public string levelToLoad = "Level1";

    private Vector3 targetPosition; // Position to move towards

    void Start()
    {
        // Start at current position
        targetPosition = transform.position;
    }

    void Update()
    {
        // Movement with arrow keys (basic for now)
        if (Keyboard.current.rightArrowKey.isPressed)
        {
            targetPosition += Vector3.right * moveSpeed * Time.deltaTime; // Move right
        }
        if (Keyboard.current.leftArrowKey.isPressed)
        {
            targetPosition += Vector3.left * moveSpeed * Time.deltaTime; // Move left
        }
        if (Keyboard.current.upArrowKey.isPressed)
        {
            targetPosition += Vector3.up * moveSpeed * Time.deltaTime; // Move up
        }
        if (Keyboard.current.downArrowKey.isPressed)
        {
            targetPosition += Vector3.down * moveSpeed * Time.deltaTime; // Move down
        }

        // Smooth movement towards target
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);

        // Enter the level when pressing Space (you can change to Enter)
        if (Keyboard.current.spaceKey.isPressed) 
        {
            Debug.Log("Entering Level: " + levelToLoad);
            SceneManager.LoadScene(levelToLoad); // Loads a level scene
        }
    }
}
