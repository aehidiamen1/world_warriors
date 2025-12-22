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
    private ArraySO inventorySO;

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
            inventorySO.Values = new bool[0];
            hasReset = true;
            Debug.Log("Game values reset.");
        }
        else
        {
            Debug.Log("Game values have already been reset. Skipping reset.");
        }
    }
}