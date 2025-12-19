using UnityEngine;
using System.Collections;

public class FallingPlatform : MonoBehaviour
{
    public float fallWait = 2f;
    public float  destroyWait = 1f;

    public GameObject platformPrefab;
    public float respawnDelay = 0f;

    bool isFalling;
    Rigidbody2D rb;

    
    private Vector2 startPos;
    private Quaternion startRot;
    private RigidbodyType2D startBodyType; 

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {   
        rb = GetComponent<Rigidbody2D>();
        startPos = transform.position;
        startRot = transform.rotation;
        startBodyType = rb.bodyType;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Checks if the player has landed on the platform
        if (collision.gameObject.CompareTag("Player") && !isFalling)
        {
            StartCoroutine(Fall());
        }
    }

    private IEnumerator Fall()
    {
        isFalling = true;
        //Wait before falling
        yield return new WaitForSeconds(fallWait);
        //Make the platform fall
        rb.bodyType = RigidbodyType2D.Dynamic;
        // Destroy this instance after a short delay so it falls away
        Destroy(gameObject, destroyWait);
        // Wait until the object is destroyed and optionally wait more before respawning
        yield return new WaitForSeconds(destroyWait + respawnDelay);
        
        // Spawn a new platform at the original position
        GameObject spawned = null;
        
        spawned = Instantiate(platformPrefab, startPos, startRot);

        if (spawned != null)
        {
            // Ensure the spawned platform is reset to its original state
            FallingPlatform newPlatform = spawned.GetComponent<FallingPlatform>();
            if (newPlatform != null)
            {
                newPlatform.Respawn(startBodyType);
            }
        }
    }

    public void Respawn(RigidbodyType2D bodyType)
    {
        // Reset the platform's state
        rb = GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.linearVelocity = Vector2.zero;
            rb.bodyType = bodyType;
        }
        isFalling = false;
        transform.position = startPos;
        transform.rotation = startRot;
    }
}

