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
        // Check if the player is already at max health
        if (playerHealth.health >= playerHealth.maxHealth)
        {            
            // Exit the method early without destroying the potion
            return;
        }
        else
        {
            // Add the health amount directly to the player's health
            playerHealth.health += healthAmount;

            // Destroy this potion since it's been used by the player
            Destroy(gameObject);                
        }
    }
}