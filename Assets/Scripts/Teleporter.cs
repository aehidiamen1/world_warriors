using UnityEngine;

public class Teleporter : MonoBehaviour
{
    //Sets the destination of the teleporter in the inspector
    [SerializeField] private Transform destination;

    public Transform GetDestination()
    {
        return destination;
    }
}
