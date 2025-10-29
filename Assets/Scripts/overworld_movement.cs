using UnityEngine;
public class overworld_movement : MonoBehaviour
{
    public float speed = 5f;
    public Collider2D pathCollider; 

    private Rigidbody2D rb;
    private Collider2D playerCollider;
    private Vector2 movement;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        playerCollider = GetComponent<Collider2D>();

        if (pathCollider == null)
        {
            Debug.LogError("Assign a pathCollider!");
        }
    }

    void Update()
    {
        // Get input
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        movement.Normalize(); // prevent faster diagonal movement
    }

    void FixedUpdate()
    {
        Vector2 newPosition = rb.position + movement * speed * Time.fixedDeltaTime;

        // Temporarily move the collider to the new position
        Vector2 delta = newPosition - rb.position;
        ContactFilter2D filter = new ContactFilter2D();
        filter.useTriggers = false;
        filter.SetLayerMask(LayerMask.GetMask("Default")); // or your path layer

        Collider2D[] results = new Collider2D[1];
        int count = playerCollider.Overlap(filter, results);

        // Check if the new position would be outside the path
        if (IsPositionInsidePath(newPosition))
        {
            rb.MovePosition(newPosition);
        }
    }

    bool IsPositionInsidePath(Vector2 targetPos)
    {
        // Save original position
        Vector2 originalPos = rb.position;

        // Move temporarily
        rb.position = targetPos;

        // Check if the player collider is fully inside the path
        Bounds playerBounds = playerCollider.bounds;
        Vector3[] corners = new Vector3[4];
        corners[0] = new Vector3(playerBounds.min.x, playerBounds.min.y);
        corners[1] = new Vector3(playerBounds.max.x, playerBounds.min.y);
        corners[2] = new Vector3(playerBounds.min.x, playerBounds.max.y);
        corners[3] = new Vector3(playerBounds.max.x, playerBounds.max.y);

        foreach (var corner in corners)
        {
            if (!pathCollider.OverlapPoint(corner))
            {
                rb.position = originalPos; // restore
                return false; // at least one corner is outside
            }
        }

        rb.position = originalPos; // restore
        return true; // all corners are inside
    }
}
