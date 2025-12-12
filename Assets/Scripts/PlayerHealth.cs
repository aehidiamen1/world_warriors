using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public float health;
    public float minHealth;
    public float maxHealth;
    public Image healthBar;
    public int lives = 3; // Number of lives the player starts with
    public int maxLives = 3; // Maximum number of lives
    private int currentLives;
    public Image[] lifeImages;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentLives = lives;

        // If health isn't set then set to maxHealth
        if (health <= 0)
        {
            health = maxHealth;
        }

        //Ensures that the starting health is within the set boundaries
        health = Mathf.Clamp(health, minHealth, maxHealth);

        UpdateLivesUI();
    }

    // Update is called once per frame
    void Update()
    {
        //Restrict the health to min and max health
        health = Mathf.Clamp(health, minHealth, maxHealth);

        if (health <= minHealth && currentLives > 0)
        {
            LoseLife();
        }

        //Update the health bar
        healthBar.fillAmount = health / maxHealth;
    }

    void LoseLife()
    {
        currentLives--;
        
        if (currentLives > 0)
        {
            // Restore health to full
            health = maxHealth;
            Debug.Log("Life lost! Lives remaining: " + currentLives);
        }
        else
        {
            // All lives are gone
            Debug.Log("Game Over! No lives remaining.");
        }

        UpdateLivesUI();
    }

    void UpdateLivesUI()
    {
        for (int i = 0; i < lifeImages.Length; i++)
        {
            // Enable the image if we have enough lives, disable if we don't
            if (i < currentLives)
            {
                lifeImages[i].enabled = true;
            }
            else
            {
                lifeImages[i].enabled = false;
            }
        }
    }
}
