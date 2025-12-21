using UnityEngine;

public class HealthPotionEffect : MonoBehaviour
{
    public float healthAmount = 50f;
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
        //Calls the method used to select the game object to apply the effect to
        FindPlayer();

        // Ensure we have a player reference
        if (playerHealth == null) return;

        // Check if the player is already at max health
        if (playerHealth.GetHealth() >= playerHealth.maxHealth)
        {
            // Exit the method early without destroying the potion
            return;
        }

        // Add the health amount
        playerHealth.AddHealth(healthAmount);

        // Destroy this potion since it's been used by the player
        Destroy(gameObject);
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