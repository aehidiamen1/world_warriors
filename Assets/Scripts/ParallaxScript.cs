using UnityEngine;
using UnityEngine.InputSystem;

public class ParallaxScript : MonoBehaviour
{
    //Allows me to manually adjust the offset multiplier in unity
    [SerializeField] private float offsetMultiplier;
    //Controls the speed at which the object moves to the offset position
    [SerializeField] private float smoothTime;

    private Vector3 startPosition;
    private Vector3 velocity;

    private void Start()
    {
        //Initial position of the layer
        startPosition = transform.position;
    }

    private void Update()
    {
        Vector2 mousePos = Mouse.current.position.ReadValue();

        // Use the mouse position to adjust the offset for the parallax effect
        Vector2 offset = Camera.main.ScreenToViewportPoint(mousePos);

        // Move the layer towards the position offset based on the position of the mouse pointer
        transform.position = Vector3.SmoothDamp(transform.position, startPosition + (Vector3)(offset * offsetMultiplier), ref velocity, smoothTime
        );
    }
}
