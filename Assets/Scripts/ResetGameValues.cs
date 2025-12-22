using UnityEngine;

public class ResetGameValues : MonoBehaviour
{
    private static ResetGameValues instance;
    
    [SerializeField]
    private FloatSO coinCountSO;
    [SerializeField]
    private FloatSO healthSO;
    [SerializeField]
    private FloatSO livesSO;

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
        coinCountSO.Value = 0;
        healthSO.Value = 0;
        livesSO.Value = 0;
        Debug.Log("Game values reset.");
    }
}