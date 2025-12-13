using UnityEngine;

public class LifeHeartEffect : MonoBehaviour
{
    private PlayerHealth playerHealth;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // Find the GameObject with the "Player" tag in the scene and get the PlayerHealth component from the game object
        playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>();
    }

    // When the player clicks on the potion in their inventory
    public void Use()
    {
        //Calls the method used to figure the game object to apply the effect to
        FindPlayer();

        // Check if the player is already at maximum lives
        if (playerHealth.currentLives >= playerHealth.maxLives)
        {
            // Exit the method early without destroying the heart
            return;
        }
        else
        {
            // Add one life to the player's current lives
            playerHealth.currentLives++;
            // Call the UpdateLivesUI method to visually show the new heart gained
            playerHealth.UpdateLivesUI();
            // Destroy this heart object since it's been used
            Destroy(gameObject);
        }
    }

    void FindPlayer()
    {
        GameObject playerObject = GameObject.FindGameObjectWithTag("Player");
        if (playerObject != null)
        {
            //Gets the players health so that it can be adjusted by the effect
            playerHealth = playerObject.GetComponent<PlayerHealth>();
        }
    }
}
