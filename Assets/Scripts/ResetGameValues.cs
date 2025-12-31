using UnityEngine;

public class ResetGameValues : MonoBehaviour
{
    private static ResetGameValues instance;
    private static bool hasReset = false;
    
    [SerializeField]
    private FloatSO coinCountSO;
    [SerializeField]
    private FloatSO healthSO;
    [SerializeField]
    private FloatSO livesSO;
    [SerializeField]
    private ArraySO inventoryData;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            ResetValues();
        }
    }

    private void ResetValues()
    {
        if (!hasReset)
        {
            coinCountSO.Value = 0;
            healthSO.Value = 0;
            livesSO.Value = 0;
            inventoryData.ClearAll();
            hasReset = true;
            Debug.Log("Game values reset.");
        }
        else if (GameOverScreen.reset)
        {
            coinCountSO.Value = 0;
            healthSO.Value = 0;
            livesSO.Value = 0;
            inventoryData.ClearAll();
            GameOverScreen.reset = false;
            Debug.Log("Game values reset on returning to main menu after game is over.");
        }
        else
        {
            Debug.Log("Game values have already been reset. Skipping reset.");
        }
    }
}