using UnityEngine;
using Unity.Cinemachine;

public class CameraBoundsSwitcher : MonoBehaviour
{
    [SerializeField] private CinemachineCamera virtualCamera;
    [SerializeField] private BoxCollider2D newBoundsCollider;
    
    private CinemachineConfiner2D confiner;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        confiner = virtualCamera.GetComponent<CinemachineConfiner2D>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // Switch to the other camera bounds
            confiner.BoundingShape2D = newBoundsCollider;
            confiner.InvalidateBoundingShapeCache();
        }
    }
}
