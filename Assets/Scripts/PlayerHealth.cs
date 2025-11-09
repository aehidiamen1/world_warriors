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
        maxHealth = health;
        //Ensures that the starting health is within the set boundaries
        health = Mathf.Clamp(health, minHealth, maxHealth);
    }

    // Update is called once per frame
    void Update()
    {
        //Restrict the health to min and max health
        health = Mathf.Clamp(health, minHealth, maxHealth);
        //Restrict the fillAmount to the min health and max health
        healthBar.fillAmount = Mathf.Clamp(health / maxHealth, 0 ,1);
    }
}
