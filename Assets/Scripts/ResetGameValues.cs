using UnityEngine;

public class ResetGameValues : MonoBehaviour
{
    [SerializeField]
    private FloatSO coinCountSO;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
        coinCountSO.Value = 0;
    }
}