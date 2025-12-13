using UnityEngine;

public class SpeedPotionEffect : MonoBehaviour
{
    public float speedMultiplier = 1.5f;
    public float duration = 10f;
    private PlayerMovement playerMovement;
    private GameObject player;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // Find the GameObject with the "Player" tag in the scene
        player = GameObject.FindGameObjectWithTag("Player");
        // Get the PlayerMovement component from the player GameObject
        playerMovement = player.GetComponent<PlayerMovement>();
    }

    public void Use()
    {
        //Calls the method used to figure the game object to apply the effect to
        FindPlayer();

        // Check if the player already has a speed boost active
        if (playerMovement.isSpeedBoosted)
        {
            // Exit the method early without destroying the potion
            return;
        }
        else
        {
            // Start the speed boost coroutine
            playerMovement.StartCoroutine(playerMovement.SpeedBoost(speedMultiplier, duration));
            // Destroy this potion object since it's been consumed
            Destroy(gameObject);
        }
    }

    void FindPlayer()
    {
        // Find the GameObject with the "Player" tag in the scene
        player = GameObject.FindGameObjectWithTag("Player");
        // Get the PlayerMovement component from the player GameObject
        playerMovement = player.GetComponent<PlayerMovement>();
    }
}
