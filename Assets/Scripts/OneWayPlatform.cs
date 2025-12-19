using UnityEngine;

public class OneWayPlatform : MonoBehaviour
{
    PlayerOneWayPlatformControls playerControls;
    PlatformEffector2D platformEffector;

    private void Awake()
    {
        platformEffector = GetComponent<PlatformEffector2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            playerControls = collision.collider.GetComponent<PlayerOneWayPlatformControls>();
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (playerControls == null)
        {
            return;
        }
        
        if (playerControls.fallThrough)
        {
            platformEffector.rotationalOffset = 180f;
            playerControls = null;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        platformEffector.rotationalOffset = 0f;
        playerControls = null;
    }
}
