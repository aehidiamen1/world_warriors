using UnityEngine;

public class Damage : MonoBehaviour
{
    public PlayerHealth pHealth;
    public float damage;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionEnter2D(Collision2D other)
    {
        //Checks if the player has collided with the obstacle and reduces the players health
        if (other.gameObject.CompareTag("Player"))
        {
            pHealth.health -= damage;
        }
    }
}
