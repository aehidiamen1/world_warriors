using UnityEngine;

public class ParallaxScript : MonoBehaviour
{

    [SerializeField] private float parallaxEffectMultiplier;
    private Transform cameraTransform;
    private Vector3 lastCameraPosition;
    private void Start()
    {
        cameraTransform = Camera.main.transform;
        lastCameraPosition = cameraTransform.position;
    }

    // Update is called once per frame
    private void Update()
    {
        Vector3 movement = cameraTransform.position - lastCameraPosition;
        transform.position += new Vector3(movement.x * parallaxEffectMultiplier, movement.y * parallaxEffectMultiplier, 0);
        lastCameraPosition = cameraTransform.position;
    }
}
