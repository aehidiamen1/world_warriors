using UnityEngine;
using System.Collections;

public class FallingPlatform : MonoBehaviour
{
    public float fallWait = 2f;
    public float  destroyWait = 1f;

    bool isFalling;
    Rigidbody2D rb;

    // Stored start state for respawn
    private Vector3 startPos;
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

        // Wait while the platform falls, then reset it back to start state
        yield return new WaitForSeconds(destroyWait);

        // Reset physics and transform back to the starting state
        rb.velocity = Vector2.zero;
        rb.angularVelocity = 0f;
        rb.bodyType = startBodyType;
        transform.position = startPos;
        transform.rotation = startRot;

        isFalling = false;
    }
}
