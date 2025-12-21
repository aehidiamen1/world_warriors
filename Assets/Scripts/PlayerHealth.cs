using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public float minHealth;
    public float maxHealth;
    public Image healthBar;
    public float lives = 3f;
    public float maxLives = 3f;
    public float currentLives;
    public Image[] lifeImages;

    [SerializeField]
    private FloatSO healthSO;
    [SerializeField]
    private FloatSO livesSO;

    //Set the starting position for respawn
    Vector2 CheckpointPos;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // Set the initial value of lives
        livesSO.Value = lives;
        CheckpointPos = transform.position;
        currentLives = livesSO.Value;

        // If health isn't set then set to maxHealth
        if (healthSO.Value <= 0)
        {
            healthSO.Value = maxHealth;
        }

        //Ensures that the starting health is within the set boundaries
        healthSO.Value = Mathf.Clamp(healthSO.Value, minHealth, maxHealth);

        UpdateLivesUI();
    }

    // Update is called once per frame
    void Update()
    {
        //Restrict the health to min and max health
        healthSO.Value = Mathf.Clamp(healthSO.Value, minHealth, maxHealth);

        if (healthSO.Value <= minHealth && currentLives > 0)
        {
            LoseLife();
        }

        //Update the health bar
        healthBar.fillAmount = healthSO.Value / maxHealth;
    }

    void LoseLife()
    {
        //Decrease lives by 1
        currentLives--;
        livesSO.Value = currentLives;
        
        if (currentLives > 0)
        {
            // Restore health to full
            healthSO.Value = maxHealth;
            Debug.Log("Life lost! Lives remaining: " + currentLives);
        }
        else
        {
            // All lives are gone
            Debug.Log("Game Over! No lives remaining.");
        }

        // Respawn the player at the starting position

        StartCoroutine(Respawn(1f));

        UpdateLivesUI();
    }

    public void UpdateLivesUI()
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

    IEnumerator Respawn(float delay)
    {
        yield return new WaitForSeconds(delay);
        transform.position = CheckpointPos;
    }

    public void UpdateCheckpoint(Vector2 pos)
    {
        CheckpointPos = pos;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Checks if the player has fallen into a death zone
        if (collision.CompareTag("DeathZone"))
        {
            // Play death animation
            Animator playerAnimator = GetComponent<Animator>();
            if (playerAnimator != null)
            {
                playerAnimator.SetTrigger("death");
            }
            LoseLife();
        }
    }

    public void TakeDamage(float damageAmount)
    {
        healthSO.Value -= damageAmount;
    }

    // Returns the current health value
    public float GetHealth()
    {
        if (healthSO != null)
        {
            return healthSO.Value;
        }
        else
        {
            return 0f;
        }
    }

    // Safely adds health and clamps to max
    public void AddHealth(float amount)
    {
        if (healthSO == null) return;
        healthSO.Value = Mathf.Clamp(healthSO.Value + amount, minHealth, maxHealth);
        Debug.Log("Health added. Current health: " + healthSO.Value);
        if (healthBar != null)
        {
            healthBar.fillAmount = healthSO.Value / maxHealth;
        }
    }
}
