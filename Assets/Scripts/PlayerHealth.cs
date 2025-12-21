using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public float health;
    public float minHealth;
    public float maxHealth;
    public Image healthBar;
    public int lives = 3;
    public int maxLives = 3;
    public int currentLives;
    public Image[] lifeImages;

    [SerializeField]
    private FloatSO HealthSO;

    //Set the starting position for respawn
    Vector2 CheckpointPos;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        CheckpointPos = transform.position;

        currentLives = lives;

        // If health isn't set then set to maxHealth
        if (HealthSO.Value <= 0)
        {
            HealthSO.Value = maxHealth;
        }

        //Ensures that the starting health is within the set boundaries
        HealthSO.Value = Mathf.Clamp(HealthSO.Value, minHealth, maxHealth);

        UpdateLivesUI();
    }

    // Update is called once per frame
    void Update()
    {
        //Restrict the health to min and max health
        HealthSO.Value = Mathf.Clamp(HealthSO.Value, minHealth, maxHealth);

        if (HealthSO.Value <= minHealth && currentLives > 0)
        {
            LoseLife();
        }

        //Update the health bar
        healthBar.fillAmount = HealthSO.Value / maxHealth;
    }

    void LoseLife()
    {
        currentLives--;
        
        if (currentLives > 0)
        {
            // Restore health to full
            HealthSO.Value = maxHealth;
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
}
