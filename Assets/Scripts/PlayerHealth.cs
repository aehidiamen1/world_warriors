using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public float health;
    public float minHealth;
    public float maxHealth;
    public Image healthBar;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // If health isn't set then set to maxHealth
        if (health <= 0)
        {
            health = maxHealth;
        }

        //Ensures that the starting health is within the set boundaries
        health = Mathf.Clamp(health, minHealth, maxHealth);
    }

    // Update is called once per frame
    void Update()
    {
        //Restrict the health to min and max health
        health = Mathf.Clamp(health, minHealth, maxHealth);
        //Update the health bar
        healthBar.fillAmount = health / maxHealth;
    }
}
