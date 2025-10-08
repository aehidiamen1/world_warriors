using UnityEngine;

public class SideScrollCamera : MonoBehaviour
{
    public Transform target;        // The player character
    public Vector3 offset;          // Offset from player (e.g. (2, 1, -10))
    public float smoothSpeed = 0.125f; // Camera follow speed
    public bool followY = true;     // Toggle vertical follow

    void LateUpdate()
    {
        if (target == null) return;

        // Desired position
        Vector3 desiredPosition = target.position + offset;

        // If you don’t want the camera to move vertically
        if (!followY)
        {
            desiredPosition.y = transform.position.y;
        }

        // Smooth movement
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;
    }
}
