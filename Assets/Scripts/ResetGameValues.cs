using UnityEngine;

public class ResetGameValues : MonoBehaviour
{
    private static bool hasRunOnce = false;
    
    [SerializeField]
    private FloatSO coinCountSO;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
        // Reset game values only once to prevent multiple resets in case
        // the player returns to the main menu within the same session
        if (hasRunOnce == false)
        {
            coinCountSO.Value = 0;
            hasRunOnce = true;
            Debug.Log("Game values reset.");
        }
    }
}